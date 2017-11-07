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
