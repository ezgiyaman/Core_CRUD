using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD.Models.DTOs
{
    public class CreateAppUserDTO
    {
        [Required(ErrorMessage = "Must to type into first name")]
        [MinLength(3, ErrorMessage = "Minumum lenght is 3")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must to type into category name")]
        [MinLength(3, ErrorMessage = "Minumum lenght is 3")]
        public string LastName { get; set; }
    }
}
