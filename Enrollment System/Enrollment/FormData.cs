using System;
using Enrollment_System.Data;

namespace Enrollment_System.Enrollment
{
    /**
     * All methods regarding the data from the enrollment forms
     * are handled here
     * 
     */

    class FormData
    {

        public static Address getAddress(String StreetUnitNumber, String Street, String SubdivisionVillageBldg, String Barangay, String City, String Province, String ZipCode)
        {
            Address address = new Address();
            
            address.StreetUnitNumber = StreetUnitNumber;
            address.Street = Street;
            address.SubdivisionVillageBldg = SubdivisionVillageBldg;
            address.Barangay = Barangay;
            address.City = City;
            address.Province = Province;
            address.ZipCode = ZipCode;

            return address;
        }

        public static Contact getContact(String TelephoneNo, String MobileNo, String Email)
        {
            Contact contact = new Contact();
            
            contact.TelephoneNo = TelephoneNo;
            contact.MobileNo = MobileNo;
            contact.Email = Email;

            return contact;
        }
        
        public static Guardian getGuardian(String FirstName, String LastName, String MiddleInitial, String SuffixName, String MobileNumber, String Email, String Occupation, String Relation)
        {
            Guardian guardian = new Guardian();
            
            guardian.FirstName = FirstName;
            guardian.LastName = LastName;
            guardian.MiddleInitial = MiddleInitial;
            guardian.SuffixName = SuffixName;
            guardian.MobileNumber = MobileNumber;
            guardian.Email = Email;
            guardian.Occupation = Occupation;
            guardian.Relation = Relation;

            return guardian;
        }

        public static SchoolHistory getSchoolHistory(String Type, String Name, String ProgramTrackSpecialization)
        {
            SchoolHistory schoolHistory = new SchoolHistory();
            
            schoolHistory.Type = Type;
            schoolHistory.Name = Name;
            schoolHistory.ProgramTrackSpecialization = ProgramTrackSpecialization;

            return schoolHistory;
        }

        public static Student getStudent(String FirstName, String MiddleName, String LastName, String SuffixName, String Gender, String Status, String Citizenship, DateTime BirthDate, String Birthplace, String Religion)
        {
            Student student = new Student();
            
            student.FirstName = FirstName;
            student.MiddleName = MiddleName;
            student.LastName = LastName;
            student.SuffixName = SuffixName;
            student.Gender = Gender;
            student.Status = Status;
            student.Citizenship = Citizenship;
            student.BirthDate = BirthDate;
            student.Birthplace = Birthplace;
            student.Religion = Religion;

            return student;
        }
    }
}
