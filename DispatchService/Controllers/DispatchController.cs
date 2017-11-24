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
    [RoutePrefix("app/machin")]
    public class DispatchController : ApiController
    {
    
        [HttpPost]
        [Route("blabla/{id:string}")]
        public object Dispatch(RequestModel obj, string id)
        {
            if (obj.Name == null)
                return "Give a name tocard";
            if (obj.Type == null)
                return "Give me a type tocard";

            switch (obj.Type)
            {
                case "Get":
                    return Operation.Get(obj.Name, obj.FindCorrectDTO());
                case "Add":
                    Operation.Add(obj.Name, obj.FindCorrectDTO());
                    return null;
                case "Modify":
                    Operation.Modify(obj.Name, obj.FindCorrectDTO());
                    return null;
                case "Remove":
                    Operation.Remove(obj.Name, obj.FindCorrectDTO());
                    return null;
                default:
                    return null;
            }
        }

       

    }
}
