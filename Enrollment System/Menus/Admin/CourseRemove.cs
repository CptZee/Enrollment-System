﻿using System;
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
    public partial class CourseRemove : Form
    {
        public CourseRemove()
        {
            InitializeComponent();
        }

        private void CourseRemove_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text.ToString()))
            {
                MessageBox.Show("ID is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ID = 0;
            try
            {
                ID = Convert.ToInt32(tbID.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("ID must be in whole numbers form!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CourseManager manager = CourseManager.getInstance();
            Course course = manager.find(ID);
            if (course == null)
            {
                MessageBox.Show("Course does not exist! Check the ID of the course that you are trying to remove!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DatabaseHelper.removeCourse(course);

            manager.remove(ID);
        }
    }
}
