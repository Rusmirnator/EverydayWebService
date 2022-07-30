using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class Dictionary
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        public virtual DictionaryCategory Category { get; set; }
    }
}
