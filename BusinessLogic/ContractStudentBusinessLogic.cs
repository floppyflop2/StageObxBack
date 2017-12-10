using Models;
using System.Collections.Generic;
using System;
using System.Linq;
using static DatabaseMapper.DatabaseMapper;
using ClassLibrary2;

namespace BusinessLogic
{
    public class ContractStudentBusinessLogic : BaseBusinessLogic
    {

        public override object Get(string id)
        {
            List<Contract> result = null;
            int integerId = Int32.Parse(id);
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    result = db.Contracts.Where(c => c.StudentId == integerId).ToList();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return MapToContractDTO(result);
        }
    }
}
