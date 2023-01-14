using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class AdminManager
    {
        private AdminManager()
        {
            admins = new ArrayList();
        }
        private static AdminManager instance = null;
        public ArrayList admins { get; set; }

        public static AdminManager getInstance()
        {
            if (instance == null)
                instance = new AdminManager();
            return instance;
        }

        public void add(Admin admin)
        {
            admins.Add(admin);
        }

        public int retrieveRecent()
        {
            if (admins.Count == 0)
                return -1;
            Admin x = (Admin)admins[admins.Count - 1];
            return x.ID;
        }

        public void removeRecent()
        {
            if (admins.Count == 0)
                return;
            admins.RemoveAt(admins.Count - 1);
        }
        public Admin find(int Id)
        {
            for (int i = 0; i < admins.Count; i++)
            {
                Admin s = (Admin)admins[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public int findIndex(Admin x)
        {
            return admins.IndexOf(x);
        }
    }
}
