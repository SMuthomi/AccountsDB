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

namespace myAccounts
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

         SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\steve\Documents\Steve.mdf;
                                                Integrated Security=True;Connect Timeout=30");
         SqlDataAdapter sda=new SqlDataAdapter("Select Count(*) From Login where Username='"+ txtUserName.Text +"' and Password='"+txtPassword.Text+"'",con);
         DataTable dt=new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Main fm = new Main();
                fm.Show();
            }
            else
            {
                var str = "Please check Username and Password";
                lblText.Text = str;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
