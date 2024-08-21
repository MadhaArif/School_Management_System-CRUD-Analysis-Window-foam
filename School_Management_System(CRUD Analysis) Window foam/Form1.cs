using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_Management_System_CRUD_Analysis__Window_foam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Using block ensures the SqlConnection is closed and disposed of correctly.
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Madha Arif\source\repos\School_Management_System(CRUD Analysis) Window foam\School_Management_System(CRUD Analysis) Window foam\Database1.mdf;Integrated Security=True"))
            {
                 con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO student (Name, Age) VALUES (@Name, @Age)", con))
                    {
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully saved");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Madha Arif\source\repos\School_Management_System(CRUD Analysis) Window foam\School_Management_System(CRUD Analysis) Window foam\Database1.mdf;Integrated Security=True"))
            {
                  con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE student SET Age = @Age WHERE Id = @Id", con))
                    {
                        // Assuming you have a textbox or other input control for Id
                        cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully updated");
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Madha Arif\source\repos\School_Management_System(CRUD Analysis) Window foam\School_Management_System(CRUD Analysis) Window foam\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM student WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully deleted");
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Madha Arif\source\repos\School_Management_System(CRUD Analysis) Window foam\School_Management_System(CRUD Analysis) Window foam\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM student where id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt; // Ensure the correct name of your DataGridView control
                }

            }
        }



    }
}
