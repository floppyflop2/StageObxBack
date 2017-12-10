using Models;
using System.Collections.Generic;
using System;
using System.Linq;
using static DatabaseMapper.DatabaseMapper;
using ClassLibrary2;

namespace BusinessLogic
{
    public class CompanyBusinessLogic : BusinessLogic
    {

        // Gets all the companies
        public override object GetAll()
        {
            object compList = new List<object>();
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    compList = db.Companies.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToCompanyDTO((List<Company>)compList);
        }
        public override object Get(string userId)
        {

            int companyId = 0;
            List<Company> result = null;

            // GETS ALL THE COMPANIES IF ID == 0
            if (userId == "0")
            {
                return GetAll();
            }

            if (!Int32.TryParse(userId, out companyId))
            {
                try
                {
                    using (var db = new stageobxdatabaseEntities())
                    {
                        result = db.Companies.Where(c => c.Student.AspNetUserId == userId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    using (var db = new stageobxdatabaseEntities())
                    {
                        result = db.Companies.Where(c => c.CompanyId == companyId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return MapToCompanyDTO(result);
        }

        public override object Add(object obj, string userId)
        {
            CompanyDTO cpn = (CompanyDTO)obj;

            try
            {
                using (var db = new stageobxdatabaseEntities())
                {

                    db.Companies.Add(new Company()
                    {
                        CompanyName = cpn.Name,
                        CompanyCity = cpn.City,
                        CompanyStreetName = cpn.StreetName,
                        CompanyPostalCode = cpn.PostalCode,
                        CompanyTelephone = cpn.Telephone,
                        StudentId = db.Students.Where(w => w.AspNetUserId == userId).First().StudentId
                    });

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }
    }
}
