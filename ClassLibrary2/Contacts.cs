namespace DBDomain
{
    using System.ComponentModel.DataAnnotations;

    public partial class Contacts
    {
        [Key]
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

        public virtual Companies Companies { get; set; }
    }
}
