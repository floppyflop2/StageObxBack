using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
