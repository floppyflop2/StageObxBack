using DBDomain;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InternshipBusinessLogic : BusinessLogic
    {

        private readonly StageObxContext db;

        public InternshipBusinessLogic(StageObxContext db)
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
                    compList = db.Internship.ToList();
                }
            }
            catch
            {

            }
            return compList;
        }

        public override object Get(int id)
        {
            Internship comp = new Internship();
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Internship.FirstOrDefault(c => c.InternshipId == id);
                    comp = result;
                }
            }
            catch
            { }
            return comp;

        }

        public override void Add(object obj)
        {
            try
            {
                using (var db = new StageObxContext())
                {
                    //TODO effectuer verif pour les doublons 
                    // var result = db.Internship.FirstOrDefault(c => c.S == obj.Name);
                    // if (!obj.Equals((Internship)result)) db.Internship.Add((Document)obj);
                    db.Internship.Add(obj);
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
                    var result = db.Internship.FirstOrDefault(c => c.InternshipId == obj.id);
                    if (result != null) db.Internship.Remove(obj);
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
                    var result = db.Internship.FirstOrDefault(c => c.InternshipId == obj.id);
                    if (result != null)
                    {
                        db.Internship.Remove(result);
                        db.Internship.Add((Internship)obj);
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
