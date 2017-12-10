using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DatabaseMapper.DatabaseMapper;
using Models;

namespace BusinessLogic
{
    public class ContractBusinessLogic : BaseBusinessLogic
    {
        private object GetAll()
        {
            List<Contract> result = null;
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    result = db.Contracts.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return MapToContractDTO(result);
        }

        public override object Get(string userId)
        {

            int contractId = 0;
            List<Contract> result = null;

            // GETS ALL THE STUDENTS IF ID == 0
            if (userId == "0")
            {
                return GetAll();
            }

            if (!Int32.TryParse(userId, out contractId))
            {
                try
                {
                    using (var db = new stageobxdatabaseEntities())
                    {
                        result = db.Contracts.Where(c => c.ContractId == contractId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    using (var db = new stageobxdatabaseEntities())
                    {
                        result = db.Contracts.Where(c => c.Student.AspNetUserId == userId).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return MapToContractDTO(result);
        }

        public override object Add(object obj, string id)
        {
            ContractDTO contract = (ContractDTO)obj;
            try
            {
                using (var db = new stageobxdatabaseEntities())
                {
                    db.Contracts.Add(
                        new Contract()
                        {
                            ContractAddressBox = contract.ContractAddressBox,
                            ContractAddressCity = contract.ContractAddressCity,
                            ContractAddressNumber = contract.ContractAddressNumber,
                            ContractAddressPostalCode = contract.ContractAddressPostalCode,
                            ContractAddressStreet = contract.ContractAddressStreet,
                            ContractArrivalTime = contract.ContractArrivalTime,
                            ContractContactName = contract.ContractContactName,
                            ContractContactTitle = contract.ContractContactTitle,
                            ContractModality = contract.ContractModality,
                            ContractName = contract.ContractName,
                            ContractNotes = contract.ContractNotes,
                            ContractOptionnalInstruction = contract.ContractOptionnalInstruction,
                            ContractPhone = contract.ContractPhone,
                            ContractSubject = contract.ContractSubject,
                            ContractSupervisorFirstName = contract.ContractSupervisorFirstName,
                            ContractSupervisorMail = contract.ContractSupervisorMail,
                            ContractSupervisorName = contract.ContractSupervisorName,
                            ContractSupervisorPhone = contract.ContractSupervisorPhone,
                            StudentId = db.Students.First(w => w.AspNetUserId == id).StudentId
                        }    
                    );
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "";
        }
    }
}
