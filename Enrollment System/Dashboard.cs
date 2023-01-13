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

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnrollFrm frm = new EnrollFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
