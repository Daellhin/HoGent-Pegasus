using Pegasus.Data.Mapping;
using Pegasus.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Pegasus.Data {
	public class ApplicationDbContext : IdentityDbContext {

		public DbSet<Week> Weeks { get; set; }
		public DbSet<Training> Trainings { get; set; }
		public DbSet<WeekTemplate> WeekTemplates { get; set; }
		public DbSet<Trainer> Trainers { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
			modelBuilder.ApplyConfiguration(new TrainerConfiguration());
			modelBuilder.ApplyConfiguration(new TrainingConfiguration());
			modelBuilder.ApplyConfiguration(new TrainingTemplateConfiguration());
			modelBuilder.ApplyConfiguration(new WeekConfiguration());
			modelBuilder.ApplyConfiguration(new WeekTemplateConfiguration());
		}
	}
}
