using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace School_system
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            //show details of logged in user in the textboxes
            //txtBoxRegNo.Text = Global.regno;
            // txtBoxFname.Text = Global.fname;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MiniLogin miniLogin = new MiniLogin();
            DialogResult result = miniLogin.ShowDialog();
            if (result == DialogResult.OK)
            {
                //txtBoxRegNo.Text = miniLogin.RegNo;
                string Username = miniLogin.Username;
                //get details of the user from the db
                try
                {
                    string connString = "server=localhost;user=root;password=kevoh;database=schoolapp;";
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        con.Open();
                        string query = "SELECT * FROM student_details WHERE username=@Username";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", Username); // Add parameter for username
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate text boxes with fetched data
                                txtBoxFname.Text = reader["fname"].ToString();
                                txtBoxLname.Text = reader["lname"].ToString();
                                txtBoxClass.Text = reader["class"].ToString();
                                txtBoxGender.Text = reader["gender"].ToString();
                                txtBoxPass1.Text = reader["password"].ToString();
                                txtBoxUsername.Text = reader["username"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Username not found");
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Login failed");
            }

        }

        private void txtBoxPass1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            //save the updated details to the database
            string fname = txtBoxFname.Text;
            string lname = txtBoxLname.Text;
            string classes = txtBoxClass.Text;
            string gender = txtBoxGender.Text;
            string username = txtBoxUsername.Text;
            string password = txtBoxPass1.Text;
            string confirmpassword = txtBoxPass2.Text;

            //fields validation
            if (fname == "" || lname == "" || classes == ""
              || gender == "" || username == "" || password == "" ||
              confirmpassword == "")
            {
                //throw error
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                //check if password and confirm password match
                if (password != confirmpassword)
                {
                    MessageBox.Show("Passwords do not match");
                }
                else
                {
                    //send to data base
                    try
                    {
                        string connString = "server=localhost;user=root;password=kevoh;database=schoolapp;";
                        using (MySqlConnection con = new MySqlConnection(connString))
                        {
                            con.Open();
                            string query = "UPDATE student_details SET fname=@fname, lname=@lname, class=@class, gender=@gender, password=@password WHERE username=@Username";
                            MySqlCommand cmd = new MySqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@fname", fname);
                            cmd.Parameters.AddWithValue("@lname", lname);
                            cmd.Parameters.AddWithValue("@class", classes); // Changed from @classes to @class
                            cmd.Parameters.AddWithValue("@gender", gender);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password); // Hash the password before storing it
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Details updated successfully");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No records updated"); // Handle case where no records were updated
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }


                }

            }
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }
    }
}
