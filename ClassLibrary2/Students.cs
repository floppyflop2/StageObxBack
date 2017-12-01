using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBDomain
{

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
        public string StudentFirstName { get; set; }

        [Required]
        [StringLength(5)]
        public string StudentDepartement { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentTelephone { get; set; }

        [Required]
        [StringLength(30)]
        public string StudentEmail { get; set; }

        public byte[] StudentDocument { get; set; }

        public string StudentToken { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Internship> Internship { get; set; }
    }
}

