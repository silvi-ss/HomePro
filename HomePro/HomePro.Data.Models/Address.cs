using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePro.Data.Models
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }

    }
}
