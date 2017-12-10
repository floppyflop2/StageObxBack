using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public string ContractName { get; set; }
        public string ContractSupervisorName { get; set; }
        public string ContractSupervisorFirstName { get; set; }
        public string ContractSupervisorMail { get; set; }
        public string ContractSupervisorPhone { get; set; }
        public string ContractAddressStreet { get; set; }
        public string ContractAddressNumber { get; set; }
        public string ContractAddressBox { get; set; }
        public string ContractAddressPostalCode { get; set; }
        public string ContractAddressCity { get; set; }
        public string ContractSubject { get; set; }
        public string ContractModality { get; set; }
        public string ContractContactTitle { get; set; }
        public string ContractContactName { get; set; }
        public string ContractPhone { get; set; }
        public string ContractOptionnalInstruction { get; set; }
        public string ContractArrivalTime { get; set; }
        public string ContractNotes { get; set; }
    }
}
