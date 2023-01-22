using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private static ApplicationForm application;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            if (String.IsNullOrEmpty(tbAppID.Text.ToString()))
            {
                MessageBox.Show("Specify an application ID to check!", "Missing Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            application = applicationFormsManager.find(Convert.ToInt32(tbAppID.Text));

            if(application == null)
            {
                MessageBox.Show("Application ID not found! Please check your application ID!", "Application ID not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Hide();
            new StatusFrm(application).ShowDialog();
            this.Close();

        }

        private void StatusFrm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbAppID_TextChanged(object sender, EventArgs e)
        {
            if (tbAppID.Text.Length > 7)
            {
                tbAppID.Text = tbAppID.Text.Remove(tbAppID.Text.Length - 1);
            }
        }
    }
}
