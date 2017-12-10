using ClassLibrary2;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static DatabaseMapper.DatabaseMapper;

namespace BusinessLogic
{
    public class StudentBusinessLogic : BaseBusinessLogic
    {
        private object GetAll()
        {
            List<Student> result = null;
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    result = db.Students.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToStudentDTO(result);
        }

        public override object Get(string userId)
        {

            int studentId = 0;
            List<Student> result = null;

            // GETS ALL THE STUDENTS IF ID == 0
            if (userId == "0")
            {
                return GetAll();
            }

            if (!Int32.TryParse(userId, out studentId))
            {
                try
                {
                    using (var db = new stageobxdatabaseEntities())
                    {
                        result = db.Students.Where(c => c.AspNetUserId == userId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    using (var db = new stageobxdatabaseEntities())
                    {
                        result = db.Students.Where(c => c.StudentId == studentId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return MapToStudentDTO(result);
        }

        public override object Add(object obj, string userId)
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
                            StudentEmail = std.Email,
                            AspNetUserId = userId
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
            StudentDTO student = (StudentDTO)obj;
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    db.Students.Remove(db.Students.First(stud => stud.StudentId == student.Id));
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