using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THTZDotNetCore.MiniKpayDatabase.Models
{
    public class TblWithdraw
    {
        public int WithdrawId { get; set; }
        public string MobileNumber { get; set; }
        public decimal Balance { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
