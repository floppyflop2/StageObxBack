//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Internship
    {
        public int InternshipId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<System.DateTime> year { get; set; }
    
        public virtual Companies Companies { get; set; }
        public virtual Students Students { get; set; }
    }
}
