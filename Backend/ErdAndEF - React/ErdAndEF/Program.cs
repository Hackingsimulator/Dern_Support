using ErdAndEF.Data;
using ErdAndEF.Models;
using ErdAndEF.Repositories.Interfaces;
using ErdAndEF.Repositories.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace ErdAndEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Get the connection string settings from appsettings.json or appsettings.Development.json
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            // Switch to MySQL configuration
            builder.Services.AddDbContext<EmployeeDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21)) // Ensure the MySQL version here matches your setup
                    ));


            // Add Identity Service
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EmployeeDbContext>();

            //builder.Services.AddTransient<IEmployee, EmployeeService>();
            builder.Services.AddScoped<IEmployee, EmployeeService>();
            builder.Services.AddScoped<IUser, IdentitiUserService>();
            builder.Services.AddScoped<JwtTokenService>();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            // Add auth service to the app using JWT
            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
            });

            // Configure Authorization with Claims
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("CanCreate", policy => policy.RequireClaim("Permission", "CanCreate"));
                options.AddPolicy("CanDelete", policy => policy.RequireClaim("Permission", "CanDelete"));
            });

            // Swagger configuration
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("employeesApi", new OpenApiInfo()
                {
                    Title = "Employees Api Doc",
                    Version = "v1",
                    Description = "Api for managing all employees"
                });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            app.UseCors("AllowReactApp");
            app.UseAuthentication();
            app.UseAuthorization();

            // Call swagger service
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api/{documentName}/swagger.json";
            });

            // Call swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/employeesApi/swagger.json", "Emp Api");
                options.RoutePrefix = "";
            });

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature?.Error;

                    context.Response.StatusCode = 500; // Internal Server Error by default
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "An unexpected error occurred.",
                        DetailedMessage = exception?.Message,
                        ExceptionType = exception?.GetType().Name
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                });
            });

            app.MapControllers();
            app.MapGet("/newpage", () => "Hello World! from the new page");

            app.Run();
        }
    }
}
