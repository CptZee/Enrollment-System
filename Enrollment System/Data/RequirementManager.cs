using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_System.Data;

namespace Enrollment_System.Data
{
    class RequirementManager
    {
        private RequirementManager()
        {
            requirements = new ArrayList();
        }
        private static RequirementManager instance = null;
        public ArrayList requirements { get; set; }

        public static RequirementManager getInstance()
        {
            if (instance == null)
                instance = new RequirementManager();
            return instance;
        }

        public void add(Requirement x)
        {
            requirements.Add(x);
        }

        public void update(Requirement x)
        {
            requirements[requirements.IndexOf(x)] = x;
        }

        public int retrieveRecentID()
        {
            if (requirements.Count == 0)
                return -1;
            Requirement x = (Requirement)requirements[requirements.Count - 1];
            return x.ID;
        }

        public void removeRecent()
        {
            if (requirements.Count == 0)
                return;
            requirements.RemoveAt(requirements.Count - 1);
        }

        public Requirement find(int Id)
        {
            for (int i = 0; i < requirements.Count; i++)
            {
                Requirement s = (Requirement)requirements[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public Requirement findByIndex(int index)
        {
            return (Requirement)requirements[index];
        }

        public int findIndex(Requirement x)
        {
            return requirements.IndexOf(x);
        }

        public void clear()
        {
            requirements.Clear();
        }
    }
}
