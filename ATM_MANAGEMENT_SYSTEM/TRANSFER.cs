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
    public partial class TRANSFER : Form
    {
        public TRANSFER()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ctime.Text = DateTime.Now.ToString();
        }

        private void BALANCE_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button3.BackColor = Color.SteelBlue;
            button3.ForeColor = Color.White;
            getbalance1();
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
        int bal1, bal2;
        private void addtransaction1()
        {
            string TransType = "TRANSFER TO " + personlbl.Text;
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + Acc + "','" + TransType + "','" + amountlbl.Text + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void addtransaction2()
        {
            string TransType = "RECEIVED FROM " + referencelbl.Text;
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + accnumlbl.Text + "','" + TransType + "','" + amountlbl.Text + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        int oldbalance, newbalance1, newbalance2;

        private void button8_Click(object sender, EventArgs e)
        {
            if (amountlbl.Text == "" || Convert.ToInt32(amountlbl.Text) <= 0)
            {
                MessageBox.Show("Enter A Valid Amount!");
            }
            else if (accnumlbl.Text == Acc)
            {
                MessageBox.Show("You Cannot Transfer Money Into Your Account!");
            }
            else if (Convert.ToInt32(amountlbl.Text) > bal1)
            {
                MessageBox.Show("Balance Cannot Be Negative");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda3 = new SqlDataAdapter(" select count(*) from Accounttbl where AccNum = '" + accnumlbl.Text + "'", Con);
                    DataTable dt3 = new DataTable();
                    sda3.Fill(dt3);
                    
                    if(dt3.Rows[0][0].ToString() == "1")
                    {
                        try
                        {
                            SqlDataAdapter sda2 = new SqlDataAdapter(" select Balance from Accounttbl where AccNum = '" + accnumlbl.Text + "'", Con);
                            DataTable dt2 = new DataTable();
                            sda2.Fill(dt2);
                            bal2 = Convert.ToInt32(dt2.Rows[0][0].ToString());

                            newbalance1 = bal1 - Convert.ToInt32(amountlbl.Text);
                            newbalance2 = bal2 + Convert.ToInt32(amountlbl.Text);

                            string query1 = "update Accounttbl set Balance = " + newbalance1 + " where AccNum='" + Acc + "'";
                            string query2 = "update Accounttbl set Balance = " + newbalance2 + " where AccNum='" + accnumlbl.Text + "'";
                            SqlCommand cmd1 = new SqlCommand(query1, Con);
                            SqlCommand cmd2 = new SqlCommand(query2, Con);
                            cmd1.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Success Transfer!");
                            Con.Close();
                            addtransaction1();
                            addtransaction2();
                            HOME home = new HOME();
                            home.Show();
                            this.Hide();
                        }
                        catch (Exception Err)
                        {
                            MessageBox.Show(Err.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account Number Does Not Exist!");
                    }
                    Con.Close();
                }
                catch (Exception Err)
                {
                    MessageBox.Show(Err.Message);
                }
            }
        }

        private void getbalance1()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter(" select Balance from Accounttbl where AccNum = '" + Acc + "'", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            bal1 = Convert.ToInt32(dt1.Rows[0][0].ToString());
            Con.Close();
        }
    }
}
