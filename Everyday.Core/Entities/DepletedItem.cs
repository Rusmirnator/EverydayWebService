using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class DepletedItem
    {
        public int Id { get; set; }
        public DateTime DepleteDt { get; set; }
        public int DepleteCount { get; set; }
        public string DepletionReason { get; set; }
    }
}
