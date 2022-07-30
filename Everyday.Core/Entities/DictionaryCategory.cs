using System;
using System.Collections.Generic;

#nullable disable

namespace Everyday.Core.Entities
{
    public partial class DictionaryCategory
    {
        public DictionaryCategory()
        {
            Dictionaries = new HashSet<Dictionary>();
        }

        public int Id { get; set; }
        public DateTime CreateDt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Dictionary> Dictionaries { get; set; }
    }
}
