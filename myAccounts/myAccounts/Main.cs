using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace myAccounts
{
    public partial class Main : Form
    {
       
         SqlCommandBuilder scb;
         SqlDataAdapter sda;
         DataTable dt;

        public Main()
        {
            InitializeComponent();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\steve\Documents\Steve.mdf;
                                                   Integrated Security = True; Connect Timeout = 30");
            sda=new SqlDataAdapter(@"SELECT Username,Password, Domain FROM Accounts",con);
            dt=new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scb=new SqlCommandBuilder(sda);
         
            sda.Update(dt);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
