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
    public partial class ApplicationRequirementFrm : Form
    {
        private Requirement requirement;
        private ApplicationForm application;
        public ApplicationRequirementFrm(ApplicationForm application)
        {
            this.application = application;
            requirement = new Requirement();
            InitializeComponent();
        }


        //TODO: Add a function that inserts the requirement into the application
        private void btnProceed_Click(object sender, EventArgs e)
        {
            RequirementManager requirementManager = RequirementManager.getInstance();
            requirement.PicturePath = lblPicture.Text.ToString();
            requirement.GoodMoralPath = lblGoodMoral.Text.ToString();
            requirement.PSAPath = lblPSA.Text.ToString();
            requirement.RecommendationPath = lblRecomendation.Text.ToString();
            application.RequirementID = requirement.ID;
            requirementManager.add(requirement);
            this.Hide();
            SubjectsFrm frm = new SubjectsFrm(application);
            frm.ShowDialog();
            this.Close();
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Document(*.png; *.jpeg;)|*.png; *.jpeg;";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        lblPicture.Text = openFileDialog1.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload picture.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPSA_Click(object sender, EventArgs e)
        {
            setUpFileDocumentDialog();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        lblPSA.Text = openFileDialog1.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGoodMoral_Click(object sender, EventArgs e)
        {
            setUpFileDocumentDialog();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        lblGoodMoral.Text = openFileDialog1.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecommendation_Click(object sender, EventArgs e)
        {
            setUpFileDocumentDialog();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        lblRecomendation.Text = openFileDialog1.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setUpFileDocumentDialog()
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc;)|*.pdf; *.docx;";
            openFileDialog1.FilterIndex = 1;
        }

        private void ApplicationRequirementFrm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
