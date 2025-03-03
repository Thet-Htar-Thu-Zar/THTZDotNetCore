﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THTZDotNetCore.MiniKpayDatabase.Models
{
    public class TblUser
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public decimal Balance { get; set; }
        public string? Pin { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
