using EcommerceWeb.Application.Authentication.Commands.Register;
using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Application.Authentication.Queries.Login;
using EcommerceWeb.Presentation.Authutentication;
using Mapster;

namespace EcommerceWeb.WebApi.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
