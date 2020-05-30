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

namespace HelpDesk
{
    public partial class Customer : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\CIS 237\Projects\Project 2\HelpDesk\HelpDesk\HelpDeskTicket.accdb");
        OleDbDataAdapter da;
        OleDbCommand myCommand;

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            //Load up the tickets from the user
            try
            {
                conn.Open(); //Open the connection
                //Command used to search all tickets of the logged in user
                FillTable();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();//Close connection
            }
        }//End form load event

        public void FillTable()
        {
            //Pre: does not need anything initialized
            //Post: Fills the list table with data that was queried
            //Purpose: to query data then pass that data into a table

            OleDbDataReader myReader = null;
            //Command used to search all tickets of the logged in user
            myCommand = new OleDbCommand("Select * from Tickets where userID =" + Properties.Settings.Default.userID, conn);

            //Grab the UserID from the table
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                //Fill out the table with the information 
                lstTickets.Items.Add(myReader["techID"].ToString() + " | " + myReader["Title"].ToString() + " | " + myReader["Urgency"].ToString()
                    + " | " + myReader["description"].ToString() + " | " + myReader["dateSubmitted"].ToString()
                    + " | " + myReader["status"].ToString() + " | " + myReader["userID"].ToString());
            }
        }// End FillTable

        //Form closing
        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            userSelectForm select = new userSelectForm();
            select.Show();
        }//End form closing event

        //Search the for a ticket depending on the status
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Search the databse for the status selected with the loginID of the user logged in
            try
            {
                conn.Open(); //Open the connection
                lstTickets.Items.Clear(); //Clear out the list
                OleDbDataReader myReader = null;
                //If nothing is selected for the status throw and error
                if(cmbStatus.SelectedIndex == -1)
                {
                    //Error
                    MessageBox.Show("Please select a status first!");
                }
                else
                {

                    //Command used to search the database for the tickets of the user that is logged in
                    myCommand = new OleDbCommand("Select * from Tickets where status = '" + cmbStatus.Text + "' and userID = " + Properties.Settings.Default.userID, conn);

                    //Grab the UserID from the table
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Fill out the list box
                        lstTickets.Items.Add(myReader["techID"].ToString() + " | " + myReader["Title"].ToString() + " | " + myReader["Urgency"].ToString()
                        + " | " + myReader["description"].ToString() + " | " + myReader["dateSubmitted"].ToString()
                        + " | " + myReader["status"].ToString() + " | " + myReader["userID"].ToString());
                    }
                }
                
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();//Close Connection
            }
        }//End btnSearch clicked event
    }
}
