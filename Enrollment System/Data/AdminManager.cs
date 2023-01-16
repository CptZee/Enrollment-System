using System;
using System.Collections;
using Enrollment_System.Util;

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

        public void update(Admin x)
        {
            if (admins.IndexOf(x) >= 0)
                admins[admins.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentAdminID() == 1)
                return 0;
            return DatabaseHelper.getRecentAdminID();
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

        public Admin findByIndex(int index)
        {
            return (Admin) admins[index];
        }

        public int findIndex(Admin x)
        {
            return admins.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < admins.Count; i++)
            {
                Admin s = (Admin)admins[i];
                if (s.ID == ID)
                    admins.Remove(s);
            }
        }

        public void clear()
        {
            admins.Clear();
        }
    }
}
