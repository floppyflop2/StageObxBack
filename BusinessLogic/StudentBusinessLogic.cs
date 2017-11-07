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
    public class StudentBusinessLogic : BusinessLogic
    {
        private readonly StageObxContext db;

        public StudentBusinessLogic(StageObxContext db)
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
                    compList = db.Students.ToList();
                }
            }
            catch
            {

            }
            return compList;
        }

        public override object Get(int id)
        {
            Students comp = new Students();
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Students.FirstOrDefault(c => c.StudentId == id);
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
                    var result = db.Students.FirstOrDefault(c => c.StudentName == obj.Name);
                    if (!obj.Equals((Students)result)) db.Students.Add((Students)obj);
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
                    var result = db.Students.FirstOrDefault(c => c.StudentId == obj.id);
                    if (result != null) db.Students.Remove(obj);
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
                    var result = db.Students.FirstOrDefault(c => c.StudentId == obj.id);
                    if (result != null)
                    {
                        db.Students.Remove(result);
                        db.Students.Add((Students)obj);
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
}

