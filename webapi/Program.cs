using System;
using data;
using model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host  = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<Context>();
                    context.Database.EnsureCreated();
                    context.Promotion.Add(
                        new Promotion()
                        {
                            name = "Pague 1 e leve 2",
                            clause = 2,
                            value = 50.0m,
                            ValueType = PromotioType.PERCENTAGE
                        }
                    );
                    
                    context.Promotion.Add(
                        new Promotion()
                        {
                            name = "3 por 10",
                            clause = 3,
                            value = 10.0m,
                            ValueType = PromotioType.FIXED
                        }
                    );
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService <ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
            
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}