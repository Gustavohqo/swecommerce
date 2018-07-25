using data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using service;
using AutoMapper;
using service.Mappers;

namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase()
                .UseLazyLoadingProxies());

            services.AddMvc();

            Mapper.Initialize(cfg =>
            {
                cfg.Advanced.AllowAdditiveTypeMapCreation = true;
                cfg.AddProfile<EntityMapperProfile>();
                cfg.AddProfile<DtoMapperProfile>();
            });
            
            Mapper.AssertConfigurationIsValid();
            
            services.AddTransient<ProductService, ProductService>();
            services.AddTransient<PromotionService, PromotionService>();
            services.AddTransient<CartService, CartService>();
            
            services.AddTransient<ProductRepository, ProductRepository>();
            services.AddTransient<PromotionRepository, PromotionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opt => { opt.AllowAnyOrigin(); });
            app.UseMvc();
        }
    }
}