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

        public int StudentCheck(object obj){
            var result = db.Students.Where(s => s.Studentemail == obj.Studentemail);
            if (result == null){
                return -1;
            }
            else{
                return result.StudentId;
            }
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

                    /*
                     * int studentMax = db.Students.Max(s => s.StudentId);
                     * Students student = new Students(){StudentId = studentMax+1, StudentName = obj.Name, Studentsurname = obj.Surname, departement = obj.Department, Studenttelephone = obj.Telephone, Studentemail = obj = Email};
                     * db.Students.Add(student);
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
                    var result = db.Students.FirstOrDefault(c => c.StudentId == obj.id);
                    if (result != null) db.Students.Remove(obj);
                    db.SaveChanges();

                    /*
                     * var result = db.Students.Where(s => s.StudentId == obj.StudentId);
                     * db.Students.Remove(result);
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
                    var result = db.Students.FirstOrDefault(c => c.StudentId == obj.id);
                    if (result != null)
                    {
                        db.Students.Remove(result);
                        db.Students.Add((Students)obj);
                        db.SaveChanges();
                    }

                    /*
                     * var result = db.Students.Where(s => s.StudentId == obj.StudentId);
                     * db.Companies.Remove(result);
                     * db.Companies.Add((Students)obj);
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


