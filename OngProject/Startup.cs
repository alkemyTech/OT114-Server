using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OngProject.Data;
using OngProject.Interfaces;
using OngProject.Services;
using System.Collections.Generic;
using OngProject.Models;
using OngProject.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Amazon.S3;
using OngProject.Middlewares;
using System.Reflection;
using System.IO;
using System;

namespace OngProject
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
            //services.AddDbContext<ONGDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ONGDBConnection")));

            services.AddEntityFrameworkSqlServer();
            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICommentsService, CommentsService>();

            services.AddAWSService<IAmazonS3>();
            services.AddTransient<AwsS3Service>();
            services.AddSingleton<IMailService, MailService>();

            services.AddDbContextPool<ONGDBContext>(optionsAction: (provider, builder) =>
            {
                builder.UseInternalServiceProvider(provider);
                builder.UseSqlServer(connectionString: "Data Source=(localdb)\\MSSQLLocalDB;Database=OngDb;Integrated Security=True;");
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OngProject", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer",
                        new OpenApiSecurityScheme
                        {
                            Name = "Authorization",
                            Type = SecuritySchemeType.ApiKey,
                            Scheme = "Bearer",
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,
                            Description = "Ingrese Bearer [Token] para poder identificarse dentro de la aplicación"


                        });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                          {
                                 Reference= new OpenApiReference
                                 {
                                        Type=ReferenceType.SecurityScheme,
                                        Id="Bearer"
                                 }
                          },
                        new List<string>()
                    }

                });

            });

            //Inyecta las dependencias necesarias de identity
            services.AddIdentity<User, IdentityRole/*aca agregar entidad roles*/>().AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();
            //Toma un usuario, los roles y coloca la configuración por default.

            //Añade un tipo de autentificación:
            /*Agrega autentificacion JWT ("Con "Bearers"")*/
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//chequear si se debe eliminar la linea
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options => {
                    options.SaveToken = true; // que guarde el token autorizado
                    options.RequireHttpsMetadata = false; //en enterono de desarrolo false, no necesito aun https
                    options.TokenValidationParameters = new TokenValidationParameters
                    { //parametros para la validacion del token
                        ValidateIssuer = true, //entidad que genera el token
                        ValidateAudience = true, //usuarios que usan o ven el token
                        ValidAudience = "https://localhost:5001", 
                        ValidIssuer = "https://localhost:5001",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeySecretaSuperLargaDeAutorizacion")) 
                        //Encargado de proveernos info con la llave secreta para ingresar a la aplicación
                        // TOKEN = HEADER + PILOT + FIRMA
                    };
                });

            services.AddDbContext<UserContext>(optionsAction: (services, options) =>
            {
                options.UseInternalServiceProvider(services);
                options.UseSqlServer(connectionString: "Data Source=(localdb)\\MSSQLLocalDB;Database=UserOngDb;Integrated Security=True;");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OngProject v1"));
            }
            app.UseMiddleware<UserMiddleware>();
            app.UseMiddleware<OwnershipMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
