using Models;
using System.Collections.Generic;
using ClassLibrary2;

namespace DatabaseMapper
{
    public static class DatabaseMapper
    {


        public static StudentDTO MapToStudentDTO(Student student)
        {
            return new StudentDTO()
            {
                Id = student.StudentId,
                FirstName = student.StudentFirstname,
                Name = student.StudentName,
                Departement = student.StudentDepartement,
                Document = student.StudentDocument,
                Email = student.StudentEmail
            };
        }

        public static List<StudentDTO> MapToStudentDTO(List<Student> student)
        {
            List<StudentDTO> listOfStudent = new List<StudentDTO>();
            student.ForEach(s => listOfStudent.Add(MapToStudentDTO(s)));
            return listOfStudent;
        }

        public static CompanyDTO MapToCompanyDTO(Company company)
        {
            return new CompanyDTO()
            {
                Id = company.CompanyId.ToString(),
                Name = company.CompanyName,
                City = company.CompanyCity,
                StreetName = company.CompanyStreetName,
                PostalCode = company.CompanyPostalCode,
                Telephone = company.CompanyTelephone
            };
        }


        public static List<CompanyDTO> MapToCompanyDTO(List<Company> companies)
        {
            List<CompanyDTO> listOfCompanies = new List<CompanyDTO>();
            companies.ForEach(w => listOfCompanies.Add(MapToCompanyDTO(w)));
            return listOfCompanies;
        }
    }



}

