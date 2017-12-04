namespace StageobxDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int ContactId { get; set; }

        [Required]
        [StringLength(40)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(40)]
        public string ContactFirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactTelephone { get; set; }

        [Required]
        [StringLength(30)]
        public string ContactEmail { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
