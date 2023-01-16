using System;
using System.Collections;
using Enrollment_System.Util;

namespace Enrollment_System.Data
{
    class GuardianManager
    {
        private GuardianManager()
        {
            guardians = new ArrayList();
        }
        private static GuardianManager instance = null;
        public ArrayList guardians { get; set; }

        public static GuardianManager getInstance()
        {
            if (instance == null)
                instance = new GuardianManager();
            return instance;
        }

        public void add(Guardian guardian)
        {
            guardians.Add(guardian);
        }

        public void update(Guardian x)
        {
            if (guardians.IndexOf(x) >= 0)
                guardians[guardians.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentGuardianID() == 1)
                return 0;
            return DatabaseHelper.getRecentGuardianID();
        }

        public void removeRecent()
        {
            if (guardians.Count == 0)
                return;
            guardians.RemoveAt(guardians.Count - 1);
        }

        public Guardian find(int Id)
        {
            for (int i = 0; i < guardians.Count; i++)
            {
                Guardian s = (Guardian)guardians[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public Guardian findByIndex(int index)
        {
            return (Guardian)guardians[index];
        }

        public Guardian findByName(string FirstName)
        {
            for (int i = 0; i < guardians.Count; i++)
            {
                Guardian s = (Guardian)guardians[i];
                if (s.FirstName.Equals(FirstName))
                    return s;
            }
            return null;
        }

        public int findIndex(Guardian x)
        {
            return guardians.IndexOf(x);
        }


        public void remove(int ID)
        {
            for (int i = 0; i < guardians.Count; i++)
            {
                Guardian s = (Guardian)guardians[i];
                if (s.ID == ID)
                    guardians.Remove(s);
            }
        }
        public void clear()
        {
            guardians.Clear();
        }
    }
}
