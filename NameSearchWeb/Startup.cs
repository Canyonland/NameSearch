using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using NameSearchCore;
using Newtonsoft.Json;

namespace NameSearchApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        string ClientAppOrigin = "_ALLOWClientApp";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<PersonRepository, PersonRepository>();
            services.AddTransient<PersonService, PersonService>();
            services.AddHttpContextAccessor();
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<CommunityContext>(options => options.UseSqlite(@"Filename=Community.db"));
            services.AddCors(options =>
            {
                options.AddPolicy(ClientAppOrigin, builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                });

            });
            //services.AddDbContext<CommunityContext>(options => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=SaltLakeCity;Trusted_Connection=True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(ClientAppOrigin);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
