using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Provider
    {
        public string Name { get; set; }
        public float Score { get; set; }
        public string[] Specialties { get; set; }
        public AvailableDateRange[] AvailableDates { get;set;}
    }
}
