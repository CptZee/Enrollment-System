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
    public partial class StatusFrm : Form
    {
        public StatusFrm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            ApplicationForm application = applicationFormsManager.find(Convert.ToInt32(tbAppID.Text));
            MessageBox.Show("Application is now " + application.Status, "Application Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
