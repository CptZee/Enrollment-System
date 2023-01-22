using System;
using System.Windows.Forms;
using Enrollment_System.Menus;

namespace Enrollment_System
{
    public partial class DashboardFrm : Form
    {
        public DashboardFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new StatusCheckerFrm().ShowDialog();
            this.Show();

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminAuthFrm().ShowDialog();
            this.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ApplicationFrm().ShowDialog();
            this.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
