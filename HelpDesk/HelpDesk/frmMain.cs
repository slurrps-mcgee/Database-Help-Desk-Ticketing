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
    public partial class frmMain : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\CIS 237\Projects\Project 2\HelpDesk\HelpDesk\HelpDeskTicket.accdb");
        OleDbDataAdapter da;
        OleDbCommand myCommand;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); //Open the connection
                FillType();//Call the fillType method
                FillArea();//Call the FillArea method

            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();//Close event
            }
        }//End form load event

        //Area
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sets the default urgency depending on the selection from the cmbAreas combo box
            if (cmbArea.SelectedIndex == 1)
            {
                radHigh.Checked = true;
            }
            else if (cmbArea.SelectedIndex == 2)
            {
                radLow.Checked = true;
            }
        }//End cmbArea selectedindex change event

        public void FillType()
        {
            //Pre: nothing to be initialized
            //Post: Fills out the cmbType combo box
            //Purpose: to select all the information from the TicketType table in the database and then fill out the appropriate combo box

            cmbType.Items.Clear();
            //Reload Combo Box
            //Fill the combo box
            myCommand = new OleDbCommand("Select * from TicketType", conn);
            OleDbDataReader myReader = null;

            //Execute myCommand to the reader
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                //Associative array
                cmbType.Items.Add(myReader["typeID"].ToString() + " " + myReader["type"].ToString());
            }
        }//End FillType

        public void FillArea()
        {
            //Pre: nothing to be initialized
            //Post: Fills out the cmbArea combo box
            //Purpose: to select all the information from the Areas table in the database and then fill out the appropriate combo box

            cmbArea.Items.Clear();
            //Reload Combo Box
            //Fill the combo box
            myCommand = new OleDbCommand("Select * from Areas", conn);
            OleDbDataReader myReader = null;

            //Execute myCommand to the reader
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                //Associative array
                cmbArea.Items.Add(myReader["areaID"].ToString() + " " + myReader["area"].ToString());
            }
        }//End FillArea

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Variables to hold the data that will be inserted into the table 
            string title = "", urgency = "", description = "", building = "", status = "";
            int area, type, roomNum = 0, techID, userID;

            //Default expectedTime is 30 minutes
            string expectedTime = "30 minutes";
            if(cmbArea.SelectedIndex == -1 && cmbBuilding.SelectedIndex == -1 && cmbType.SelectedIndex == -1 && txtRoomNum.Text == "" && txtTitle.Text == "" && rtbDescription.Text == "")
            {
                MessageBox.Show("Please make sure the form is completely filled out!");
            }
            else
            {
                //Check which radial button is checked then set the Urgency string to equal the appropriate text
                if (radLow.Checked == true)
                {
                    urgency = "Low";
                }
                else if (radMedium.Checked == true)
                {
                    urgency = "Medium";
                }
                else if (radHigh.Checked == true)
                {
                    urgency = "High";
                }
                //Check to make sure you have selected a urgency level
                if (radHigh.Checked == false && radMedium.Checked == false && radLow.Checked == false)
                {
                    MessageBox.Show("Please select a level of urgency!");
                    return;
                }
                else
                {
                    //Set the variables to equal the user input on the form
                    title = txtTitle.Text;
                    description = rtbDescription.Text;
                    building = cmbBuilding.Text;
                    status = "Open";

                    //Default the tech ID to be 4 which is the unassigned techID
                    techID = 4; //Unassigned
                                //Grab the userID which is saved in the program from the login information
                    userID = Convert.ToInt32(Properties.Settings.Default.userID);

                    //Grabs the areaID number----
                    //Grab the string of the item
                    string index = cmbArea.Text.ToString();
                    //Grab the position of the first space in the string
                    int position = index.IndexOf(" ");
                    area = Convert.ToInt32(index.Substring(0, position));
                    //--------------------------------------------------------
                    //Grabs the typeID number----
                    //Grab the string of the item
                    string strType = cmbType.Text.ToString();
                    //Grab the position of the first space in the string
                    int pos = index.IndexOf(" ");
                    type = Convert.ToInt32(strType.Substring(0, pos));
                    //--------------------------------------------------------

                    //Here we will try to convert the user input to an integer
                    try
                    {
                        //Set the room number to equal the user input
                        roomNum = Convert.ToInt32(txtRoomNum.Text);
                        //Check to make sure that the number is greater than 0
                        if (roomNum < 0)
                        {
                            //Error
                            MessageBox.Show("Number cannot be negative!");
                        }
                        //Check to see if the number is not greater than 399
                        else if (roomNum > 399)
                        {
                            //Error
                            MessageBox.Show("Number is too large!");
                        }

                    }
                    catch (FormatException ex)
                    {
                        //Error
                        MessageBox.Show("This is not an integer please try again.");
                    }
                    //Here we will try and insert the information gathered into a new record in the Tickets table in the database.
                    try
                    {
                        conn.Open(); //Open the connection

                        //Set the command
                        myCommand = new OleDbCommand("INSERT INTO Tickets (Title, areaID, typeID, Urgency, description, dateSubmitted, building, roomNumber, expectedTime, techID, status, userID)" +
                            " VALUES" + "('" + title + "'" + "," + area + "," + type + ", '" + urgency + "', '" + description + "', '" + System.DateTime.Now + "', '" + building + "',"
                            + roomNum + ", '" + expectedTime + "', " + techID + ", '" + status + "', " + userID + ")", conn);

                        //setting the command to the adapter
                        da = new OleDbDataAdapter(myCommand);
                        //Execute the command to the database
                        da.SelectCommand.ExecuteNonQuery();
                        //End Command--------------------------------

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();//Close the connection
                    }

                    this.Close(); //Close the form
                                  //Set a new instance of the selection form
                    userSelectForm select = new userSelectForm();
                    select.Show(); //Show the selection form
                }
            }
            
        }//End btnSubmit click event

        //form closing event
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            userSelectForm select = new userSelectForm();
            select.Show();
        }//End form closing event
    }
}
