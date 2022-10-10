using BLL.Users.Abstract;
using BLL.Users.Concrete;
using Common.Database;
using Configuration.AutoMapper;
using DAL;
using DAL.Abstract;
using DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        #region fields

        private readonly IConfiguration _config;

        #endregion

        #region constructors

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        #region operations

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });

            #region BLL

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region DAL

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region AM

            services.AddAutoMapper(typeof(UserProfile));

            #endregion

            #region DB

            services.AddDbContext<SocialMediaAppDbContext>(options => 
            {
                options.UseSqlServer(_config.GetConnectionString(DBCommon.ConnectionString));
            });

            #endregion

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(p => p.AllowAnyHeader()
                        .AllowAnyMethod().WithOrigins("https://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion
    }
}
