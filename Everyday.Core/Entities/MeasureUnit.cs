using System;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class MeasureUnit
    {
        public int Id { get; set; }
        public DateTime? CreateDt { get; set; }
        public string Signature { get; set; }
        public string Name { get; set; }
    }
}
