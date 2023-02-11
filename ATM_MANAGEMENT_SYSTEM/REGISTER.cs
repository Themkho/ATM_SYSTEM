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
    public partial class REGISTER : Form
    {
        public REGISTER()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ctime.Text = DateTime.Now.ToString();
        }

        private void REGISTER_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ctime_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NKGUDI\Documents\ATMMSDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if(accnumtbl.Text == "" || idnumtbl.Text == "" || surnametbl.Text == "" || nametbl.Text == "" || gendertbl.Text == "" || titletbl.Text == "" || cellnumtbl.Text == "" || addresstbl.Text == "" || pintbl.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Accounttbl values('"+accnumtbl.Text+ "', '"+idnumtbl.Text+ "', '"+surnametbl.Text+ "', '"+nametbl.Text+ "', '"+gendertbl.SelectedItem.ToString()+ "', '"+titletbl.SelectedItem.ToString()+ "', '"+cellnumtbl.Text+ "', '"+addresstbl.Text+ "', '"+pintbl.Text+ "', '"+bal+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Registered!");
                    Con.Close();
                    LOGIN login = new LOGIN();
                    login.Show();
                    this.Hide();
                }catch(Exception Err)
                {
                    MessageBox.Show(Err.Message);
                }
            }
        }
    }
}
