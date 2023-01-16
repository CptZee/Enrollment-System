using System;
using System.Collections;
using Enrollment_System.Util;

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
            if (requirements.IndexOf(x) >= 0)
                requirements[requirements.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentRequirementID() == 1)
                return 0;
            return DatabaseHelper.getRecentRequirementID();
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

        public void remove(int ID)
        {
            for (int i = 0; i < requirements.Count; i++)
            {
                Requirement s = (Requirement)requirements[i];
                if (s.ID == ID)
                    requirements.Remove(s);
            }
        }

        public void clear()
        {
            requirements.Clear();
        }
    }
}
