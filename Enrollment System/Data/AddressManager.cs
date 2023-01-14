using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class AddressManager
    {
        private AddressManager()
        {
            addresses = new ArrayList();
        }
        private static AddressManager instance = null;
        public ArrayList addresses { get; set; }

        public static AddressManager getInstance()
        {
            if (instance == null)
                instance = new AddressManager();
            return instance;
        }

        public void add(Address address)
        {
            addresses.Add(address);
        }

        public int retrieveRecentID()
        {
            if (addresses.Count == 0)
                return -1;
            Address x = (Address)addresses[addresses.Count - 1];
            return x.ID;
        }

        public void removeRecent()
        {
            if (addresses.Count == 0)
                return;
            addresses.RemoveAt(addresses.Count - 1);
        }
        public Address find(int Id)
        {
            for (int i = 0; i < addresses.Count; i++)
            {
                Address s = (Address)addresses[i];
                if (s.ID == Id)
                    return s;
            }
            return null;
        }
        public int findIndex(Address x)
        {
            return addresses.IndexOf(x);
        }
    }
}
