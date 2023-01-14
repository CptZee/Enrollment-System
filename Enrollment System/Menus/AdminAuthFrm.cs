using System;
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
                Console.WriteLine(username + ": " + password);
                Console.WriteLine(admin.username + ": " + admin.password);
                if (username.Equals(admin.username) && password.Equals(admin.password))
                {
                    this.Hide();
                    AdminFrm frm = new AdminFrm();
                    frm.ShowDialog();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Invalid Username or password!", "Invalid Credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
