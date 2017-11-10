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
    public class ContactBusinessLogic : BusinessLogic
    {
        private readonly StageObxContext db;

        public ContactBusinessLogic(StageObxContext db)
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
                    compList = db.Contacts.ToList();
                }
            }
            catch
            {

            }
            return compList;
        }

        public override object Get(int id)
        {
            Contacts comp = new Contacts();
            try
            {
                using (var db = new StageObxContext())
                {
                    var result = db.Contacts.Where(c => c.CompanyId == id).FirstOrDefault();
                    comp = result;
                }
            }
            catch
            { }
            return comp;

        }

        public int ContactCheck(object obj)
        {
            var result = db.Contacts.Where(c => c.ContactEmail == obj.ContactEmail);
            if (result == null){
                return -1;
            }
            else{
                return result.ContactId;
            }
        }

        public override void Add(object obj)
        {
            try
            {
                using (var db = new StageObxContext())
                {
                    //TODO effectuer verif pour les doublons 
                    var result = db.Contacts.FirstOrDefault(c => c.contactName == obj.Name);
                    if (!obj.Equals((Contacts)result)) db.Contacts.Add((Contacts)obj);
                    db.SaveChanges();

                    /*
                     * int contactMax = db.Contacts.Max(c => c.ContactId);
                     * Contacts contact = new Contacts(){ContactId = contactMax+1, ContactName = obj.ContactName, ContactFirstName = obj.ContactFirstName, ContactTelephone = obj.ContactTelephone, ContactPostalCode = obj.ContactPostalCode, ContactEmail = obj.ContactEmail, CompanyId = obj.CompanyId};
                     * db.Contacts.Add(contact);
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
                    var result = db.Contacts.FirstOrDefault(c => c.ContactId == id);
                    if (result != null) db.Contacts.Remove(obj);
                    db.SaveChanges();

                    /*
                     * var result = db.contacts.Where(c => c.ContactId == id);
                     * db.companies.remove(result);
                     * db.savechanges();
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
                    var result = db.Contacts.FirstOrDefault(c => c.ContactId == obj.id);
                    if (result != null)
                    {
                        db.Contacts.Remove(result);
                        db.Contacts.Add((Contacts)obj);
                        db.SaveChanges();
                    }

                    /*
                     * var result = db.Contacts.Where(c => c.ContactId == obj.ContactId);
                     * db.Companies.Remove(result);
                     * db.Companies.Add((Contacts)obj);
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

