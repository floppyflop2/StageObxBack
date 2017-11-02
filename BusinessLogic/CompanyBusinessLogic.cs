using ClassLibrary2;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CompanyBusinessLogic :BusinessLogic
    {


        private StageObxModel db = new StageObxModel() ;

        public override object Get()
        {
            return new CompanyDTO { };
        }

        public override void Add(object obj)
        {
            
            Debug.WriteLine("");
        }

        public override void Remove(object obj)
        {
            base.Remove((CompanyDTO)obj);
        }

        public override void Modify(object obj)
        {
            base.Modify((CompanyDTO)obj);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
