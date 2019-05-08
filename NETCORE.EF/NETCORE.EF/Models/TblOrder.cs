using System;
using System.Collections.Generic;

namespace NETCORE.EF.Models
{
    public partial class TblOrder
    {
        public long Id { get; set; }
        public string Order_Code { get; set; }
        public long? User_Id { get; set; }
        public long? Amount { get; set; }
        public DateTime? Uptime { get; set; }
        public string Text { get; set; }
    }
}
