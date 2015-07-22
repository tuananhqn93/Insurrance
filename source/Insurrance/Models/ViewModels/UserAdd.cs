using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurrance.Models.ViewModels
{
    public class UserAdd
    {
        [MaxLength(4)]
        [MinLength(4)]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [MaxLength(11)]
        [MinLength(11)]
        public string NIN { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public string Phone { get; set; }

        [MaxLength(4)]
        [MinLength(4)]
        public string PostCode { get; set; }
    }
}