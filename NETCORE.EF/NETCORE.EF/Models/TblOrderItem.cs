using System;
using System.Collections.Generic;

namespace NETCORE.EF.Models
{
    public partial class TblOrderItem
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public long? GoodsId { get; set; }
        public long? Quantity { get; set; }
        public long? Amount { get; set; }
    }
}
