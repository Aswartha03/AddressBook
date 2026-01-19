using AddressBook.Core.Interfaces;
using AddressBook.Infrastructure.Data;
using AddressBook.Infrastructure.Repositories;
using AddressBook.Infrastructure.Services;
using AddressBook.Mappings;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace AddressBook
{
	public class Program
	{
		// Unit of work  
		// repo pattern 
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<IContactRepository, ContactRepository>();
			builder.Services.AddScoped<IContactService, ContactService>();
			builder.Services.AddAutoMapper(typeof(ContactMappingProfile).Assembly);
			var app = builder.Build();

			// Configure the HTTP request pipeline. 
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.MapFallback(() => Results.NotFound(new
			{
				message = "Route Not Found",
				status = 404
			}));
			app.Run();
		}
	}
}