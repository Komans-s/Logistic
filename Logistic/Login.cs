using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace Logistic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\hikmet can yıldız\source\repos\Logistic\Logistic\DatabaseComp.mdf"";Integrated Security=True");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select count(*) from LoginTable where Username = '" + tbxLoginUsername.Text + "' and Password = '" + tbxLoginPassword.Text + "'", connection);
            DataSet dataSet = new DataSet();

            connection.Open();
            sqlDataAdapter.Fill(dataSet,"Login");
            connection.Close();

            if (dataSet.Tables["Login"].Rows[0][0].ToString() != "0") 
            {
                Form1 f = new Form1(this);
                f.Visible = true;
                this.Visible = false;
                tbxLoginPassword.Text = "";
                tbxLoginUsername.Text = "";
            }
            else
            {
                MessageBox.Show("Wrong username or password!","Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
                tbxLoginPassword.Text = "";
                tbxLoginUsername.Text = "";
            }
        }
    }
}
