using System.Collections;
using Enrollment_System.Util;
using System;

namespace Enrollment_System.Data
{
    class ScheduleManager
    {
        private ScheduleManager()
        {
            schedules = new ArrayList();
        }
        private static ScheduleManager instance = null;
        public ArrayList schedules { get; set; }

        public static ScheduleManager getInstance()
        {
            if (instance == null)
                instance = new ScheduleManager();
            return instance;
        }

        public void add(Schedule subject)
        {
            schedules.Add(subject);
        }

        public void update(Schedule x)
        {
            if (schedules.IndexOf(x) >= 0)
                schedules[schedules.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentScheduleID() == 1)
                return 0;
            return DatabaseHelper.getRecentScheduleID();
        }

        public void removeRecent()
        {
            if (schedules.Count == 0)
                return;
            schedules.RemoveAt(schedules.Count - 1);
        }

        public Schedule find(int Id)
        {
            for (int i = 0; i < schedules.Count; i++)
            {
                Schedule s = (Schedule)schedules[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public Schedule findByIndex(int index)
        {
            return (Schedule)schedules[index];
        }

        public Schedule findByTime(string Time)
        {
            for (int i = 0; i < schedules.Count; i++)
            {
                Schedule s = (Schedule)schedules[i];
                string schedule = s.StartTime + " - " + s.EndTime + ", " + s.Day;
                if (schedule.Equals(Time))
                    return s;
            }
            return null;
        }

        public int findIndex(Schedule x)
        {
            return schedules.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < schedules.Count; i++)
            {
                Schedule s = (Schedule)schedules[i];
                if (s.ID == ID)
                    schedules.Remove(s);
            }
        }

        public void clear()
        {
            schedules.Clear();
        }
    }
}
