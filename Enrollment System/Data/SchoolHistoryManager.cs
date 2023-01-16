using System;
using System.Collections;
using Enrollment_System.Util;

namespace Enrollment_System.Data
{
    class SchoolHistoryManager
    {
        private SchoolHistoryManager()
        {
            schoolHistories = new ArrayList();
        }
        private static SchoolHistoryManager instance = null;
        public ArrayList schoolHistories { get; set; }

        public static SchoolHistoryManager getInstance()
        {
            if (instance == null)
                instance = new SchoolHistoryManager();
            return instance;
        }

        public void add(SchoolHistory schoolHistoy)
        {
            schoolHistories.Add(schoolHistoy);
        }

        public void update(SchoolHistory x)
        {
            if (schoolHistories.IndexOf(x) >= 0)
                schoolHistories[schoolHistories.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentSchoolHistoryID() == 1)
                return 0;
            return DatabaseHelper.getRecentSchoolHistoryID();
        }

        public void removeRecent()
        {
            if (schoolHistories.Count == 0)
                return;
            schoolHistories.RemoveAt(schoolHistories.Count - 1);
        }
        public SchoolHistory find(int Id)
        {
            for (int i = 0; i < schoolHistories.Count; i++)
            {
                SchoolHistory s = (SchoolHistory)schoolHistories[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public SchoolHistory findByIndex(int index)
        {
            return (SchoolHistory)schoolHistories[index];
        }

        public SchoolHistory findByName(string Name)
        {
            for (int i = 0; i < schoolHistories.Count; i++)
            {
                SchoolHistory s = (SchoolHistory)schoolHistories[i];
                if (s.Name.Equals(Name))
                    return s;
            }
            return null;
        }

        public int findIndex(SchoolHistory x)
        {
            return schoolHistories.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < schoolHistories.Count; i++)
            {
                SchoolHistory s = (SchoolHistory)schoolHistories[i];
                if (s.ID == ID)
                    schoolHistories.Remove(s);
            }
        }

        public void clear()
        {
            schoolHistories.Clear();
        }
    }
}
