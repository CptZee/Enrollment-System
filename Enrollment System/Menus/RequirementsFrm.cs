using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System.Menus
{
    public partial class RequirementsFrm : Form
    {
        public RequirementsFrm()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationConfrimationFrm frm = new ApplicationConfrimationFrm();
            frm.ShowDialog();
            this.Close();
        }
    }
}
