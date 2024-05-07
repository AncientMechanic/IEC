using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Employers
{
    public class UpdateEmployerView
    {
        public string CompanyName { get; set; } = null!;
        public string ContactFirstName { get; set; } = null!;
        public string ContactLastName { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Wage { get; set; } = null!;
        public string JobOfferStatus { get; set; } = null!;
    }
}
