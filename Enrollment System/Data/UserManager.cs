using System.Collections;

namespace Enrollment_System.Data
{
    class UserManager
    {
        private UserManager()
        {
            Users = new ArrayList();
        }
        private static UserManager instance = null;
        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }
        private ArrayList Users; 

        public ArrayList getUsers()
        {
            return Users;
        }

        public void addUser(User user)
        {
            Users.Add(user);
        }
    }
}
