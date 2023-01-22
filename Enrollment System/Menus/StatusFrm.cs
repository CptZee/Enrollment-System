using System;
using System.Drawing;
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
            String status = lblStatus.Text.ToString();
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
                    btnPayment.Enabled = false;
                    break;
                case "Approved":
                    lblStatus.ForeColor = Color.Green;
                    btnPayment.Enabled = false;
                    break;
                case "Denied":
                    lblStatus.ForeColor = Color.Red;
                    btnPayment.Enabled = false;
                    break;
            }
            lblStatus.Text = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PaymentFrm(application).ShowDialog();
            this.Show();

        }
    }
}
