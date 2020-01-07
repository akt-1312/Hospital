using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class DoctorScheduleViewModel
    {
        public List<DoctorSchedule> DoctorSchedules { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
