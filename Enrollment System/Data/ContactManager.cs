using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class ContactManager
    {
        private ContactManager()
        {
            contacts = new ArrayList();
        }
        private static ContactManager instance = null;
        public ArrayList contacts { get; set; }

        public static ContactManager getInstance()
        {
            if (instance == null)
                instance = new ContactManager();
            return instance;
        }

        public void add(Contact contact)
        {
            contacts.Add(contact);
        }

        public void update(Contact x)
        {
            contacts[contacts.IndexOf(x)] = x;
        }

        public int retrieveRecentID()
        {
            if (contacts.Count == 0)
                return -1;
            Contact x = (Contact)contacts[contacts.Count - 1];
            return x.ID;
        }

        public void removeRecent()
        {
            if (contacts.Count == 0)
                return;
            contacts.RemoveAt(contacts.Count - 1);
        }

        public Contact find(int Id)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                Contact s = (Contact)contacts[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }

        public Contact findByIndex(int index)
        {
            return (Contact)contacts[index];
        }

        public Contact findByEmail(string email)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                Contact s = (Contact)contacts[i];
                if (s.Email.Equals(email))
                    return s;
            }
            return null;
        }

        public int findIndex(Contact x)
        {
            return contacts.IndexOf(x);
        }

        public void clear()
        {
            contacts.Clear();
        }
    }
}
