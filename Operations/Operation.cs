﻿using BusinessLogic;
namespace Operations
{
    public static class Operation
    {

        public static object Get(string caller, string id)
        {
            return GetBusinessLogic(caller).Get(id);
        }

        public static object Add(string caller, object obj, string id)
        {
            return GetBusinessLogic(caller).Add(obj, id);
        }

        public static void Modify(string caller, object obj, string id)
        {
            GetBusinessLogic(caller).Modify(obj, id);
        }

        public static void Remove(string caller, object obj)
        {
            GetBusinessLogic(caller).Remove(obj);
        }


        public static BaseBusinessLogic GetBusinessLogic(string caller)
        {
            switch (caller)
            {
                case "Student":
                    return new StudentBusinessLogic();
                case "Company":
                    return new CompanyBusinessLogic();
                case "Contract":
                    return new ContractBusinessLogic();
                case "CompanyStudent":
                    return new CompanyStudentBusinessLogic();
                case "ContractStudent":
                    return new ContractStudentBusinessLogic();
                default:
                    return null;
            }
        }
    }
}
