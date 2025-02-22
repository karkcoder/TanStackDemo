using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestApp.Model;

namespace TestApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "TestApp API",
					Version = "v1",
					Description = "A sample API to demonstrate OpenAPI integration"
				});
			});

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder
						.WithOrigins("http://localhost:5173") // Allow your frontend URL
						.AllowAnyHeader()
						.AllowAnyMethod());
			});

			// Add DbContext with SQL Server
			builder.Services.AddDbContext<InsuranceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("AllowSpecificOrigin");

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}