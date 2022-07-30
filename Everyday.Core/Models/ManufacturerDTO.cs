using Everyday.Core.Entities;

namespace Everyday.Core.Models
{
    public class ManufacturerDTO
    {
        #region Fields & Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region CTOR
        public ManufacturerDTO()
        {

        }

        public ManufacturerDTO(Manufacturer entry)
        {
            Id = entry.Id;
            Name = entry.Name;
            Description = entry.Description;
        }
        #endregion
    }
}
