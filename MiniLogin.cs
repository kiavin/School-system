using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace School_system
{
    public partial class MiniLogin : Form
    {
        public string Username { get; private set; }

        public MiniLogin()
        {
            InitializeComponent();
        }

        public object Public { get; private set; }


        private void confirm_Click(object sender, EventArgs e)
        {
        //confirm login details for the user
        Public: string username = txtBoxUname.Text;
            string password = txtBoxPassword.Text;


            //check from db if the user exists
            //fields validation
            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                try
                {
                    string connString = "server=localhost;user=root;password=kevoh;database=schoolapp;";
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        con.Open();
                        string query = "SELECT * FROM student_details WHERE username=@username AND password=@password";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                //MessageBox.Show("Access granted");
                                Username = username;
                                this.DialogResult = DialogResult.OK; // Set DialogResult
                                this.Close(); // Close the MiniLogin form

                                //redirect to update form
                                // UpdateForm updateForm = new UpdateForm();
                                //updateForm.ShowDialog();
                                //this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Login failed");

                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void MiniLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

