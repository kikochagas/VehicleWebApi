using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VehicleWebApi.Models;
using VehicleWebApi.Models.Repository;
using VehicleWebApi.Models.UnitOfWork;
using VehicleWebApi.Services;

namespace VehicleWebApi
{
    public class Startup
    {
        readonly string AllowLocalHost = "_allowLocalHost";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(op =>
            {
                op.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehicleWebApi", Version = "v1" });
            });
            services.AddDbContext<VehicleDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowLocalHost,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IVehicleService, VehicleService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarsWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowLocalHost);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
