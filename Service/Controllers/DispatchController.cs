﻿using Service.Models;
using Newtonsoft.Json;
using Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DispatchService.Controllers
{
    [Authorize]
    public class DispatchController : ApiController
    {

        [HttpGet]
        [Route("{name}/{id}")]
        public object DispatchGet(string name, int id)
        {
            if (name == "Create" && id == 0)
            {
                using (var context = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    roleManager.Create(new IdentityRole("Admin"));
                }
                return "";
            }
            return name == null ? "Give a name" : Operation.Get(name, id);
        }

        [HttpPost]
        [Route("{name}")]
        public object DispatchPost(RequestModel obj, string name)
        {
            return name == null ? "Give a name" : Operation.Add(name, obj.FindCorrectDTO());
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{name}")]
        public object DispatchPut(RequestModel obj, string name)
        {
            if (name == null)
                return "Give a name";
            Operation.Modify(name, obj.FindCorrectDTO());
            return "Ok";
        }

        [Authorize(Roles = "Admin")]
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