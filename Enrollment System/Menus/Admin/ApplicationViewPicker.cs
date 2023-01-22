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

namespace Enrollment_System.Menus.Admin
{
    public partial class ApplicationViewPicker : Form
    {
        private ApplicationFormsManager manager;
        public ApplicationViewPicker()
        {
            manager = ApplicationFormsManager.getInstance();
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ApplicationFormsManager manager = ApplicationFormsManager.getInstance();
            ApplicationForm application = manager.find(Convert.ToInt32(cbID.Text.ToString()));

            this.Hide();
            new ApplicationViewer(application).ShowDialog();
            this.Close();
        }

        private void ApplicationViewPicker_Load(object sender, EventArgs e)
        {
            CenterToParent();
            updateList();
        }

        private void updateList()
        {
            cbID.Items.Clear();
            for (int i = 0; i < manager.applicationForms.Count; i++)
            {
                ApplicationForm subject = manager.findByIndex(i);
                cbID.Items.Add(subject.ID);
            }
        }
    }
}
