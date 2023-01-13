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

        public void addAddress(Address address)
        {
            addresses.Add(address);
        }

        public Address retrieveRecent()
        {
            if (addresses.Count == 0)
                return null;
            return (Address) addresses[addresses.Count - 1];
        }

        public void removeRecent()
        {
            if (addresses.Count == 0)
                return;
            addresses.RemoveAt(addresses.Count - 1);
        }
    }
}
