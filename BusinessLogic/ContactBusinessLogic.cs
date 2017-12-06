using Models;
using StageobxDB;
using System;
using System.Collections.Generic;
using System.Linq;
using static DatabaseMapper.DatabaseMapper;

namespace BusinessLogic
{
    public class ContactBusinessLogic : BusinessLogic
    {


        public ContactBusinessLogic() { }

        public override object GetAll()
        {
            object compList = new List<object>();
            try
            {
                using (var db = new DBModel())
                {
                    compList = db.Contacts.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return MapToContactDTO((List<Contact>)compList);
        }

        public override object Get(object obj)
        {
            Contact comp = new Contact();
            int id = (int)obj;

            if(id == 0)
            {
                return GetAll();
            }

            try
            {
                using (var db = new DBModel())
                {
                    var result = db.Contacts.Where(c => c.CompanyId == id).FirstOrDefault();
                    comp = result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToContactDTO(comp);

        }

        public override int Check(object obj)
        {

            ContactDTO cont = (ContactDTO)obj;
            try
            {
                using (var db = new DBModel())
                {
                    var result = db.Contacts.Where(c => c.ContactEmail == cont.ContactEmail);
                    if (result == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return result.SingleOrDefault().ContactId;
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
            ContactDTO cont = (ContactDTO)obj;
            try
            {
                using (var db = new DBModel())
                {

                    var result = db.Contacts.FirstOrDefault(c => c.ContactName == cont.ContactName);
                    if (!obj.Equals((Contact)result))
                        db.Contacts.Add(new Contact()
                        {
                            ContactName = cont.ContactName,
                            ContactFirstName = cont.ContactFirstName,
                            ContactEmail = cont.ContactEmail,
                            ContactTelephone = cont.ContactTelephone
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
            {
                return;
            }
            try
            {
                using (var db = new DBModel())
                {

                    var result = db.Contacts.Remove(db.Contacts.FirstOrDefault(c => c.ContactId == id));
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
            {
                return;
            }
            ContactDTO cont = (ContactDTO)obj;
            try
            {
                using (var db = new DBModel())
                {
                    db.Contacts.Add(new Contact()
                    {
                        ContactName = cont.ContactName,
                        ContactFirstName = cont.ContactFirstName,
                        ContactEmail = cont.ContactEmail,
                        ContactTelephone = cont.ContactTelephone
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

