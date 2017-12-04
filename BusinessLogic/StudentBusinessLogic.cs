using StageobxDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                using (var db = new DBModel())
                {
                    compList = db.Student.ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "GetAllStudent impossible");
                throw new Exception(e.Message);
            }
            return MapToStudentDTO((List<Student>)compList);
        }

        public override object Get(object obj)
        {
            Student comp = new Student();
            int id = Check(obj);
            try
            {
                using (var db = new DBModel())
                {
                    var result = db.Student.Where(c => c.StudentId == id).FirstOrDefault();
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
                using (var db = new DBModel())
                {
                    var result = db.Student.Where(s => s.StudentEmail == stud.Email);
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

        public override object Add(object obj)
        {
            StudentDTO std = (StudentDTO)obj;
            try
            {
                using (var db = new DBModel())
                {
                    var result = db.Student.FirstOrDefault(c => c.StudentName == std.Name);
                    if (!obj.Equals((Students)result))
                        db.Students.Add(new Student()
                        {
                            StudentName = std.Name,
                            StudentFirstName = std.FirstName,
                            StudentDepartement = std.Departement,
                            StudentDocument = std.Document,
                            StudentEmail = std.Email,
                            StudentTelephone = std.Telephone,
                            StudentToken = std.Token
                        });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "AddStudent Error");
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
                using (var db = new DBModel())
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
                using (var db = new DBModel())
                {
                    db.Students.Remove(db.Students.First(w => w.StudentId == id));
                    db.Students.Add(new Students()
                    {
                        StudentName = std.Name,
                        StudentFirstName = std.FirstName,
                        StudentDepartement = std.Departement,
                        StudentDocument = std.Document,
                        StudentEmail = std.Email,
                        StudentTelephone = std.Telephone,
                        StudentToken = std.Token
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