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
            return base.GetAll();
        }

        public override object Get(int id)
        {
            var result = db.Companies.FirstOrDefault(c => c.CompanyId == id);
            return result;

        }

        public override void Add(object obj)
        {

            Debug.WriteLine("");
        }

        public override void Remove(object obj)
        {
            base.Remove((CompanyDTO)obj);


        }

        public override void Modify(object obj)
        {
            base.Modify((CompanyDTO)obj);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
