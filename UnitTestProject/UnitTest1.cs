using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBDomain;
using System.Data.Entity;
using Util;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Students a = new Students()
            {
                StudentFirstName = "xxx",
                StudentEmail = "xx",
                StudentName = "xx"
            };
            try
            {
                using (var db = new DBModel())
                {
                    db.Students.Add(a);
                    Console.WriteLine(db.Students.CountAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




        }
    }
}
