using System;
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
            CenterToParent();
            loadComputation();
        }
        
        private void loadComputation()
        {
            SubjectManager manager = SubjectManager.getInstance();
            int units = 0;
            int unitsCount = 0;
            int tuitionFee = 10000; //Default
            for (int i = 0; i < application.SubjectIDs.Count; i++)
            {
                Subject subject = manager.find((int)application.SubjectIDs[i]);
                units = units + subject.Units;
                unitsCount = unitsCount + 1;
            }
            int unitPrice = units * (750);
            int total = tuitionFee + unitPrice;

            int otherSchoolFees = 5000;
            int miscFees = 5000;
            int TotalFee = total + otherSchoolFees + miscFees;
            
            lblTuition.Text = "" + total;
            lblOther.Text = "" + otherSchoolFees;
            lblMisc.Text = "" + miscFees;
            lblTotal.Text = "" + TotalFee;
            
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please select a payment method!", "Missing field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Payment Successful! Payment methods and the such is WIP", "Payment Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            application.Status = "Paid";
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            applicationFormsManager.update(application);
            ApplicationHelper.updateApplicationForm(application);
            
            this.Close();
        }
    }
}
