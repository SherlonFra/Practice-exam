using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Practice_exam
{
    /// <summary>
    /// Interaction logic for New_Student.xaml
    /// </summary>
    public partial class New_Student : Window
    {
        public New_Student()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            /*SqlConnection con = new SqlConnection("Data Source= DESKTOP-NVG7K5K\\SQLEXPRESS;Initial Catalog=To Do List;Integrated Security=True;Pooling=False");
            con.Open();*/

            string connectionStr = "Server=IBTCOLLEGE.mssql.somee.com; Database=IBTCollege; User Id=ibtcollege_SQLLogin_1; Password=dd69kxzi3m";

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO [Students](FirstName,LastName,EmailAddress) VALUES (@FirstName,@LastName,@EmailAddress)", conn);
                

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM [Students]", conn);
                List<Student> results = new List<Student>();

                // use datareader
                // while datareader.Read()
                // results.add( ) 

                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    Student info = new Student();
                    info.FirstName = reader["FirstName"].ToString();
                    info.LastName = reader["lastName"].ToString();
                    info.EmailAddress = reader["EmailAddress"].ToString();
                    results.Add(info);
                }
                reader.Close();

                dataGridView1.ItemsSource = results;
                conn.Close();

               
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmailAddress.Text = "";

            }
        }
    }
}
