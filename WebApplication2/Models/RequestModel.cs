using System.Linq;
using Models;

namespace DispatchService.Models
{
    public class RequestModel
    {
        public StudentDTO StudentDTO { get; set; }
        public InternshipDTO DocumentDTO { get; set; }
        public ContactDTO ContactDTO { get; set; }
        public CompanyDTO CompanieDTO { get; set; }

        public object FindCorrectDTO()
        {
            return new object[] { StudentDTO, DocumentDTO, ContactDTO, CompanieDTO }.FirstOrDefault(w => w != null);
        }
    }
}