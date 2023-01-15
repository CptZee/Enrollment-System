using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enrollment_System.Util;
using Enrollment_System.Data;

namespace Enrollment_System.Menus.Admin
{
    public partial class CourseModify : Form
    {
        private CourseManager manager;
        public CourseModify()
        {
            manager = CourseManager.getInstance();
            InitializeComponent();
        }

        private void CourseModify_Load(object sender, EventArgs e)
        {
            updateList();
            CenterToScreen();
        }

        private void updateList()
        {
            cbID.Items.Clear();
            for (int i = 0; i < manager.courses.Count; i++)
            {
                Course course = manager.findByIndex(i);
                cbID.Items.Add(course.ID);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course course = manager.find(Convert.ToInt32(cbID.Text.ToString()));
            tbName.Text = course.Name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Course course = manager.find(Convert.ToInt32(cbID.Text.ToString()));
            course.Name = tbName.Text.ToString();
            manager.update(course);
            DatabaseHelper.updateCourses(course);
            
            MessageBox.Show("Course " + course.ID + " successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateList();
        }
    }
}
