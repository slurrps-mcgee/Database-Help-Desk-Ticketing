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
    public partial class TechnitianForm : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\CIS 237\Projects\Project 2\HelpDesk\HelpDesk\HelpDeskTicket.accdb");
        OleDbDataAdapter da;
        OleDbCommand myCommand;
        DataSet mySet;

        public TechnitianForm()
        {
            InitializeComponent();
        }
        private void TechnitianForm_Load(object sender, EventArgs e)
        {
            //Variable to hold the boolean of isAdmin
            bool isAdmin = false;
            try
            {
                conn.Open(); //Open the connection
                FillTechnitian(); //Call the fill Technitian method to fill the combo box
                FillTable();//Call the fill table method to fill the list box

                //Query to check if the user is an admin
                myCommand = new OleDbCommand("select t.isAdmin from Technitians t inner join UserInformation i on t.techID = i.techID where i.userID = " + Properties.Settings.Default.userID, conn);
                //Execute and set the data to be held in the variable isAdmin
                isAdmin = Convert.ToBoolean(myCommand.ExecuteScalar());

            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            //Sets the ITAdmin label and button to be invisible if user is not and admin and visable if they are
            if (isAdmin == false)
            {
                btnIT.Visible = false;
                lblAdmin.Visible = false;
            }
            else
            {
                btnIT.Visible = true;
                lblAdmin.Visible = true;
            }
        }//End form load event

        public void FillTechnitian()
        {
            //Pre: nothing needs to be initialized
            //Post: Fills in the combo box cmbTechnitian with data from the query that was ran
            //Purpose: to fill in the combo box cmbTechnitian with the query from the method

            cmbTechnitian.Items.Clear();
            //Reload Combo Box
            //Fill the combo box
            myCommand = new OleDbCommand("Select * from Technitians", conn);
            OleDbDataReader myReader = null;

            //Execute myCommand to the reader
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                //Associative array
                 cmbTechnitian.Items.Add(myReader["techID"].ToString() + " " + myReader["firstName"].ToString() + " " + myReader["lastName"].ToString());
            }
        }//End FillArea

        public void FillTable()
        {
            //Pre: does not need anything initialized
            //Post: Fills the list table with data that was queried
            //Purpose: to query data then pass that data into a table

            OleDbDataReader myReader = null;
            
            myCommand = new OleDbCommand("Select * from Tickets where status <> 'Closed'" , conn);

            //Grab the UserID from the table
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                listTickets.Items.Add(myReader["ticketID"].ToString() + " | " + myReader["Title"].ToString() + " | " + myReader["Urgency"].ToString()
                    + " | "  + myReader["description"].ToString() + " | " + myReader["dateSubmitted"].ToString()
                    + " | " + myReader["status"].ToString() + " | " + myReader["userID"].ToString());
            }

        }// End FillTable

        private void listTickets_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Variables to hold the information that will 
            string title = "", urgency = "", description = "", building = "", status = "";
            int area = 0, type = 0, roomNum = 0, userID = 0;
            int ticketID = 0;
            OleDbDataReader myReader = null;

            try
            {
                if(listTickets.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a ticket!");
                }
                else
                {
                    //Set strID to the text in the combo box books
                    string strID = listTickets.SelectedItem.ToString();
                    //Get the index of the position of Space in the text
                    int pos = strID.IndexOf(" ");
                    //Grab the letters starting at position 0 and going until the integer of position that was grabbed above.
                    ticketID = Convert.ToInt32(strID.Substring(0, pos));
                }
                
                conn.Open(); //Open the connection

                //Search for the information from the ticketID selected from the list box
                myCommand = new OleDbCommand("SELECT Tickets.*, TicketType.type, Areas.area, Technitians.* " +
                    "FROM TicketType INNER JOIN(Technitians INNER JOIN(Areas INNER JOIN Tickets ON Areas.areaID = Tickets.areaID)" +
                    " ON Technitians.techID = Tickets.techID) ON TicketType.typeID = Tickets.typeID where Tickets.ticketID = " + ticketID, conn);

                //Set myReader to execute the command
                myReader = myCommand.ExecuteReader();

                //Loop through all of the data starting with 1 because the custID is 0
                while (myReader.Read())
                {
                    //Grab all of the information and set it to the appropriate variables.
                    title = myReader["Title"].ToString();
                    area = Convert.ToInt32(myReader["areaID"]);
                    type = Convert.ToInt32(myReader["typeID"]);
                    urgency = myReader["Urgency"].ToString();
                    description = myReader["description"].ToString();
                    building = myReader["building"].ToString();
                    roomNum = Convert.ToInt32(myReader["roomNumber"]);
                    //techID = Convert.ToInt32(myReader["techID"]);
                    status = myReader["status"].ToString();
                    userID = Convert.ToInt32(myReader["userID"]);
                    txtType.Text = (myReader["typeID"].ToString() + " " + myReader["type"].ToString()); //Fill in the text of the type combo box
                    txtArea.Text = (myReader["areaID"].ToString() + " " + myReader["area"].ToString()); //Fill in the text of the area combo box
                    cmbTechnitian.Text = (myReader["Tickets.techID"].ToString() + " " + myReader["firstName"].ToString() + " " + myReader["lastName"].ToString()); //Fill in the text of the technitian combo box
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close(); //Close the connection
            }

            //Fill out the form with the information queried
            cmbStatus.Text = status;
            txtTitle.Text = title;
            txtBuilding.Text = building;
            txtRoomNum.Text = roomNum.ToString();
            rtbDescription.Text = description;

            //Check the appropriate radial button from the information queried
            if (urgency == "Low")
            {
                radLow.Checked = true;
            }
            else if (urgency == "Medium")
            {
                radMedium.Checked = true;
            }
            else
            {
                radHigh.Checked = true;
            }
        }//End listTickets selection index changed event

        //Update button to update the ticket record with a technition and status
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Use this to grab the techID
            int techID = 0;
            //Set the variable strID to the text inside of the selected customer combo box
            string strID = cmbTechnitian.Text.Trim();
            //Get the index of the position of first Space in the text
            int pos = strID.IndexOf(" ");
            //Grab the letters starting at position 0 and going until the integer of position that was grabbed above.
            techID = Convert.ToInt32(strID.Substring(0, pos));
            //----------------------------------------------------------------------------------------------
            //Use this to grab the ticketID
            int ticketID = 0;
            //Set strID to the text in the combo box books
            string strTicket = listTickets.SelectedItem.ToString();
            //Get the index of the position of Space in the text
            int position = strTicket.IndexOf(" ");
            //Grab the letters starting at position 0 and going until the integer of position that was grabbed above.
            ticketID = Convert.ToInt32(strTicket.Substring(0, position));
            //----------------------------------------------------------------------------------------------

            //Update the ticket with the techID and status selected from the cmbStatus combo box
            try
            {
                conn.Open(); //Open the connection
                //Update the techID and status where ticket ID = the ticketID selected from the list
                myCommand = new OleDbCommand("Update Tickets set techID =" + techID + ", status = '" + cmbStatus.Text + "' where ticketID = " + ticketID, conn);

                //execute the dataadapter
                da = new OleDbDataAdapter(myCommand);
                da.SelectCommand.ExecuteNonQuery();
                //Clear the list
                listTickets.Items.Clear();
                FillTable(); //Call the filltable method
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();//Close Connection
            }
        }//End btnUpdate click event

        //This button will query the tickets assigned to a single user
        private void btnITUserTickets_Click(object sender, EventArgs e)
        {
            //Check the cmbTechnitian is not = -1 if it is throw an error to make sure a technitian is selected
            if(cmbTechnitian.SelectedIndex == -1)
            {
                //Error
                MessageBox.Show("Please select a technition first before searching!");
            }
            else
            {
                //User this string operation to grab the TechID number-----------------
                int techID = 0;
                //Set the variable strID to the text inside of the selected customer combo box
                string strID = cmbTechnitian.Text.Trim();
                //Get the index of the position of first Space in the text
                int pos = strID.IndexOf(" ");
                //Grab the letters starting at position 0 and going until the integer of position that was grabbed above.
                techID = Convert.ToInt32(strID.Substring(0, pos));
                //----------------------------------------------------------------------------------------------
                OleDbDataReader myReader = null;
                listTickets.Items.Clear();

                try
                {
                    conn.Open(); //Open the connection
                    //select tickets where the techID is equal to the techID variable
                    myCommand = new OleDbCommand("Select * from Tickets where techID =" + techID, conn);

                    //Grab the UserID from the table
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Fill in the listTickets list box
                        listTickets.Items.Add(myReader["ticketID"].ToString() + " | " + myReader["Title"].ToString() + " | " + myReader["Urgency"].ToString()
                            + " | " + myReader["description"].ToString() + " | " + myReader["dateSubmitted"].ToString()
                            + " | " + myReader["status"].ToString() + " | " + myReader["userID"].ToString());
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();//Close tickets
                }
            }
        }//End btnITUserTickets click event

        //Open Tickets search
        private void btnOpenTickets_Click(object sender, EventArgs e)
        {
            //Search for any open tickets in the system
            try
            {
                conn.Open(); //Open the connection
                listTickets.Items.Clear();
                OleDbDataReader myReader = null;
                //Search for all tickets with a status of open
                myCommand = new OleDbCommand("Select * from Tickets where status = 'Open'", conn);

                //Grab the UserID from the table
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //Fill in the list
                    listTickets.Items.Add(myReader["ticketID"].ToString() + " | " + myReader["Title"].ToString() + " | " + myReader["Urgency"].ToString()
                        + " | " + myReader["description"].ToString() + " | " + myReader["dateSubmitted"].ToString()
                        + " | " + myReader["status"].ToString() + " | " + myReader["userID"].ToString());
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close(); //Close the ticket
            }
        }//End btnOpenTickets click event

        //ITAdmin button search for any statuses
        private void button1_Click(object sender, EventArgs e)
        {
            //ITAdmin lookup button code
            OleDbDataReader myReader = null;
            listTickets.Items.Clear();
            //Will fill up the list box with the selection of the status combo box
            try
            {
                conn.Open(); //Open the connection
                myCommand = new OleDbCommand("Select * from Tickets where status = '" + cmbStatus.Text + "'", conn);

                //Grab the UserID from the table
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    listTickets.Items.Add(myReader["ticketID"].ToString() + " | " + myReader["Title"].ToString() + " | " + myReader["Urgency"].ToString()
                        + " | " + myReader["description"].ToString() + " | " + myReader["dateSubmitted"].ToString()
                        + " | " + myReader["status"].ToString() + " | " + myReader["userID"].ToString());
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close(); //Close Connection
            }
        }//End btnIT click event

        //Form Closing event
        private void TechnitianForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //show the selection form
            userSelectForm select = new userSelectForm();
            select.Show();
        }//End form closing event
    }
}
