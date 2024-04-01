using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace School_system
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtBoxUsername.Text;
            string password = txtBoxPassword.Text;
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
                                //MessageBox.Show("Login successful");
                                //redirect to dashboard
                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                                this.Hide();
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
    }
}
