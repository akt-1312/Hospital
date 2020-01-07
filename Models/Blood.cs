using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models
{
    public class Blood
    {
        [Key]
        public int BloodID { get; set; }

        [Required]
        [Display(Name ="BloodGroup")]
        public string BloodType { get; set; }
    }
}
