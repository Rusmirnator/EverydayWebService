using Everyday.Application.Common.Interfaces.Services;
using Everyday.Application.Common.Models;
using Everyday.Application.Common.Queries;
using MediatR;

namespace Everyday.Application.Common.Handlers
{
    public class GetUserTokenHandler : IRequestHandler<GetUserTokenQuery, UserResponseModel?>
    {
        private readonly IIdentityService identityService;

        public GetUserTokenHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task<UserResponseModel?> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return default;
            }

            return await identityService.LoginAsync(request.Login);
        }
    }
}
