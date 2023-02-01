using Everyday.Application.Common.Models;
using MediatR;

namespace Everyday.Application.Common.Queries
{
    public record GetUserToken(LoginRequestModel Login) : IRequest<UserResponseModel>;
}
