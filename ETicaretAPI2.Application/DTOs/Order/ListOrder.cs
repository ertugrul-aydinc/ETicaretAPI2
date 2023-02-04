using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI2.Application.DTOs.Order
{
    public class ListOrder
    {
        public int TotalOrderCount { get; set; }
        public object Orders { get; set; }
    }
}
