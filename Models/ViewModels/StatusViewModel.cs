using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class StatusViewModel
    {
        public List<Status> Statuses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
