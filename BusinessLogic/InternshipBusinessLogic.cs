using Models;
using StageobxDB;
using System;
using System.Collections.Generic;
using System.Linq;
using static DatabaseMapper.DatabaseMapper;


namespace BusinessLogic
{
    public class InternshipBusinessLogic : BusinessLogic
    {

        public override object GetAll()
        {
            List<Internship> internshipList = new List<Internship>();
            try
            {
                using (var db = new DBModel())
                {
                    internshipList = db.Internships.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToInternshipDTO(internshipList);
        }

        public override object Get(object obj)
        {
            Internship internship = new Internship();

            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }

            try
            {
                using (var db = new DBModel())
                {
                    var result = db.Internships.Where(c => c.InternshipId == id).FirstOrDefault();
                    internship = result;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return MapToInternshipDTO(internship); ;
        }

        public override int Check(object obj)
        {
            InternshipDTO internship = (InternshipDTO)obj;
            using (var db = new DBModel()){
                var result = db.Internships.FirstOrDefault(i => i.CompanyId == internship.CompanyId && i.StudentId == internship.StudentId);
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

        public override object Add(object obj)
        {
            InternshipDTO internship = (InternshipDTO)obj;
            try
            {
                using (var db = new DBModel())
                {
                    var result = db.Internships.FirstOrDefault(c => c.InternshipId == internship.Id);
                    if (!obj.Equals((Internship)result))
                        db.Internships.Add(new Internship()
                        {
                            
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
                using (var db = new DBModel())
                {
                    db.Internships.Remove(db.Internships.First(w => w.InternshipId == id));
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
            InternshipDTO std = (InternshipDTO)obj;
            try
            {
                using (var db = new DBModel())
                {
                    db.Internships.Remove(db.Internships.First(w => w.InternshipId == id));
                    db.Internships.Add(new Internship()
                    {
                      
                    });
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
