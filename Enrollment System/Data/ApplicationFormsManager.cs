﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class ApplicationFormsManager
    {
        private ApplicationFormsManager()
        {
            applicationForms = new ArrayList();
        }
        private static ApplicationFormsManager instance = null;
        public ArrayList applicationForms { get; set; }

        public static ApplicationFormsManager getInstance()
        {
            if (instance == null)
                instance = new ApplicationFormsManager();
            return instance;
        }

        public void addApplicationForm(ApplicationForm application)
        {
            applicationForms.Add(application);
        }

        public ApplicationForm retrieveRecent()
        {
            if (applicationForms.Count == 0)
                return null;
            return (ApplicationForm) applicationForms[applicationForms.Count - 1];
        }

        public void removeRecent()
        {
            if (applicationForms.Count == 0)
                return;
            applicationForms.RemoveAt(applicationForms.Count - 1);
        }
    }
}
}
