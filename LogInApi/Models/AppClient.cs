using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LogInApi.Models
{
    public class AppClient
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Nick { get; set; }

        [Required]
        [MaxLength(64)]
        public string PassCode { get; set; }

        [Required] 
        public string EmailAddress { get; set; }

    }
}
