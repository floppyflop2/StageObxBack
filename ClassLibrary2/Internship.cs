namespace DBDomain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Internship")]
    public partial class Internship
    {
        public int InternshipId { get; set; }

        public int? CompanyId { get; set; }

        public int? StudentId { get; set; }

        public DateTime? InternshipYear { get; set; }

        public virtual Companies Companies { get; set; }

        public virtual Students Students { get; set; }
    }
}
