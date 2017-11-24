using DBDomain;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using DatabaseMapper;

namespace BusinessLogic
{
    public class ContactBusinessLogic : BusinessLogic
    {

        Logger logger = new Logger();

        public ContactBusinessLogic() { }

        public override object GetAll()
        {
            object compList = new List<object>();
            try
            {
                using (var db = new StageObxContext())
                {
                    compList = db.Contacts.ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "GetAll impossible");
                throw new Exception(e.Message);
            }

            return DatabaseMapper.DatabaseMapper.MapToContactDTO((List<Contacts>)compList);
        }

        public override object Get(object obj)
        {
            Contacts comp = new Contacts();
            int id = Check(obj);
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Contacts.Where(c => c.CompanyId == id).FirstOrDefault();
                    comp = result;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "GetContact impossible");
                throw new Exception(e.Message);
            }
            return DatabaseMapper.DatabaseMapper.MapToContactDTO(comp);

        }

        public override int Check(object obj)
        {

            ContactDTO cont = (ContactDTO)obj;
            try
            {
                using (var db = new StageObxContext())
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
                logger.Error(e.Message + "Check Error");
                throw new Exception(e.Message);
            }
        }

        public override object Add(object obj)
        {
            ContactDTO cont = (ContactDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {

                    var result = db.Contacts.FirstOrDefault(c => c.ContactName == cont.ContactName);
                    if (!obj.Equals((Contacts)result))
                        db.Contacts.Add(new Contacts()
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
                logger.Error(e.Message + "addContact impossible");
                throw new Exception(e.Message);
            }
            return "";
        }

        public override void Remove(object obj)
        {
            int id = Check(obj);
            if (id == -1)
            {
                logger.Error("contact not found !");
                return;
            }
            try
            {
                using (var db = new StageObxContext())
                {

                    var result = db.Contacts.Remove(db.Contacts.FirstOrDefault(c => c.ContactId == id));
                    db.SaveChanges();


                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "unable to remove contact");
                throw new Exception(e.Message);
            }
        }

        public override void Modify(object obj)
        {
            int id = Check(obj);
            if (id == -1)
            {
                logger.Error("modify impossible contact not found");
                return;
            }
            ContactDTO cont = (ContactDTO)obj;
            try
            {
                using (var db = new StageObxContext())
                {
                    db.Contacts.Add(new Contacts()
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
                logger.Error(e.Message + "unable to modify contact");
                throw new Exception(e.Message);
            }
        }

    }
}

