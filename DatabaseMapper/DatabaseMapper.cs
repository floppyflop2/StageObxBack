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
        public static List<StudentDTO> MapToStudentDTO(List<Students> student)
        {
            List<StudentDTO> listOfStudents = new List<StudentDTO>();
            student.ForEach(w => listOfStudents.Add(new StudentDTO()
            {
                FirstName = w.StudentFirstName,
                Name = w.StudentName,
                Departement = w.StudentDepartement,
                Document = w.StudentDocument,
                Email = w.StudentEmail,
                Telephone = w.StudentTelephone
            }));
            return listOfStudents;
        }

        public static StudentDTO MapToStudentDTO(Students student)
        {
            return new StudentDTO()
            {
                FirstName = student.StudentFirstName,
                Name = student.StudentName,
                Departement = student.StudentDepartement,
                Document = student.StudentDocument,
                Email = student.StudentEmail,
                Telephone = student.StudentTelephone
            };
        }

        public static ContactDTO MapToContactDTO(Contacts contact)
        {
            return new ContactDTO(){
                
            };
        }

        public static CompanyDTO MapToCompanyDTO(Companies company)
        {
            return new CompanyDTO(){
                
            };
        }

        public static InternshipDTO MapToInternshipDTO(Internship internship)
        {
            return new InternshipDTO(){
                
            };
        }
    }
}
