using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using UserRegistrationAndLogin.Data;

namespace UserRegistrationAndLogin
{
    public partial class LoginForm : Form
    {
        string ConnectionString;
        SqlConnection sqlConn;
        DataAccess dataAccess;
        public LoginForm()
        {
            InitializeComponent();
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Mou\Desktop\OOP2\TestDb4.mdf';Integrated Security=True;Connect Timeout=30";
            dataAccess = new DataAccess(ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string sql = string.Format("select * from [Users] where [UserName]='{0}' and [Password]='{1}'",txtUserName.Text,txtPassword.Text);

            //SqlCommand sqlCommand = new SqlCommand(sql, sqlConn);
            //sqlCommand.Connection.Open();
            //DataTable dt = new DataTable();
            //dt.Load(sqlCommand.ExecuteReader());
            //sqlCommand.Connection.Close();

            string whereClause = string.Format("where [UserName]='{0}' and [Password]='{1}'", txtUserName.Text, txtPassword.Text);
            DataTable dt = new DataTable();
            dt = dataAccess.GetData<Entities.Users>(whereClause);
            var user = dataAccess.GetList<Entities.Users>(whereClause).FirstOrDefault();
            var newUser = new Entities.Users() { DOB=DateTime.Now.AddYears(-20),EmailAddress="asd@ss.cc",Password="1212",UpdatedDate=DateTime.Now,UserName="abc"};
            int count  = dataAccess.Insert<Entities.Users>(newUser, true);
            if (dt.Rows.Count > 0)
            {
                txtPassword.Text = "";
                MessageBox.Show("Login Success!");
                string email = dt.Rows[0].Field<string>("EmailAddress");
                string userName = dt.Rows[0].Field<string>("UserName");
                DateTime dob = dt.Rows[0].Field<DateTime>("DOB");
                UserInfo userInfo = new UserInfo(this,userName, email, dob);
                userInfo.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User Name or password!!");
            }

            /*
             if (users.Count > 0 && users!=null)
            {
                txtPassword.Text = "";
                MessageBox.Show("Login Success!");
                string email = users[0].EmailAddress;
                string userName = users[0].UserName;
                DateTime dob = users[0].DOB;
                UserInfo userInfo = new UserInfo(this,userName, email, dob);
                userInfo.Show();
                this.Hide();
            }
             */
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            UserRegistrationForm userRegistrationForm = new UserRegistrationForm(this);
            userRegistrationForm.Show();
        }
    }
}
