using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Data
{
    class Address
    {
        public int ID { get; set; }
        public String StreetUnitNumber { get; set; }
        public String Street { get; set; }
        public String SubdivisionVillageBldg { get; set; }
        public String Barangay { get; set; }
        public String City { get; set; }
        public String Province { get; set; }
        public String ZipCode { get; set; }
    }
}
