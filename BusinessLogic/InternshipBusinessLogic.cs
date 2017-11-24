using DBDomain;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BusinessLogic
{
    public class InternshipBusinessLogic : BusinessLogic
    {
        Logger logger = new Logger();
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
            {
                logger.Error(e.Message + "GetInternShip Error");
                throw new Exception(e.Message);
            }
            return comp;

        }

        public override int Check(object obj)
        {
            InternshipDTO internship = (InternshipDTO)obj;
            var result = new Internship();
            using (var db = new StageObxContext()){

                result = db.Internship.Where(i => i.CompanyId == internship.CompanyId && i.StudentId == internship.StudentId);
                if (result == null)
                {
                    return -1;
                }
                else
                {
                    return result.InternshipId;
                }
            }
        }

        public override void Add(object obj)
        {
            InternshipDTO internship = (InternshipDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Internship.FirstOrDefault(c => c.InternshipId == internship.Id);
                    if (!obj.Equals((Internship)result))
                        db.Internship.Add(new Internship()
                        {
                            
                        });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "AddInternship Error");
                throw new Exception(e.Message);
            }
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
                    db.Internship.Remove(db.Internship.First(w => w.InternshipId == id));
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "RemoveInternship Error");
                throw new Exception(e.Message);
            }


        }

        public override void Modify(object obj)
        {

            int id = Check(obj);
            if (id == -1)
                return;
            InternshipDTO std = (InternshipDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    db.Internship.Remove(db.Internship.First(w => w.InternshipId == id));
                    db.Internship.Add(new Internship()
                    {
                      
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "ModifyInternship Error");
                throw new Exception(e.Message);
            }
        }
    }
}
