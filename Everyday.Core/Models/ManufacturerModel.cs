using Everyday.Core.EntitiesPg;
using Everyday.Core.Shared;

namespace Everyday.Core.Models
{
    public class ManufacturerModel : DataTransferObject
    {
        #region Fields & Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region CTOR
        public ManufacturerModel() : base()
        {

        }

        public ManufacturerModel(Manufacturer entry) : base()
        {
            Id = entry.Id;
            Name = entry.Name;
            Description = entry.Description;
        }
        #endregion
    }
}
