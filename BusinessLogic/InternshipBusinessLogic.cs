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

        public override object GetAll()
        {
            object compList = new List<object>();
            try
            {
                using (var db = new StageObxContext())
                {
                    compList = db.Internship.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
                    var result = db.Internship.Where(c => c.InternshipId == id).FirstOrDefault();
                    comp = result;
                }
            }
            catch
            { }
            return comp;

        }

        public override int Check(object obj)
        {
            var result = db.Internship.Where(i => i.CompanyId == obj.CompanyId && i.StudentId == obj.StudentId);
            if (result == null)
            {
                return -1;
            }
            else
            {
                return result.InternshipId;
            }
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

                    /*
                     * int internshipMax = db.Internship.Max(c => c.InternshipId);
                     * Internship internship = new Internship(){InternshipId = internshipMax+1, CompanyId = obj.CompanyId, StudentId = obj.StudentId, InternshipYear = obj.InternshipYear};
                     * db.Internship.Add(internship);
                     * db.SaveChanges();
                     * 
                     * */
                }
            }
            catch
            { }
        }

        public override void Remove(int id)
        {

            try
            {
                using (var db = new StageObxContext())
                {
                    //TODO il faut typer pour le remove 
                    var result = db.Internship.FirstOrDefault(c => c.InternshipId == id);
                    if (result != null) db.Internship.Remove(obj);
                    db.SaveChanges();

                    /*
                     * var result = db.Internship.Where(i => i.InternshipId == id);
                     * db.Internship.Remove(result);
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
                    var result = db.Internship.FirstOrDefault(c => c.InternshipId == obj.id);
                    if (result != null)
                    {
                        db.Internship.Remove(result);
                        db.Internship.Add((Internship)obj);
                        db.SaveChanges();
                    }

                    /*
                     * var result = db.Internship.Where(i => i.InternshipId == obj.InternshipId);
                     * db.Companies.Remove(result);
                     * db.Companies.Add((Internship)obj);
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
