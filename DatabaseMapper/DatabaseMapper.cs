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

        public static List<StudentDTO> MapToStudentDTO(List<Students> student)
        {
            List<StudentDTO> listOfStudents = new List<StudentDTO>();
            student.ForEach(s => listOfStudents.Add(MapToStudentDTO(s)));
            return listOfStudents;
        }

        public static ContactDTO MapToContactDTO(Contacts contact)
        {
            return new ContactDTO()
            {
                ContactName = contact.ContactName,
                ContactFirstName = contact.ContactFirstName,
                ContactTelephone = contact.ContactTelephone,
                ContactEmail = contact.ContactEmail
            };
        }

        public static List<ContactDTO> MapToContactDTO(List<Contacts> contacts)
        {
            List<ContactDTO> contactsList = new List<ContactDTO>();
            contacts.ForEach(c => contactsList.Add(MapToContactDTO(c)));

            return contactsList;
        }


        public static CompanyDTO MapToCompanyDTO(Companies company)
        {
            return new CompanyDTO()
            {
                Name = company.CompanyName,
                City = company.CompanyCity,
                StreetName = company.CompanyStreetName,
                PostalCode = company.CompanyPostalCode,
                Telephone = company.CompanyTelephone
            };
        }


        public static List<CompanyDTO> MapToCompanyDTO(List<Companies> companies)
        {
            List<CompanyDTO> listOfCompanies = new List<CompanyDTO>();
            companies.ForEach(w => listOfCompanies.Add(MapToCompanyDTO(w)));
            return listOfCompanies;
        }

        public static InternshipDTO MapToInternshipDTO(Internship internship)
        {
            return new InternshipDTO()
            {

            };
        }

        public static List<CompanyDTO> MapToInternshipDTO(List<Internship> internships)
        {
            List<InternshipDTO> listOfInternships = new List<InternshipDTO>();
            internships.ForEach(w => listOfInternships.Add(MapToInternshipDTO(w)));
            return listOfInternships;
        }

    }



}

