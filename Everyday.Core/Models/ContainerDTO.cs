using Everyday.Core.Entities;

namespace Everyday.Core.Models
{
    public class ContainerDTO
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

        public ContainerDTO(Container entry)
        {
            Id = entry.Id;
            TrashTypeId = entry.TrashTypeId;
            IsReusable = entry.IsReusable;
        }
        #endregion
    }
}
