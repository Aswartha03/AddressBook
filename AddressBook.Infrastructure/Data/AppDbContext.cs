
using System.Collections.Generic;
using AddressBook.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Contact> Contacts { get; set; }
	}
}