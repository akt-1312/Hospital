using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class TownshipViewModel
    {
        public List<Township> Townships { get; set; }

        public PagingInfo PagingInfo { get; set; }

    }
}
