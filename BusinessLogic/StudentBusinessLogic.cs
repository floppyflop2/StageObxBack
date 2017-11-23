using DBDomain;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using static DatabaseMapper.DatabaseMapper;

namespace BusinessLogic
{
    public class StudentBusinessLogic : BusinessLogic
    {
        Logger logger = new Logger();
        public override object GetAll()
        {
            object compList = new List<object>();
            try
            {
                using (var db = new StageObxContext())
                {
                    compList = db.Students.ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "GetAllStudent impossible");
                throw new Exception(e.Message);
            }
            return MapToStudentDTO((List<Students>)compList);
        }

        public override object Get(object obj)
        {
            Students comp = new Students();
            int id = Check(obj);
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Students.Where(c => c.StudentId == id).FirstOrDefault();
                    comp = result;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "GetStudent impossible");
                throw new Exception(e.Message);
            }

            return MapToStudentDTO(comp);

        }

        public override int Check(object obj)
        {

            StudentDTO stud = (StudentDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Students.Where(s => s.StudentEmail == stud.Email);
                    if (result == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return result.SingleOrDefault().StudentId;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "Check Error");
                throw new Exception(e.Message);
            }
        }

        public override void Add(object obj)
        {
            StudentDTO std = (StudentDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Students.FirstOrDefault(c => c.StudentName == std.Name);
                    if (!obj.Equals((Students)result))
                        db.Students.Add(new Students()
                        {
                            StudentName = std.Name,
                            StudentFirstName = std.FirstName,
                            StudentDepartement = std.Departement,
                            StudentDocument = std.Document,
                            StudentEmail = std.Email,
                            StudentTelephone = std.Telephone
                        });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "AddStudent Error");
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
                    db.Students.Remove(db.Students.First(w => w.StudentId == id));
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "RemoveStudent Error");
                throw new Exception(e.Message);
            }


        }

        public override void Modify(object obj)
        {

            int id = Check(obj);
            if (id == -1)
                return;
            StudentDTO std = (StudentDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    db.Students.Remove(db.Students.First(w => w.StudentId == id));
                    db.Students.Add(new Students()
                    {
                        StudentName = std.Name,
                        StudentFirstName = std.FirstName,
                        StudentDepartement = std.Departement,
                        StudentDocument = std.Document,
                        StudentEmail = std.Email,
                        StudentTelephone = std.Telephone
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "ModifyStudent Error");
                throw new Exception(e.Message);
            }
        }
    }
}


