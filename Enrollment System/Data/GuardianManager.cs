using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            guardians[guardians.IndexOf(x)] = x;
        }

        public int retrieveRecentID()
        {
            if (guardians.Count == 0)
                return -1;
            Guardian x = (Guardian)guardians[guardians.Count - 1];
            return x.ID;
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
        public int findIndex(Guardian x)
        {
            return guardians.IndexOf(x);
        }
    }
}
