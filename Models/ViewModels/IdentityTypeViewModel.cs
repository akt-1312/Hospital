using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class IdentityTypeViewModel
    {
        public List<IdentityType> IdentityTypes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
