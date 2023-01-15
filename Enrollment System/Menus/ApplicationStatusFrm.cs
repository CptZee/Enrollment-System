using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enrollment_System.Data;

namespace Enrollment_System.Menus
{
    public partial class ApplicationStatusFrm : Form
    {
        private ApplicationForm application;
        public ApplicationStatusFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void ApplicationStatus_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard frm = new Dashboard();
            frm.ShowDialog();
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

        }
    }
}
