using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DBDomain
{
    public class StageObxContextInitializer : CreateDatabaseIfNotExists<StageObxContext>
    {

        Logger logger = new Logger();
        protected override void Seed(StageObxContext context)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var sqlStreamReader = new StreamReader(assembly.GetManifestResourceStream("StageObxBack.07.domain.DBDomain.Put_PK_to_NONCLUSTERED.sql")))
                {
                    var sql = sqlStreamReader.ReadToEnd();
                    context.Database.ExecuteSqlCommand(sql);

                    // Indexes must be applied to be Azure compatible!
                    //context.Database.ExecuteSqlCommand("CREATE CLUSTERED INDEX [IX_AccountClu] on [App].[Account] ([Account])");

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return;
            }

            // Add data initialization here

            context.SaveChanges();

            base.Seed(context);
        }


        public static void ExecuteExample()
        {
            string connectionString = "server=localhost;port=5432;database=Web;uid=postgres;password=floflo19?";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create database if not exists
                using (StageObxContext contextDB = new StageObxContext(connection, false))
                {
                    contextDB.Database.CreateIfNotExists();
                }

                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // DbConnection that is already opened
                    using (StageObxContext context = new StageObxContext(connection, false))
                    {

                        // Interception/SQL logging
                        context.Database.Log = (string message) => { Console.WriteLine(message); };

                        // Passing an existing transaction to the context
                        context.Database.UseTransaction(transaction);

                        // DbSet.AddRange
                        /*            List<Car> cars = new List<Car>();

                                    cars.Add(new Car { Manufacturer = "Nissan", Model = "370Z", Year = 2012 });
                                    cars.Add(new Car { Manufacturer = "Ford", Model = "Mustang", Year = 2013 });
                                    cars.Add(new Car { Manufacturer = "Chevrolet", Model = "Camaro", Year = 2012 });
                                    cars.Add(new Car { Manufacturer = "Dodge", Model = "Charger", Year = 2013 });

                                    context.Cars.AddRange(cars);

                                    context.SaveChanges();*/
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}

