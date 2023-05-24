using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Crud_Login.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]

        public DateTime Birthdate{get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Activestatus { get; set; }
        [Required]
        public string Gender { get; set; }



    }
}