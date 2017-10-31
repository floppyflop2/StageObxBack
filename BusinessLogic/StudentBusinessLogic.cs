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

        public override void Remove(object obj)
        {
            base.Remove((StudentDTO)obj);
        }

        public override void Modify(object obj)
        {
            base.Modify((StudentDTO)obj);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        

    }
}

