using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DocumentBusinessLogic : BusinessLogic
    {

        public override object Get(int id)
        {
            return new InternshipDTO {};
        }

        public override void Add(object obj)
        {
            Debug.WriteLine("");
        }

        public override void Remove(object obj)
        {
            base.Remove((InternshipDTO)obj);
        }

        public override void Modify(object obj)
        {
            base.Modify((InternshipDTO)obj);
        }

        public override void Dispose()
        {
            base.Dispose();
        }


    }
}
