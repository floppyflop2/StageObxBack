namespace StageobxDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            Contacts = new HashSet<Contact>();
            Internships = new HashSet<Internship>();
        }
     
        public int CompanyId { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyCity { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyStreetName { get; set; }

        [Required]
        [StringLength(20)]
        public string CompanyPostalCode { get; set; }

        [Required]
        [StringLength(20)]
        public string CompanyTelephone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Internship> Internships { get; set; }
    }
}
