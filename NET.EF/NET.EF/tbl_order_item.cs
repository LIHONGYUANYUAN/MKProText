//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NET.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_order_item
    {
        public long id { get; set; }
        public Nullable<long> order_id { get; set; }
        public Nullable<long> goods_id { get; set; }
        public Nullable<long> quantity { get; set; }
        public Nullable<long> amount { get; set; }
    }
}
