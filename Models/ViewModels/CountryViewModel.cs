using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> Countries { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
