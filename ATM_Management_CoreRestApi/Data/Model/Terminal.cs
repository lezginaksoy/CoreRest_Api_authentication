using System;
using System.Collections.Generic;

namespace ATM_Management_CoreRestApi.Data.Model
{
    public partial class Terminal
    {
        public int TerminalId { get; set; }
        public string Desc { get; set; }
        public string TerminalCode { get; set; }
        public int? BrandId { get; set; }
    }
}
