
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DALayer;
using DALayer.Models;
using EntityLayer;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace UILayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient(typeof(HttpClient));
            services.AddTransient(typeof(OnlineBankingSystemContext));
            services.AddTransient(typeof(TransactionDataService));
            services.AddTransient(typeof(ITransaction), typeof(TransactionDataService));
            services.AddTransient(typeof(AccountDataService));
            services.AddTransient(typeof(IAccount), typeof(AccountDataService));
            services.AddTransient(typeof(AccountTypeDataService));
            services.AddTransient(typeof(IAccountType), typeof(AccountTypeDataService));
            services.AddTransient(typeof(LoanDataService));
            services.AddTransient(typeof(ILoan), typeof(LoanDataService));
            services.AddTransient(typeof(IUser), typeof(UserLoginDataService));
            services.AddControllers();
            services.AddSession();
            services.AddCors();




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "myapp", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "jwt",
                    // Name="www-authenticate",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme
                    {
                      Reference=new OpenApiReference
                    {
                      Type=ReferenceType.SecurityScheme,
                         Id="Bearer"
                     }
                },new String[]{ }
            }
        });

            });



            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;



            }).AddJwtBearer(c =>
            {
                c.SaveToken = true;

                c.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = "http://localhost:11646",
                    ValidIssuer = "http://localhost:11646",
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrst"))
                };
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(sw => sw.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineBanking"));
            app.UseCookiePolicy();
            app.UseSession();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=UI}/{action=Login}/{id?}");
            });
        }
    }
}
