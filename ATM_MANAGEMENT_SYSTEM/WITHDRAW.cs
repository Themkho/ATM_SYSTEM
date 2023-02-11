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
    public partial class WITHDRAW : Form
    {
        public WITHDRAW()
        {
            InitializeComponent();
        }

        private void WITHDRAW_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button2.BackColor = Color.SteelBlue;
            button2.ForeColor = Color.White;
            getbalance();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ctime.Text = DateTime.Now.ToString();
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
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from Accounttbl where AccNum = '" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "R " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void addtransaction1()
        {

            string TransType = "WITHDRAW";
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + Acc + "','" + TransType + "','" + 100 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message);
            }

        }
        private void addtransaction2()
        {

            string TransType = "WITHDRAW";
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + Acc + "','" + TransType + "','" + 200 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message);
            }

        }
        private void addtransaction3()
        {

            string TransType = "WITHDRAW";
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + Acc + "','" + TransType + "','" + 500 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message);
            }

        }
        private void addtransaction4()
        {

            string TransType = "WITHDRAW";
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + Acc + "','" + TransType + "','" + 1000 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message);
            }

        }
        private void addtransaction5()
        {

            string TransType = "WITHDRAW";
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + Acc + "','" + TransType + "','" + 2000 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message);
            }

        }
        private void addtransaction6()
        {

            string TransType = "WITHDRAW";
            try
            {
                Con.Open();
                string query = "insert into Transactiontbl values('" + Acc + "','" + TransType + "','" + 3000 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bal < 100)
            {
                MessageBox.Show("Balance Cannot Be Negative");
            }
            else
            {
                int newbalance = bal - 100;
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Balance = " + newbalance + " where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    addtransaction1();
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (bal < 200)
            {
                MessageBox.Show("Balance Cannot Be Negative");
            }
            else
            {
                int newbalance = bal - 200;
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Balance = " + newbalance + " where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
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
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Balance Cannot Be Negative");
            }
            else
            {
                int newbalance = bal - 500;
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Balance = " + newbalance + " where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    addtransaction3();
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance Cannot Be Negative");
            }
            else
            {
                int newbalance = bal - 1000;
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Balance = " + newbalance + " where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    addtransaction4();
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

        private void button12_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Balance Cannot Be Negative");
            }
            else
            {
                int newbalance = bal - 2000;
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Balance = " + newbalance + " where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    addtransaction5();
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

        private void button13_Click(object sender, EventArgs e)
        {
            if (bal < 3000)
            {
                MessageBox.Show("Balance Cannot Be Negative");
            }
            else
            {
                int newbalance = bal - 3000;
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Balance = " + newbalance + " where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    addtransaction6();
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

        private void button14_Click(object sender, EventArgs e)
        {
            AMOUNT amount = new AMOUNT();
            amount.Show();
            this.Hide();
        }
    }
}
