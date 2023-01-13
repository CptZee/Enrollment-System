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
        private ArrayList guardians { get; set; }

        public static GuardianManager getInstance()
        {
            if (instance == null)
                instance = new GuardianManager();
            return instance;
        }

        public void addGuardian(Guardian guardian)
        {
            guardians.Add(guardian);
        }
    }
}
