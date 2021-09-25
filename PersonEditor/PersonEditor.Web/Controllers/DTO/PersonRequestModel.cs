using PersonEditor.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonEditor.Web.Controllers.DTO
{
    public class PersonRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [GenderValidation(ErrorMessage = "Gender is not valid")]
        public Gender Gender { get; set; }

        [Required]
        public AddressRequestModel Address { get; set; }
    }
}
