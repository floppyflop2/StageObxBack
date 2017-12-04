using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using StageobxDB;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Student a = new Student()
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

        [TestMethod]
        public async void TestMethod2()
        {
            try
            {
                using (var db = new DBModel())
                {
                    await db.Students.FirstAsync();
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
