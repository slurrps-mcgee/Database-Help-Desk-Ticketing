/*Author: Kenneth Lamb
 * Date: 04/25/2020
 * Program: LoginForm
 * Purpose: To demonstrate salt and hashing
 * Error Checking: appropriate error checking to make sure all data is updated or inserted successfully
 */

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
using System.Security.Cryptography; //for the hash
using HelpDesk;
using System.Windows.Forms;


namespace LoginForm
{
    
    public partial class frmLogin : Form
    {
        
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\CIS 237\Projects\Project 2\HelpDesk\HelpDesk\HelpDeskTicket.accdb");
        OleDbDataAdapter da;
        OleDbCommand myCommand;
        //----
        userSelectForm UserSelection = new userSelectForm();//Set an instance of the userprofile form

        //-------------------------------------------Functions----------------------------------------------------
        //Create your random salt here
        string GetSalt()
        {
            //Pre: Needs no incoming variable
            //Post: Returns a random salt to the user
            //Purpose: To create a random salt and then return it

            var Random = new RNGCryptoServiceProvider();
            int maxLength = 32;

            Byte[] salt = new byte[maxLength];

            Random.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }//End GetSalt

        //Create a hashed password
        string HashedPassword(string password)
        {
            //Pre: Needs variable password to be initialized
            //Post: Returns a hashed password to the user
            //Purpose: To take a incoming string and then return it to the program

            string newPass = "";

            Byte[] data = Encoding.UTF8.GetBytes(password); //Convert to an array of bytes

            Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);

            newPass = Convert.ToBase64String(hash);

            return newPass;
        }//End HashedPassword
        //-------------------------------------------------------------------------------------------------------
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Variables
            int userCheck; //Check to see if user exists
            string userHashedPass; //holds the userPassword from the data table
            string UserSalt; //Holds the userSalt from the data table

            string incomingPass; //Holds the incoming password from the user
            string incomingHash; //Holds the incoming Hash from the user

            //Try a connection to the database
            try
            {
                conn.Open(); //Open connection
                //----
                //Command to check if the user exists
                string check = "select count(*) from UserInformation where userLogin = '" + txtLogin.Text + "'"; //Query if the user exists
                myCommand = new OleDbCommand(check, conn); //set a new command
                userCheck = Convert.ToInt32(myCommand.ExecuteScalar()); //execute
                //----------------------------------------------------------------------
                //Check if the user Exists in the database
                if (userCheck == 1)
                {
                    //User exists 
                    //Grab user salt
                    myCommand = new OleDbCommand("select saltPass from UserInformation where userLogin = '" + txtLogin.Text + "'", conn);
                    UserSalt = myCommand.ExecuteScalar().ToString();

                    //Grab input password and add the users salt
                    incomingPass = txtPassword.Text.Trim() + UserSalt;

                    //Hash the password
                    incomingHash = HashedPassword(incomingPass);

                    //get the HashedPassword from the database
                    myCommand = new OleDbCommand("select userPassword from UserInformation where userLogin = '" + txtLogin.Text + "'", conn);
                    userHashedPass = myCommand.ExecuteScalar().ToString();

                    //Check to see if they are the same
                    if(userHashedPass == incomingHash)
                    {
                        //Select the userID of the user loggging in and save it to the program while it is running
                        myCommand = new OleDbCommand("Select userID from UserInformation where userLogin = '" + txtLogin.Text + "'", conn);
                        HelpDesk.Properties.Settings.Default.userID = myCommand.ExecuteScalar().ToString(); //save the login text
                        this.Hide(); //Hide this form
                        UserSelection.Show(); //show the selection form
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password try again!"); //Error message
                        txtPassword.Clear();// Clear password text box
                    }
                }
                else
                {
                    //user does not exists
                    //allow to register
                    lblMessage.Text = "username does not exist!";
                    txtLogin.Clear();
                    txtPassword.Clear();
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
        }//End btnLogin clicked event

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Variables for the information to be inserted into the tables

            string salt; //Holds the salt created from the method GetSalt
            string password, hashedPass; //Holds the password and hashed password from the user input
            bool isIT = false;
            bool isAdmin = false;
            int itID = 0;

            //Checks to make sure all fields are filled out.
            if(txtLogin.Text == "" && txtPassword.Text == "" && txtConfirm.Text == "")
            {
                //Error
                MessageBox.Show("Please fill out the form before registering can complete."); //Error message
                
            }
            else
            {
                //Check to see if IT checkbox is checked
                if (chkIT.Checked == true)
                {
                    isIT = true;
                    //Check to make sure the name fields are not blank
                    if (txtFirstName.Text == "" && txtLastName.Text == "")
                    {
                        MessageBox.Show("Please fill out the first and last name of the IT user before continuing!");
                    }
                    else
                    {
                        //Check to see if the chbAdmin checkbox has been checked
                        if (chbAdmin.Checked == true)
                        {
                            isAdmin = true;
                        }
                        else
                        {
                            isAdmin = false;
                        }
                    }
                }
                else
                {
                    isIT = false;
                }
                //Checks to make sure both the password and confirm texts boxes text match eachother. 
                if (txtPassword.Text.Trim() == txtConfirm.Text.Trim())
                {
                    //register the user
                    salt = GetSalt(); //Grab the random salt
                    password = txtPassword.Text.Trim() + salt; //Append the salt to the user inputted password          
                    hashedPass = HashedPassword(password); //obtain the hashed version of the password by passing in the user inputted password that has the salt appended to it
                                                           //Check to see if the chkIT checkbox has been checked


                    //Used to Register the new user to the database
                    try
                    {
                        conn.Open(); //Open the connection
                        if (isIT == true)
                        {
                            myCommand = new OleDbCommand("Select Max(techID) from Technitians", conn);
                            itID = Convert.ToInt32(myCommand.ExecuteScalar().ToString()) + 1;

                        }
                        //Store login
                        //store hashed password
                        //store salt
                        myCommand = new OleDbCommand("Insert into UserInformation (userLogin, userPassword, saltPass, IsIT, techID) values ('" + txtLogin.Text + "', '" + hashedPass + "', '" + salt + "'," + isIT + "," + itID + ")", conn);
                        //Adapter-------------------------------- -
                        //setting the command to the adapter
                        da = new OleDbDataAdapter(myCommand);
                        //Execute the command to the database
                        da.SelectCommand.ExecuteNonQuery();

                        //Insert into the technitians table with the firstname lastname and whether they are an admin or not
                        myCommand = new OleDbCommand("Insert into Technitians (firstName, lastName, isAdmin) values ('" + txtFirstName.Text + "', '" + txtLastName.Text + "', " + isAdmin + ")", conn);
                        //Adapter-------------------------------- -
                        //setting the command to the adapter
                        da = new OleDbDataAdapter(myCommand);
                        //Execute the command to the database
                        da.SelectCommand.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();//Close Connection
                    }
                }
                else
                {
                    //Error
                    MessageBox.Show("Passwords do NOT match! Please try again.");
                    //Passwords do not match clear them out
                    txtPassword.Clear();
                    txtConfirm.Clear();
                }
                //Once done clear the form and go back to the login default form
                txtPassword.Clear();
                txtConfirm.Clear();
                txtLogin.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtConfirm.Visible = false;
                btnRegister.Visible = false;
                lblRegisterShow.Visible = true;
                btnLogin.Visible = true;
                chkIT.Visible = false;
                chkIT.Checked = false;
                lblFirstName.Visible = false;
                lblLastName.Visible = false;
                txtFirstName.Visible = false;
                txtLastName.Visible = false;
                chbAdmin.Visible = false;
                chbAdmin.Checked = false;


            }
        } //End btnRegister clicked event

        private void lblRegisterShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Change the form to register by chenging the visability of the following items
            btnLogin.Visible = false;
            lblRegisterShow.Visible = false;
            txtConfirm.Visible = true;
            btnRegister.Visible = true;
            chkIT.Visible = true;
        }//End lblRegisterShow link clicked event

        private void chkIT_CheckedChanged(object sender, EventArgs e)
        {
            //make the following visable on the form if this is checked
            lblFirstName.Visible = true;
            lblLastName.Visible = true;
            txtFirstName.Visible = true;
            txtLastName.Visible = true;
            chbAdmin.Visible = true;
        }//End chkIT checked event

    }
}
