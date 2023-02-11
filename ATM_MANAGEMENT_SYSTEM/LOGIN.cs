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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ctime.Text = DateTime.Now.ToString();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ctime_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            REGISTER register = new REGISTER();
            register.Show();
            this.Hide();
        }

        public static string AccNum;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NKGUDI\Documents\ATMMSDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (accnumtbl.Text == "" || pintbl.Text == "")
            {
                MessageBox.Show("Fill All Fields!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Accounttbl where AccNum = '" + accnumtbl.Text + "' and Pin = '" + pintbl.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows[0][0].ToString() == "1")
                    {
                        AccNum = accnumtbl.Text;
                        HOME home = new HOME();
                        home.Show();
                        this.Hide();
                        Con.Close();
                    }else
                    {
                        MessageBox.Show("Wrong Account Number Or Pin Code!");
                    }
                    Con.Close();
                }
                catch (Exception Err)
                {
                    MessageBox.Show(Err.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
