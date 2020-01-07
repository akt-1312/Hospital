using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class ServicePriceViewModel
    {
        public List<ServicePrice> ServicePrices { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
