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
    }
}
