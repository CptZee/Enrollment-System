using System;
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

        public void add(ApplicationForm application)
        {
            applicationForms.Add(application);
        }

        public void update(ApplicationForm x)
        {
            applicationForms[applicationForms.IndexOf(x)] = x;
        }

        public ApplicationForm getRecent()
        {
            if (applicationForms.Count == 0)
                return null;
            return (ApplicationForm) applicationForms[applicationForms.Count - 1];
        }

        public int retrieveRecentID()
        {
            if (applicationForms.Count == 0)
                return -1;
            ApplicationForm x = (ApplicationForm) applicationForms[applicationForms.Count - 1];
            return x.ID;
        }

        public void removeRecent()
        {
            if (applicationForms.Count == 0)
                return;
            applicationForms.RemoveAt(applicationForms.Count - 1);
        }
        public ApplicationForm find(int Id)
        {
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
