using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public abstract class BusinessLogic : IDisposable
    {
        public virtual object Get()
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Add(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Remove(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Modify(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Dispose()
        {
        }
    }
}
