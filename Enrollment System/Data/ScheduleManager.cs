using System.Collections;

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

        public void add(Schedule schedule)
        {
            schedules.Add(schedule);
        }

        public void update(Schedule x)
        {
            schedules[schedules.IndexOf(x)] = x;
        }

        public int retrieveRecentID()
        {
            if (schedules.Count == 0)
                return -1;
            Schedule x = (Schedule)schedules[schedules.Count - 1];
            return x.ID;
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
        public int findIndex(Schedule x)
        {
            return schedules.IndexOf(x);
        }
    }
}
