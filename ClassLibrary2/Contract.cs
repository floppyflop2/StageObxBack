//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        public int ContractId { get; set; }
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
        public int StudentId { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
