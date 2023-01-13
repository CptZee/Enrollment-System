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

        public void addContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public int retrieveRecentID()
        {
            if (contacts.Count == 0)
                return -1;
            Contact x = (Contact)contacts[contacts.Count - 1];
            return x.Id;
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
                if (s.Id == Id)
                    return s;
            }
            return null;
        }
    }
}
