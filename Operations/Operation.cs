using BusinessLogic;
using DBDomain;
namespace Operations
{
    public static class Operation
    {

        public static object Get(string caller, object obj)
        {
            return GetBusinessLogic(caller).Get(obj);
        }

         public static int Check(string caller, object obj)
        {
            return GetBusinessLogic(caller).Check(obj);
        }

        public static void Add(string caller, object obj)
        {
            GetBusinessLogic(caller).Add(obj);
        }


        public static void Remove(string caller, int id)
        {
            GetBusinessLogic(caller).Remove(id);
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
