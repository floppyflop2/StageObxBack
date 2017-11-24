using System;

namespace Models
{

    public class InternshipDTO
    {
        public int Id { get; set; }
        public DateTime Year { get; set; }
        public int StudentId { get; set; }
        public int CompanyId { get; set; } 
    }
}
