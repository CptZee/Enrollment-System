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
using Enrollment_System.Util;

namespace Enrollment_System.Menus
{
    public partial class PaymentFrm : Form
    {
        private ApplicationForm application;
        public PaymentFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void PaymentFrm_Load(object sender, EventArgs e)
        {

        }

        /**
         * A simple method that loads the computation values into
         * the form. E.g change the default values of the labels.
         * 
         */ 
        
        private void loadComputation()
        {

        }

        /**
         * A simple method that compute the tuition of the 
         * applicant and change the total value of the lblTotal
         * 
         */ 

        private void Compute()
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Successful! Payment methods and the such is WIP", "Payment Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            application.Status = "Paid";
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            applicationFormsManager.update(application);
            DatabaseHelper.updateApplicationForm(application);

            this.Hide();
            DashboardFrm frm = new DashboardFrm();
            frm.ShowDialog();
            this.Close();
        }
    }
}
