namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contacts
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(40)]
        public string contactName { get; set; }

        [Required]
        [StringLength(40)]
        public string contactSurname { get; set; }

        [Required]
        [StringLength(20)]
        public string contactTelephone { get; set; }

        [Required]
        [StringLength(30)]
        public string contactEmail { get; set; }

        public int CompanyId { get; set; }

        public virtual Companies Companies { get; set; }
    }
}
