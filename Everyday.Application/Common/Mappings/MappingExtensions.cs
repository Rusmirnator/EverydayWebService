using Everyday.Application.Common.Models;
using Everyday.Domain.Entities;

namespace Everyday.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static UserResponseModel? ToResponse(this User? entity)
        {
            if (entity is null)
            {
                return default;
            }

            return new(entity.Login ?? string.Empty);
        }
    }
}
