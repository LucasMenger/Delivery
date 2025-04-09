
using Microsoft.EntityFrameworkCore;

namespace SharedKernel.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        // Configuration.ConnectionString =
        // builder.Services.AddDbContext<AppDbContext>(options =>
        //     options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
    }
    
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options => 
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
        });
    }
}