using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_system
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void Dashboard_Load(object sender, EventArgs e)
        {
            //show all data in database
            try
            {
                string connString = "server=localhost;user=root;password=kevoh;database=schoolapp;";
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    con.Open();
                    //string searchKeyword = name; // Assuming txtSearch is the text box where the user enters the search term
                    string query = "SELECT * FROM student_details ";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    // cmd.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%"); // Add '%' wildcard for partial matching

                    // Create a DataTable to store the search results
                    DataTable dt = new DataTable();

                    // Fill the DataTable with the search results using a DataAdapter
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    // Set the DataTable as the DataSource of the DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MiniLogin miniLogin = new MiniLogin();
            //miniLogin.ShowDialog();
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog();



        }

        private void btnMe_Click(object sender, EventArgs e)
        {
            // Assuming dataGridView1 is the DataGridView control
            // Check if any row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("you have selected a row");
                // Get the value of the identifier column (e.g., primary key value) from the selected row
                int selectedRecordId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["reg_no"].Value);

                // Prompt the user to confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Construct the DELETE query
                        string connString = "server=localhost;user=root;password=kevoh;database=schoolapp;";
                        using (MySqlConnection con = new MySqlConnection(connString))
                        {
                            con.Open();
                            string query = "DELETE FROM student_details WHERE reg_no = @reg_no";
                            MySqlCommand cmd = new MySqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@reg_no", selectedRecordId);

                            // Execute the DELETE query
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully");

                                // Refresh the DataGridView to reflect the changes
                                // Implement this method to reload data into the DataGridView
                                Dashboard_Load(sender, e);

                            }
                            else
                            {
                                MessageBox.Show("Failed to delete record");
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // add a new student to the database
            Register register = new Register();
            register.ShowDialog();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search for a student in the database
            string name = txtBoxName.Text;

            if (name == "")
            {
                MessageBox.Show("Please enter a name to search for");
            }
            else
            {
                //search for the student in the database
                try
                {
                    string connString = "server=localhost;user=root;password=kevoh;database=schoolapp;";
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        con.Open();
                        string searchKeyword = name; // Assuming txtSearch is the text box where the user enters the search term
                        string query = "SELECT * FROM student_details WHERE fname LIKE @searchKeyword OR lname LIKE @searchKeyword OR username LIKE @searchKeyword";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%"); // Add '%' wildcard for partial matching
                        //check if there are any results
                        if (cmd.ExecuteScalar() == null)
                        {
                            MessageBox.Show("No results found");
                        }
                        // Create a DataTable to store the search results
                        DataTable dt = new DataTable();

                        // Fill the DataTable with the search results using a DataAdapter
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        // Set the DataTable as the DataSource of the DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard_Load(sender, e);
        }
    }
}
