using TokenApi.Data.Repository;
using TokenApi.Data.UnitOfWork;
using TokenApi.Data;
using TokenApi.Service;
using AutoMapper;

namespace TokenApi.Web;

public static class StartUpExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        // uow
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
    }

    public static void AddMapperService(this IServiceCollection services)
    {
        // mapper
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new Mapping());
        });
        services.AddSingleton(mapperConfig.CreateMapper());
    }


    public static void AddBussinessServices(this IServiceCollection services)
    {
        // repos
        services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
        services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

        
        // services
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenManagementService, TokenManagementService>();
    }
}
