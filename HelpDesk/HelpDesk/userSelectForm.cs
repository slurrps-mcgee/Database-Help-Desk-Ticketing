using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using LoginForm;

namespace HelpDesk
{
    public partial class userSelectForm : Form
    {
        //Connection class
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\CIS 237\Projects\Project 2\HelpDesk\HelpDesk\HelpDeskTicket.accdb");
        OleDbDataAdapter da;
        OleDbCommand myCommand;

        public userSelectForm()
        {
            InitializeComponent();
        }

        private void userSelectForm_Load(object sender, EventArgs e)
        {
            //Boolean to hold if they are IT or not
            bool isIT = false;

            try
            {
                conn.Open(); //Open the connection

                //Store login
                //store hashed password
                //store salt
                myCommand = new OleDbCommand("select IsIT from UserInformation where userID = " + Properties.Settings.Default.userID, conn);

                isIT = Convert.ToBoolean(myCommand.ExecuteScalar());
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            //If isIT is try they will have the option to go to the Technitian form
            if(isIT == false)
            {
                btnIT.Visible = false;
            }
            else
            {
                btnIT.Visible = true;
            }
        }
        //Open the Customer form
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer users = new Customer();
            this.Hide();
            users.Show();
        }
        //Open the Main form the Ticket creation form
        private void btnFileTicket_Click(object sender, EventArgs e)
        {
            frmMain fileTicket = new frmMain();
            this.Hide();
            fileTicket.Show();
        }
        //Open the Technitian form
        private void btnIT_Click(object sender, EventArgs e)
        {
            TechnitianForm Tech = new TechnitianForm();
            this.Hide();
            Tech.Show();
        }
        //Show the login form again.
        private void userSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}
