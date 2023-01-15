using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enrollment_System.Data;

namespace Enrollment_System.Menus
{
    public partial class RequirementsFrm : Form
    {
        private Requirement requirement;
        public RequirementsFrm()
        {
            requirement = new Requirement();
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            RequirementManager requirementManager = RequirementManager.getInstance();
            requirement.PicturePath = lblPicture.Text.ToString();
            requirement.GoodMoralPath = lblGoodMoral.Text.ToString();
            requirement.PSAPath = lblPSA.Text.ToString();
            requirement.RecommendationPath = lblRecomendation.Text.ToString();
            requirementManager.add(requirement);
            this.Hide();
            ApplicationConfrimationFrm frm = new ApplicationConfrimationFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            lblPicture.Text = Path.GetFullPath(openFileDialog1.FileName);
        }

        private void btnPSA_Click(object sender, EventArgs e)
        {
            lblPSA.Text = Path.GetFullPath(openFileDialog1.FileName);

        }

        private void btnGoodMoral_Click(object sender, EventArgs e)
        {
            lblGoodMoral.Text = Path.GetFullPath(openFileDialog1.FileName);

        }

        private void btnRecommendation_Click(object sender, EventArgs e)
        {
            lblRecomendation.Text = Path.GetFullPath(openFileDialog1.FileName);
        }
    }
}
