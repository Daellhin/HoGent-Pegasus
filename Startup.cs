using Pegasus.Data;
using Pegasus.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeApi.Data.Repositories;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Linq;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Pegasus {
	public class Startup {

		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers();

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration => {
				configuration.RootPath = "client/dist/client";
			});

			services.AddDbContext<ApplicationDbContext>(options => {
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped<DBInitializer>();
			services.AddScoped<IWeekRepository, WeekRepository>();
			services.AddScoped<IWeekTemplateRepository, WeekTemplateRepository>();
			services.AddScoped<ITrainingRepository, TrainingRepository>();
			services.AddScoped<ITrainerRepository, TrainerRepository>();

			services.AddIdentity<IdentityUser, IdentityRole>(cfg => cfg.User.RequireUniqueEmail = true).AddEntityFrameworkStores<ApplicationDbContext>();

			services.Configure<IdentityOptions>(options => {
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 8;
				options.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = true;
			});

			services.AddAuthentication(x => {
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x => {
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters {
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
								  Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
					ValidateIssuer = false,
					ValidateAudience = false,
					RequireExpirationTime = true //Ensure token hasn't expired
				};
			});

			services.AddOpenApiDocument(c => {
				c.DocumentName = "apidocs";
				c.Title = "Training API";
				c.Version = "v1";
				c.Description = "Training API documentation.";
				c.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme {
					Type = OpenApiSecuritySchemeType.ApiKey,
					Name = "Authorization",
					In = OpenApiSecurityApiKeyLocation.Header,
					Description = "Type into the textbox: Bearer {your JWT token}."
				});

				c.OperationProcessors.Add(
					new AspNetCoreOperationSecurityScopeProcessor("JWT")); //adds the token when a request is send
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DBInitializer dbInitializer) {
			Console.WriteLine($"Environement: {env.EnvironmentName}");
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseStatusCodePages();
				dbInitializer.InitializeData().Wait();
			}
			else {
				app.UseSpaStaticFiles();
				dbInitializer.MigrateDatabase();
				dbInitializer.EnsureTemplatesCreated();
			}

			app.UseStaticFiles();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});

			app.UseSpa(spa => {
				spa.Options.SourcePath = "client";

				if (env.IsDevelopment()) {
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}
