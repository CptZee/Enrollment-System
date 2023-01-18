using System;
using System.Collections;
using Enrollment_System.Util;

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

        public void add(ApplicationForm application)
        {
            applicationForms.Add(application);
        }

        public void update(ApplicationForm x)
        {
            if(applicationForms.IndexOf(x) >= 0)
                applicationForms[applicationForms.IndexOf(x)] = x;
        }

        public ApplicationForm getRecent()
        {
            if (applicationForms.Count == 0)
                return null;
            return (ApplicationForm) applicationForms[applicationForms.Count - 1];
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentApplicationID() == 1)
                return 0;
            return DatabaseHelper.getRecentApplicationID();
        }

        public void removeRecent()
        {
            if (applicationForms.Count == 0)
                return;
            applicationForms.RemoveAt(applicationForms.Count - 1);
        }
        public ApplicationForm find(int Id)
        {
            Console.WriteLine("Applications " + applicationForms.Count);
            for (int i = 0; i < applicationForms.Count; i++)
            {
                ApplicationForm s = (ApplicationForm)applicationForms[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public ApplicationForm findByIndex(int index)
        {
            return (ApplicationForm)applicationForms[index];
        }


        public int findIndex(ApplicationForm x)
        {
            return applicationForms.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < applicationForms.Count; i++)
            {
                ApplicationForm s = (ApplicationForm)applicationForms[i];
                if (s.ID == ID)
                    applicationForms.Remove(s);
            }
        }

        public void clear()
        {
            applicationForms.Clear();
        }
    }
}
