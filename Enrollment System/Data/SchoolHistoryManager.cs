﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void addSchoolHistory(SchoolHistory schoolHistoy)
        {
            schoolHistories.Add(schoolHistoy);
        }

        public int retrieveRecentID()
        {
            if (schoolHistories.Count == 0)
                return -1;
            SchoolHistory student = (SchoolHistory) schoolHistories[schoolHistories.Count - 1];
            return student.Id;
        }

        public void removeRecent()
        {
            if (schoolHistories.Count == 0)
                return;
            schoolHistories.RemoveAt(schoolHistories.Count - 1);
        }
    }
}
