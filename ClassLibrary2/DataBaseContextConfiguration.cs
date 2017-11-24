using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDomain
{

    /*

        Server=tcp:morel.database.windows.net,1433;Initial
        Catalog=StageObsDB;Persist Security Info=False;
        User ID={your_username};Password={your_password};
        MultipleActiveResultSets=False;Encrypt=True;
        TrustServerCertificate=False;Connection Timeout=30;

    */

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class StageObxContextConfiguration : DbConfiguration
    {
        public StageObxContextConfiguration()
        {
            // Today we still used the default execution startegy
            //SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}
