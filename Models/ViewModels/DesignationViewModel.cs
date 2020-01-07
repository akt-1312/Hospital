using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class DesignationViewModel
    {
        public List<Designation> Designations { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
