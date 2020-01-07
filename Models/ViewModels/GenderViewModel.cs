using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class GenderViewModel
    {
        public List<Gender> Genders { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
