using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Models.ViewModels
{
    public class PrefixViewModel
    {
        public List<Prefix> Prefixes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
