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
        private ApplicationForm application;
        public StatusFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void ApplicationStatus_Load(object sender, EventArgs e)
        {
            updateStatus();
            CenterToScreen();
        }

        private void updateStatus()
        {
            String status = application.Status;
            switch (status)
            {
                case "Pending":
                    lblStatus.ForeColor = Color.Red;
                    break;
                case "Paid":
                    lblStatus.ForeColor = Color.Yellow;
                    break;
                case "Approved":
                    lblStatus.ForeColor = Color.Green;
                    break;
            }
            lblStatus.Text = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm frm = new DashboardFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentFrm frm = new PaymentFrm(application);
            frm.ShowDialog();
            this.Close();

        }
    }
}
