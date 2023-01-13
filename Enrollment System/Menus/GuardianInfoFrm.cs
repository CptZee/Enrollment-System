using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_System.Data;
using Enrollment_System.Enrollment;
using System.Windows.Forms;

namespace Enrollment_System.Menus
{
    public partial class GuardianInfoFrm : Form
    {
        private ApplicationForm application;
        public GuardianInfoFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void GuardianInfoFrm_Load(object sender, EventArgs e)
        {

        }

        private void lblPrivacy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.sti.edu/dataprivacy.asp");
        }
    }
}
