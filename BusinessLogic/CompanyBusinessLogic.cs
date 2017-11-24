using DBDomain;
using Models;
using System.Collections.Generic;
using System;
using System.Linq;
using static DatabaseMapper.DatabaseMapper;
using Util;

namespace BusinessLogic
{
    public class CompanyBusinessLogic : BusinessLogic
    {
        Logger logger = new Logger();

        public override object GetAll()
        {
            object compList = new List<object>();
            try
            {
                using (var db = new StageObxContext())
                {
                    compList = db.Companies.ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "GetAllCompany impossible");
                throw new Exception(e.Message);
            }
            return MapToCompanyDTO((List<Companies>)compList);
        }

        public override object Get(object obj)
        {
            Companies comp = new Companies();
            int id = Check(obj);
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Companies.Where(c => c.CompanyId == id).FirstOrDefault();
                    comp = result;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "GetCompany impossible");
                throw new Exception(e.Message);
            }
            return MapToCompanyDTO(comp);

        }

        public override int Check(object obj)
        {

            CompanyDTO comp = (CompanyDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Companies.Where(c => c.CompanyName == comp.Name);
                    if (result == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return result.SingleOrDefault().CompanyId;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public override object Add(object obj)
        {
            CompanyDTO cpn = (CompanyDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Companies.FirstOrDefault(c => c.CompanyName == cpn.Name);
                    if (!obj.Equals((Companies)result))
                        db.Companies.Add(new Companies()
                        {
                            CompanyName = cpn.Name,
                            CompanyCity = cpn.City,
                            CompanyStreetName = cpn.StreetName,
                            CompanyPostalCode = cpn.PostalCode,
                            CompanyTelephone = cpn.Telephone
                        });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "unable to add company");
                throw new Exception(e.Message);
            }
            return "";
        }

        public override void Remove(object obj)
        {
            int id = Check(obj);
            if (id == -1)
                return;
            try
            {
                using (var db = new StageObxContext())
                {
                    db.Companies.Remove(db.Companies.First(w => w.CompanyId == id));
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "unable to remove a company");
                throw new Exception(e.Message);
            }


        }

        public override void Modify(object obj)
        {
            int id = Check(obj);
            if (id == -1)
                return;
            CompanyDTO cpn = (CompanyDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    db.Companies.Remove(db.Companies.First(w => w.CompanyId == id));
                    db.Companies.Add(new Companies()
                    {
                        CompanyName = cpn.Name,
                        CompanyCity = cpn.City,
                        CompanyStreetName = cpn.StreetName,
                        CompanyPostalCode = cpn.PostalCode,
                        CompanyTelephone = cpn.Telephone

                    });
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "unable to modify company");
                throw new Exception(e.Message);
            }
        }
    }
}
