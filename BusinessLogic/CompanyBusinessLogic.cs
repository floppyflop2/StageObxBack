using DBDomain;
using Models;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class CompanyBusinessLogic : BusinessLogic
    {


        private readonly StageObxContext db;

        public CompanyBusinessLogic(StageObxContext db)
        {
            this.db = db;
        }

        public override List<object> GetAll()
        {
            List<object> compList = new List<object>();
            try
            {
                using (var db = new StageObxContext())
                {
                    compList = db.Companies.ToList();
                }
            }
            catch
            {

            }
            return compList;
        }

        public override object Get(int id)
        {
            Companies comp = new Companies();
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Companies.FirstOrDefault(c => c.CompanyId == id);
                    comp = result;
                }
            }
            catch
            {            }
            return comp;

        }

        public int CompanyCheck(object obj)
        {
            var result = db.Companies.Where(c => c.companyName == obj.Name);
            if (result == null){
                return -1;
            }
            else{
                return result.CompanyId;
            }
        }

        public override void Add(object obj)
        {
            try
            {
                using (var db = new StageObxContext())
                {
                    //TODO effectuer verif pour les doublons 
                    var result = db.Companies.FirstOrDefault(c => c.companyName == obj.Name);
                    if (!obj.Equals((Companies)result)) db.Companies.Add((Companies)obj);
                    db.SaveChanges();

                    /*
                     * int companyMax = db.Companies.Max(c => c.CompanyId);
                     * Companies company = new Companies(){CompanyId = companyMax+1, companyName = obj.Name, city = obj.City, streetname = obj.Streetname, postalCode = obj.PostalCode, companyTelephone = obj.CompanyTelephone};
                     * db.Companies.Add(company);
                     * db.SaveChanges();
                     * 
                     * */
                }
            }
            catch
            { }
        }

        public override void Remove(object obj)
        {

            try
            {
                using (var db = new StageObxContext())
                {
                 //TODO il faut typer pour le remove 
                    var result = db.Companies.FirstOrDefault(c => c.CompanyId ==  obj.id);
                    if (result != null) db.Companies.Remove(obj);
                    db.SaveChanges();

                    /*
                     * var result = db.Companies.Where(c => c.companyName == obj.Name).FirstOrDefault();
                     * db.Companies.Remove(result);
                     * db.SaveChanges();
                     * 
                     * */
                }
            }
            catch
            { }


        }

        public override void Modify(object obj)
        {
            
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Companies.FirstOrDefault(c => c.CompanyId == obj.id);
                    if (result != null)
                    {
                        db.Companies.Remove(result);
                        db.Companies.Add((Companies)obj);
                        db.SaveChanges();
                    }

                    /*
                     * var result = db.Companies.Where(c => c.CompanyId == obj.id);
                     * db.Companies.Remove(result);
                     * db.Companies.Add((Companies)obj);
                     * db.SaveChanges();
                     * 
                     * */
                }
            }
            catch
            { }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
