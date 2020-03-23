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
        public UserInfo(string username,string email )
        {
                userName = username;
                this.email = email;

            InitializeComponent();
            

        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = userName + " and ";
            lblUserInfo.Text += email;
        }

        private void UserInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked on form");
        }

        private void UserInfo_ClientSizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Client Size Changed");
        }
    }
}
