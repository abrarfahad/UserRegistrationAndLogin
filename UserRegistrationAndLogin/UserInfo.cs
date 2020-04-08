using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserRegistrationAndLogin
{
    public partial class UserInfo : Form
    {
        string email;
        string userName;
        DateTime dateOfBirth;
        Form previousForm;
        public UserInfo(Form _previousForm,string username,string email,DateTime dob )
        {
            InitializeComponent();
            userName = username;
            this.email = email;
            dateOfBirth = dob;
            previousForm = _previousForm;
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = userName + ", ";
            lblUserInfo.Text += email;
            lblUserInfo.Text += " and " + dateOfBirth.ToShortDateString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm;
            if (previousForm is LoginForm && previousForm!=null)
            {
                loginForm = (LoginForm)previousForm ;
            }
            else
            {
                loginForm = new LoginForm();
            }
            loginForm.Show();
            this.Close();
            this.Dispose();

        }
    }
}
