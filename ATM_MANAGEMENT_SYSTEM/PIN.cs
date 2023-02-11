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
    public partial class PIN : Form
    {
        public PIN()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ctime.Text = DateTime.Now.ToString();
        }

        private void PIN_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button5.BackColor = Color.SteelBlue;
            button5.ForeColor = Color.White;
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
        private void button8_Click(object sender, EventArgs e)
        {
            if (pin1lbl.Text == "" || pin2lbl.Text == "")
            {
                MessageBox.Show("Enter And Confirm The New Pin!");
            }
            else if (pin1lbl.Text != pin2lbl.Text)
            {
                MessageBox.Show("Pin 1 And Pin 2 Do Not Match!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Accounttbl set Pin = " + pin1lbl.Text + " where AccNum = '"+Acc+"'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN Successfully Updated");
                    Con.Close();
                    LOGIN home = new LOGIN();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
