using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THTZDotNetCore.MiniKpayDatabase.Models
{
    public class TblTransfer
    {
        public int TransferId { get; set; }
        public string? FromMobileNumber { get; set; }
        public string? ToMobileNumber { get; set; }
        public decimal Amount { get; set; }
        public string? Pin { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
