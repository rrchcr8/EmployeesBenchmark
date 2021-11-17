using Application.ServiceManager;
using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistance;
using Persistance.Implementation;
using Services.Abstractions;

namespace EmployeesBenchmark
{
    public class Startup
    {
        readonly string CorsConfiguration = "_corsConfiguration";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeesBenchmark", Version = "v1" });
            });

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            //db
            string connectionString = this.Configuration.GetConnectionString("myconn");
            services.AddDbContext<ApplicationDbContext>(item => item.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseSqlServer(
            //       Configuration.GetConnectionString("DefaultConnection"), 
            //       b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsConfiguration,
                                  builder =>
                                  {
                                      builder
                                      .WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeesBenchmark v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(CorsConfiguration);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
