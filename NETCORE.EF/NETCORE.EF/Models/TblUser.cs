using System;
using System.Collections.Generic;

namespace NETCORE.EF.Models
{
    public partial class TblUser
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public sbyte? Age { get; set; }
    }
}
