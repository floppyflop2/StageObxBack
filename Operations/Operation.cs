using BusinessLogic;
namespace Operations
{
    public static class Operation
    {

        public static object Get(string caller, int id)
        {
            return GetBusinessLogic(caller).Get(id);
        }

         public static int Check(string caller, object obj)
        {
            return GetBusinessLogic(caller).Check(obj);
        }

        public static object Add(string caller, object obj)
        {
            return GetBusinessLogic(caller).Add(obj);
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
                case "Internship":
                    return new InternshipBusinessLogic();
                case "Company":
                    return new CompanyBusinessLogic();
                default:
                    return null;
            }
        }
    }
}
