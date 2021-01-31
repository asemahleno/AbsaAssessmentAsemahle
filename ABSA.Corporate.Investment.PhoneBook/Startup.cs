using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ABSA.Corporate.Investment.PhoneBook.Configurations;
using ABSA.Corporate.Investment.PhoneBook.Persistence;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Managers;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Managers.Impl;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories.Impl;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories.Int64;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ABSA.Corporate.Investment.PhoneBook
{
    public class Startup
    {
        private const string AllowAnyOriginCorsPolicy = "AllowAnyOriginCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("AbsaConnectionString");


            services.AddDbContext<DbContext, DatabaseContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
#if DEBUG
                    options.EnableSensitiveDataLogging();
#endif
                });

            services.AddAutoMapper(
                typeof(Startup));

            services.AddScoped<IEntryManager, EntryManager>();
            services.AddScoped<IPhoneBookManager, PhoneBookManager>();

            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();

            services.ConfigureApiForSwagger(Configuration);

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(AllowAnyOriginCorsPolicy, builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(AllowAnyOriginCorsPolicy);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           

            app.InitializeOpenApi(Configuration);
        }
    }
}
