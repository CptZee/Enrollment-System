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

namespace Enrollment_System.Menus.Admin
{
    public partial class CourseAdd : Form
    {
        public CourseAdd()
        {
            InitializeComponent();
        }

        private void CourseAdd_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CourseManager courseManager = CourseManager.getInstance();
            Course course = new Course();
            course.name = tbCourseName.Text.ToString();
            DatabaseHelper.addCourse(course);
            courseManager.add(course);
            MessageBox.Show("Course " + course.name + " successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
