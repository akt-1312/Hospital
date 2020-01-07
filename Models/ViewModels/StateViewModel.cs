using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class StateViewModel
    {
        public List<State> States { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
    }
}
