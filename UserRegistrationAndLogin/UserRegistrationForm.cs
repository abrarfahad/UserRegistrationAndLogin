using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace UserRegistrationAndLogin
{
    public partial class UserRegistrationForm : Form
    {
        string ConnectionStr;
        Form _previousForm;
        SqlConnection sqlConnection;
        SqlCommand sqlCmd;
        public UserRegistrationForm(Form previousForm)
        {
            InitializeComponent();
            ConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Mou\Desktop\OOP2\TestDb4.mdf';Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(ConnectionStr);
            sqlCmd = new SqlCommand("", sqlConnection);
            _previousForm = previousForm;
            gvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvUsers.MultiSelect = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var id = txtId.Text;
            var sql = "INSERT INTO [Users]([UserName],[Password],[EmailAddress],[DOB]) VALUES(@UN,@P,@EA,@D)";
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@UN", txtUserName.Text);
            sqlCmd.Parameters.AddWithValue("@P", txtPassword.Text);
            sqlCmd.Parameters.AddWithValue("@EA", txtEmailAddress.Text);
            sqlCmd.Parameters.AddWithValue("@D", dtpDOB.Value);
            sqlConnection.Open();
            //sqlCmd.Connection.Open();
            int affectedRowCount= sqlCmd.ExecuteNonQuery();
            //sqlCmd.Connection.Close();
            sqlConnection.Close();

            if (affectedRowCount==1)
            {
                MessageBox.Show("Saved User");
                _previousForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Somethin went wrong");
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            DataTable tadatable = new DataTable();
            sqlCmd.CommandText = "Select * From Users";
            sqlCmd.Connection.Open();
            tadatable.Load(sqlCmd.ExecuteReader());
            
            gvUsers.DataSource = tadatable;
            sqlCmd.Connection.Close();
            
            
        }

        private void gvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = gvUsers.SelectedCells[0].RowIndex;
            var selectedRow = gvUsers.Rows[rowIndex];
            string id = selectedRow.Cells["Id"].Value.ToString();
            string userName = selectedRow.Cells["UserName"].Value.ToString();
            string password = selectedRow.Cells["Password"].Value.ToString();
            string email = selectedRow.Cells["EmailAddress"].Value.ToString();
            string dob = selectedRow.Cells["DOB"].Value.ToString();
            txtEmailAddress.Text = email;
            txtPassword.Text = password;
            txtUserName.Text = userName;
            dtpDOB.Value = Convert.ToDateTime(dob);
            txtId.Text = id;
            //MessageBox.Show(id);

        }
    }
}
