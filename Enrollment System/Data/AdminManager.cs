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

        public void addAdmin(Admin admin)
        {
            admins.Add(admin);
        }

        public Admin retrieveRecent()
        {
            if (admins.Count == 0)
                return null;
            return (Admin )admins[admins.Count - 1];
        }

        public void removeRecent()
        {
            if (admins.Count == 0)
                return;
            admins.RemoveAt(admins.Count - 1);
        }
    }
}
