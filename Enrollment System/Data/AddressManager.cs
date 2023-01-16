using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_System.Util;

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

        public void update(Address x)
        {
            if (addresses.IndexOf(x) >= 0)
                addresses[addresses.IndexOf(x)] = x;
        }

        public int getRecentID()
        {
            if (DatabaseHelper.getRecentAddressID() == 1)
                return 0;
            return DatabaseHelper.getRecentAddressID();
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

        public Address findByIndex(int index)
        {
            return (Address)addresses[index];
        }

        public int findIndex(Address x)
        {
            return addresses.IndexOf(x);
        }

        public void remove(int ID)
        {
            for (int i = 0; i < addresses.Count; i++)
            {
                Address s = (Address)addresses[i];
                if (s.ID == ID)
                    addresses.Remove(s);
            }
        }

        public void clear()
        {
            addresses.Clear();
        }
    }
}
