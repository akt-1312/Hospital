using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class MaritalStatusViewModel
    {
        public List<MaritalStatus> MaritalStatuses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
