using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace DispatchService.Models
{
    public class RequestModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
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