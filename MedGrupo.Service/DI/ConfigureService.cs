using MedGrupo.Domain.Interfaces.Services.Contact;
using MedGrupo.Domain.Interfaces.Services.User;
using MedGrupo.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace MedGrupo.Service.DI
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IContactService, ContactService>();

        }
    }
}
