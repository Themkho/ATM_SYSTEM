using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_MANAGEMENT_SYSTEM
{
    public partial class DEPOSIT : Form
    {
        public DEPOSIT()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ctime.Text = DateTime.Now.ToString();
        }

        private void DEPOSIT_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button1.BackColor = Color.SteelBlue;
            button1.ForeColor = Color.White;
            getbalance();
        }

        private void ctime_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DEPOSIT deposit = new DEPOSIT();
            deposit.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WITHDRAW withdraw = new WITHDRAW();
            withdraw.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TRANSFER transfer = new TRANSFER();
            transfer.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            STATEMENT statement = new STATEMENT();
            statement.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PIN pin = new PIN();
            pin.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NKGUDI\Documents\ATMMSDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = LOGIN.AccNum;
        private void addtransaction()
        {
            string TransType = "DEPOSIT";
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('"+Acc+"','"+TransType+"','"+depositlbl.Text+"','"+DateTime.Now.ToString()+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        int oldbalance, newbalance;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance from Accounttbl where AccNum = '" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void depositbnt_Click(object sender, EventArgs e)
        {
            if(depositlbl.Text == "" || Convert.ToInt32(depositlbl.Text) <= 0)
            {
                MessageBox.Show("Enter Valid Amount To Deposit!");
            }
            else
            {
                newbalance = oldbalance + Convert.ToInt32(depositlbl.Text);
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Balance = " + newbalance + " where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit!");
                    Con.Close();
                    addtransaction();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Err)
                {
                    MessageBox.Show(Err.Message);
                }
            }
        }
    }
}
