using DBDomain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMapper
{
    public static class DatabaseMapper
    {
        public static StudentDTO MapToStudentDTO(Students student)
        {
            return null;
        }

        public static ContactDTO MapToContactDTO(Contacts contact)
        {
            return new ContactDTO();
        }

        public static CompanyDTO MapToCompanyDTO(Companies company)
        {
            return new CompanyDTO();
        }

        public static InternshipDTO MapToInternshipDTO(Internship internship)
        {
            return new InternshipDTO();
        }
    }
}
