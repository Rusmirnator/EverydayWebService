using Everyday.Application.Common.Models;
using MediatR;

namespace Everyday.Application.Common.Queries
{
    public record GetUserTokenQuery(LoginRequestModel Login) : IRequest<UserResponseModel>;
}
