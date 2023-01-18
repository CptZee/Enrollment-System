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
    public partial class SubjectsFrm : Form
    {
        private ApplicationForm application;
        public SubjectsFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void SubjectsFrm_Load(object sender, EventArgs e)
        {
            //TODO: Change into a dataviewmodel
            CenterToScreen();
        }
    }
}
