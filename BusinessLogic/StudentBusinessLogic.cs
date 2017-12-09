using ClassLibrary2;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static DatabaseMapper.DatabaseMapper;

namespace BusinessLogic
{
    public class StudentBusinessLogic : BusinessLogic
    {
        public override object GetAll()
        {
            object compList = new List<object>();
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    compList = db.Students.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToStudentDTO((List<Student>)compList);
        }

        public override object Get(object obj)
        {
            Student comp = new Student();

            string idAsp = (string) obj;
            int id = 0;
            using (var db = new stageobxdatabaseEntities())
            {
                var result = db.Students.Where(c => c.AspNetUserId == idAsp).FirstOrDefault();
                id = result.StudentId;
            }

            // GETS ALL THE STUDENTS IF ID == 0
            if (id == 0)
            {
                return GetAll();
            }

            // GET THE STUDENT WITH THIS ID
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    var result = db.Students.Where(c => c.StudentId == id).FirstOrDefault();
                    comp = result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return MapToStudentDTO(comp);
        }

        public override int Check(object obj)
        {

            StudentDTO stud = (StudentDTO)obj;
            try
            {
                using (var db = new stageobxdatabaseEntities())
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
                throw new Exception(e.Message);
            }
        }

        public override object Add(object obj)
        {
            StudentDTO std = (StudentDTO)obj;
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    var result = db.Students.FirstOrDefault(c => c.StudentEmail == std.Email);
                    if (!obj.Equals(result))
                        db.Students.Add(new Student()
                        {
                            StudentName = std.Name,
                            StudentFirstname = std.FirstName,
                            StudentDepartement = std.Departement,
                            StudentDocument = std.Document,
                            StudentEmail = std.Email
                        });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
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
                using (var db = new stageobxdatabaseEntities())
                {
                    db.Students.Remove(db.Students.First(w => w.StudentId == id));
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
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
                using (var db = new stageobxdatabaseEntities())
                {
                    Student student = db.Students.Remove(db.Students.First(w => w.StudentId == id));
                    db.SaveChanges();

                    if (std.FirstName != null)
                        student.StudentFirstname = std.FirstName;
                    if (std.Name != null)
                        student.StudentName = std.Name;
                    if (std.Departement != null)
                        student.StudentDepartement = std.Departement;
                    if (std.Document != null)
                        student.StudentDocument = std.Document;

                    db.Students.Add(student);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}