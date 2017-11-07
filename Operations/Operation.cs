using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public static class Operation
    {
        public static object Get(string caller)
        {
            return GetBusinessLogic(caller).Get();
        }

        public static void Add(string caller, object obj)
        {
            GetBusinessLogic(caller).Add(obj);
        }


        public static void Remove(string caller, object obj)
        {
             GetBusinessLogic(caller).Remove(obj);
        }


        public static void Modify(string caller, object obj)
        {
             GetBusinessLogic(caller).Modify(obj);
        }


        public static BusinessLogic.BusinessLogic GetBusinessLogic(string caller)
        {
            switch (caller)
            {
                case "Student":
                    return new StudentBusinessLogic();
                case "Contact":
                    return new ContactBusinessLogic();
                case "Documents":
                    return new InternshipBusinessLogic();
                case "Company":
                    return new CompanyBusinessLogic();  
                   
                default:
                    return null;
            }
        }
    }
}
