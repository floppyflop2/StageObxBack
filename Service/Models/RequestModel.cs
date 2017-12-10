using System.Linq;
using Models;

namespace Service.Models
{
    public class RequestModel
    {
        public StudentDTO StudentDTO { get; set; }
        public CompanyDTO CompanyDTO { get; set; }

        public object FindCorrectDTO()
        {
            return new object[] { StudentDTO, CompanyDTO }.FirstOrDefault(w => w != null);
        }
    }
}