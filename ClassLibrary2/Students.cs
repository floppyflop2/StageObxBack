namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            Internship = new HashSet<Internship>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(40)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(40)]
        public string Studentsurname { get; set; }

        [Required]
        [StringLength(5)]
        public string departement { get; set; }

        [Required]
        [StringLength(20)]
        public string Studenttelephone { get; set; }

        [Required]
        [StringLength(30)]
        public string Studentemail { get; set; }

        public byte[] document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Internship> Internship { get; set; }
    }
}
