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
    public partial class StatusCheckerFrm : Form
    {
        public StatusCheckerFrm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            ApplicationForm application = applicationFormsManager.find(Convert.ToInt32(tbAppID.Text));

            this.Hide();
            StatusFrm frm = new StatusFrm(application);
            frm.ShowDialog();
            this.Close();
        }

        private void StatusFrm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm frm = new DashboardFrm();
            frm.ShowDialog();
            this.Close();

        }
    }
}
