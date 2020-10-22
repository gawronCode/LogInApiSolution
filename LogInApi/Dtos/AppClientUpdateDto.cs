using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogInApi.Dtos
{
    public class AppClientUpdateDto
    {
        [Required]
        [MaxLength(64)]
        public string Nick { get; set; }

        [Required]
        [MaxLength(64)]
        public string PassCode { get; set; }

        [MaxLength(64)]
        public string NewPassCode { get; set; }

        [MaxLength(64)]
        public string NewEmailAddress { get; set; }

    }
}
