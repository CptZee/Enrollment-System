using System;
using System.Windows.Forms;
using Enrollment_System.Menus;

namespace Enrollment_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatusFrm frm = new StatusFrm();
            frm.ShowDialog();
            this.Close();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnrollFrm frm = new EnrollFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
