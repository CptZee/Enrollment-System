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
            StatusCheckerFrm frm = new StatusCheckerFrm();
            frm.ShowDialog();
            this.Close();

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminAuthFrm frm = new AdminAuthFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationFrm frm = new ApplicationFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
