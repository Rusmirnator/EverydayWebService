using Everyday.Core.EntitiesPg;
using Everyday.Core.Shared;

namespace Everyday.Core.Models
{
    public class ContainerDTO : DataTransferObject
    {
        #region Fields & Properties
        public int Id { get; set; }
        public int TrashTypeId { get; set; }
        public bool IsReusable { get; set; }
        #endregion

        #region CTOR
        public ContainerDTO()
        {

        }

        public ContainerDTO(Container entry) : base()
        {
            Id = entry.Id;
            TrashTypeId = entry.TrashTypeId;
            IsReusable = entry.IsReusable;
        }
        #endregion
    }
}
