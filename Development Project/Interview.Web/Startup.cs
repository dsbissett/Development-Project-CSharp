using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Sparcpoint.Inventory;
using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Inventory.Repostiories;
using Sparcpoint.Service;
using Sparcpoint.Service.Abstractions;

namespace Interview.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext, SparcpointInventoryDatabaseContext>(x =>
            {
                x.UseSqlServer(this.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddControllers();

            services.AddRepositories();

            services.AddServices();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<ProductAttribute>, ProductAttributeRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<CategoryAttribute>, CategoryAttributeRepository>();
            services.AddScoped<IRepository<InventoryTransaction>, InventoryTransactionRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IService<Product>, ProductService>();
            services.AddScoped<IService<ProductAttribute>, ProductAttributeService>();
            services.AddScoped<IService<Category>, CategoryService>();
            services.AddScoped<IService<CategoryAttribute>, CategoryAttributeService>();
            services.AddScoped<IService<InventoryTransaction>, InventoryTransactionService>();
            return services;
        }
    }
}
