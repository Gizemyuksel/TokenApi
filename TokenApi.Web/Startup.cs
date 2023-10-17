using TokenApi.Web;
using Microsoft.OpenApi.Models;
using TokenApi.Base;

namespace TokenApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public static JwtConfig JwtConfig { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        //jwt 
        JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
        services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));


        // inject
        services.AddDbContextDI(Configuration);
        services.AddServices();
        services.AddMapperService();
        services.AddBussinessServices();
        services.AddJwtAuthentication();
        services.AddCustomSwagger();

        services.AddControllers();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TokenApi v1"));
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        
    }
}
