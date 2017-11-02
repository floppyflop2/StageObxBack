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
        public override object Get()
        {
            return new ContactDTO { };
        }

        public override void Add(object obj)
        {
            Debug.WriteLine("");
        }

        public override void Remove(object obj)
        {
            base.Remove((ContactDTO)obj);
        }

        public override void Modify(object obj)
        {
            base.Modify((ContactDTO)obj);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
