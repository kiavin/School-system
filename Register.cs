using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
namespace School_system
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string regno = txtBoxRegNo.Text;
            string fname = txtBoxFname.Text;
            string lname = txtBoxLname.Text;
            string date = txtBoxDate.Text;
            string classes = txtBoxClass.Text;
            string gender = txtBoxGender.Text;
            string username = txtBoxUsername.Text;
            string password = txtBoxPassword.Text;
            string confirmpassword = txtBoxConfirm.Text;

            if (regno == "" || fname == "" || lname == "" || date == ""
                || classes == ""
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
                            string query = "INSERT INTO student_details(reg_no, fname, lname, class, gender, dateofbirth, username, password) VALUES(@regno, @fname, @lname, @classes, @gender, @date, @username, @password)";
                            MySqlCommand cmd = new MySqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@regno", regno);
                            cmd.Parameters.AddWithValue("@fname", fname);
                            cmd.Parameters.AddWithValue("@lname", lname);
                            cmd.Parameters.AddWithValue("@classes", classes);
                            cmd.Parameters.AddWithValue("@gender", gender);
                            cmd.Parameters.AddWithValue("@date", date); // Ensure the date format is correct
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password); // Hash the password before storing it
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("User registered successfully");
                                // Redirect to login page
                                LOGIN lOGIN = new LOGIN();
                                lOGIN.Show();
                                this.Hide();

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

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
