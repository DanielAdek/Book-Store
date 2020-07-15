using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bookshop.Models;
using Bookshop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Bookshop
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
            services.Configure<BookShopRepository>(Configuration.GetSection(nameof(BookShopRepository)));

            services.AddSingleton<IBookShopRepository>(sp =>
            sp.GetRequiredService<IOptions<BookShopRepository>>().Value);

            services.AddSingleton<BookService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async ctx =>
                {
                    await ctx.Response.WriteAsync("Hello World");
                });

                endpoints.MapControllers();
            });
        }
    }
}
