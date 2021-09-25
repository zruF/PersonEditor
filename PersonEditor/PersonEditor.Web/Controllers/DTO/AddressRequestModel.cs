using System.ComponentModel.DataAnnotations;

namespace PersonEditor.Web.Controllers.DTO
{
    public class AddressRequestModel
    {
        [Required]
        public string City { get; set; }

        [Required, Range(100, 1000000000)]
        public int PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Street { get; set; }
    }
}
