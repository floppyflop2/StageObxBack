﻿using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;

namespace BusinessLogic
{
    public abstract class BaseBusinessLogic : IDisposable
    {

        public virtual object Get(string id)
        {
            throw new Exception("Not implemented for this object");
        }
        
        public virtual object Add(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Modify(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Remove(object obj)
        {
            throw new Exception("Not implemented for this object");
        }


        public void Dispose()
        {

        }
    }
}