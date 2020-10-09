using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Login : Form
    {
        String pwd;
        SqlConnection con = new SqlConnection("Data Source=SAGAR;Initial Catalog=CrackersManagementSystem;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Login()
        {
            InitializeComponent();
        }



        private void xButton1_Click(object sender, EventArgs e)
        {


            /*     cmd = new SqlCommand("select * from tblLoginDetails where username='" + txtusername.Text + "' and password ='" + txtpassword.Text + "';", con);
           
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);

                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();

                 if (dt.Rows.Count > 0)
                 {
                     Home settingsForm = new Home();
                     settingsForm.Show();
                     this.Hide();
                 }

                 else
                 {

                     MessageBox.Show("Please enter Correct Username and Password");
                 }  */
            SqlDataReader da;
            con.Close();
            cmd = new SqlCommand("select  password from tblLoginDetails where username='" + txtusername.Text + "' ;", con);
            con.Open();
            da = cmd.ExecuteReader();
            if (da.HasRows)
            {
                da.Read();
                pwd = da.GetValue(0).ToString();

                if (pwd == txtpassword.Text)
                {
                    Crackers2() hm = new Crackers2();
                }
                else
                {
                    MessageBox.Show("Password not matched");
                }

            }
            else
            {
                MessageBox.Show("No username found");
            }
            con.Close();

        }

        private void checkUser()
        {
            SqlDataReader da;
            con.Close();
            cmd = new SqlCommand("select  password from tblLoginDetails where username='" + txtusername.Text + "' ;", con);
            con.Open();
            da = cmd.ExecuteReader();
            if (da.HasRows)
            {
                da.Read();
                txtusername.BackColor = Color.Green;
                txtusername.ForeColor = Color.White;
            }
            else
            {
                txtusername.BackColor = Color.Red;
                txtusername.ForeColor = Color.White;
            }
            //   throw new NotImplementedException();
        }

        private void xButton2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
        }

        private void xButton1_Enter(object sender, EventArgs e)
        {

        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            checkUser();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }



    }
}
