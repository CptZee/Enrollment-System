using System.Collections;
using System;
using Enrollment_System.Util;

namespace Enrollment_System.Data
{
    class SubjectManager
    {
        private SubjectManager()
        {
            subjects = new ArrayList();
        }
        private static SubjectManager instance = null;
        public ArrayList subjects { get; set; }

        public static SubjectManager getInstance()
        {
            if (instance == null)
                instance = new SubjectManager();
            return instance;
        }

        public void add(Subject subject)
        {
            subjects.Add(subject);
        }

        public void update(Subject x)
        {
            if (subjects.IndexOf(x) >= 0)
                subjects[subjects.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentSubjectID() == 1)
                return 0;
            return DatabaseHelper.getRecentSubjectID();
        }

        public void removeRecent()
        {
            if (subjects.Count == 0)
                return;
            subjects.RemoveAt(subjects.Count - 1);
        }

        public Subject find(int Id)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                Subject s = (Subject)subjects[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public Subject findByIndex(int index)
        {
            return (Subject)subjects[index];
        }

        public Subject findByName(string Name)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                Subject s = (Subject)subjects[i];
                if (s.Name.Equals(Name))
                    return s;
            }
            return null;
        }

        public int findIndex(Subject x)
        {
            return subjects.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                Subject s = (Subject)subjects[i];
                if (s.ID == ID)
                    subjects.Remove(s);
            }
        }

        public void clear()
        {
            subjects.Clear();
        }
    }
}
