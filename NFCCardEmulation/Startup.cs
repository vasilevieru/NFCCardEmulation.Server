using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NFCCardEmulation.Application.AutoMapper;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Application.Users.QueryHandlers;
using NFCCardEmulation.Filters;
using NFCCardEmulation.Persistence;
using NFCCardEmulation.Services;

namespace NFCCardEmulation
{
    public class Startup
    {
        public bool IsDevelopment { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            IsDevelopment = env.IsDevelopment();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<INFCCardEmulationDbContext, NFCCardEmulationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(new Assembly[] { typeof(UserProfile).GetTypeInfo().Assembly });

            services.AddMediatR(typeof(GetUserDetailsQueryHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(ICurrentUser), typeof(HttpContextCurrentUser));


            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
