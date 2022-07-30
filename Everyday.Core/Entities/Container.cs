using System;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class Container
    {
        public int Id { get; set; }
        public DateTime? CreateDt { get; set; }
        public int TrashTypeId { get; set; }
        public bool IsReusable { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
