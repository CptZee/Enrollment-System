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
        private ArrayList contacts { get; set; }

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
    }
}
