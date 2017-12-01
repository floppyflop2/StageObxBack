using DispatchService.Models;
using Newtonsoft.Json;
using Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DispatchService.Controllers
{
    public class DispatchController : ApiController
    {
        [HttpPost]
        [Route("{name}")]
        public object DispatchPost(RequestModel obj, string name){
            return name == null ? "Give a name" : Operation.Add(name, obj.FindCorrectDTO());
        }

        [HttpGet]
        [Route("{name}")]
        public object DispatchGet(RequestModel obj, string name)
        {
            return name == null ? "Give a name" : Operation.Get(name, obj.FindCorrectDTO());
        }

        [HttpPut]
        [Route("{name}")]
        public object DispatchPut(RequestModel obj, string name)
        {
            if (name == null)
                return "Give a name";
            Operation.Modify(name, obj.FindCorrectDTO());
            return "Ok";
        }

        [HttpDelete]
        [Route("{name}")]
        public object DispatchDelete(RequestModel obj, string name)
        {
            if  (name == null)
                return "Give a name";
            Operation.Remove(name, obj.FindCorrectDTO());
            return "Ok";
        }
    }
}
