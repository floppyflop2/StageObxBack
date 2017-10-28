using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class StudentBusinessLogic : BusinessLogic
    {
        public override object Get()
        {
            return new StudentDTO { Name = "Alex", FirstName = "Le Jacko"};
        }

        public override void Add(object obj)
        {
            Debug.WriteLine(((StudentDTO)obj).Name);
        }
    }
}

