using System;
using System.Drawing;
using System.Windows.Forms;
using Enrollment_System.Data;

namespace Enrollment_System.Menus
{
    public partial class AdminAuthFrm : Form
    {
        public AdminAuthFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminManager adminManager = AdminManager.getInstance();
            String username = tbUsername.Text.ToString();
            String password = tbPassword.Text.ToString();
            for (int i = 0; i < adminManager.admins.Count; i++)
            {
                Data.Admin admin = adminManager.findByIndex(i);
                if (username.Equals(admin.Username) && password.Equals(admin.Password))
                {
                    this.Hide();
                    new AdminFrm().ShowDialog();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Invalid Username or password!", "Invalid Credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AdminAuthFrm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if(tbUsername.Text == "Username")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.Silver;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Text = "";
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.ForeColor = Color.Black;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "Password";
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.ForeColor = Color.Silver;
            }
        }
        
    }
}
