using System.ComponentModel.DataAnnotations;

namespace CDTS_Blazor.Data.Entity
{
    public class Address
    {
        public string ApartmentUnitNumber { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string Street { get; set; }

        public string POBox { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        public string Telephone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
