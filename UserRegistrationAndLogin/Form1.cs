using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UserRegistrationAndLogin
{
    public partial class Form1 : Form
    {
        string _connectionString;
        public Form1()
        {
            InitializeComponent();
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mou\Desktop\OOP2\TestDb3.mdf;Integrated Security=True;Connect Timeout=30";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("insert into Users " +
          "(UserName,Password,EmailAddress,UpdatedDate) " +
          "Values ('{0}','{1}','{2}','{3}')",
          txtUserName.Text, txtPassword.Text, txtEmailAddress.Text, System.DateTime.Now.ToString());
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            sqlCmd.Connection.Open();
            int rowsAffected = sqlCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Saved Successfully!!");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
            sqlCmd.Connection.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserGridData();

        }

        void LoadUserGridData()
        {
            string ConnectionString = _connectionString;
            string sql = "select UserName as 'User Name',  EmailAddress as 'Email Address' from Users";

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);

            DataTable dt = new DataTable();

            sqlCmd.Connection.Open();
            dt.Load(sqlCmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            sqlCmd.Connection.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
