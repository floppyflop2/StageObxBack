namespace StageobxDB
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

        public DateTime? year { get; set; }

        public virtual Company Company { get; set; }

        public virtual Student Student { get; set; }
    }
}
