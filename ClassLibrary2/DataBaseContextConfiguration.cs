using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDomain
{
    public class StageObxContextConfiguration : DbConfiguration
    {
        public StageObxContextConfiguration()
        {
            // Today we still used the default execution startegy
            //SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}
