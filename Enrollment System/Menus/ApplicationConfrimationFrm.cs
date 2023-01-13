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
    public partial class ApplicationConfrimationFrm : Form
    {
        private ApplicationForm application;
        public ApplicationConfrimationFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void btnStartOver_Click(object sender, EventArgs e)
        {
            this.Hide();
            EnrollFrm frm = new EnrollFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
