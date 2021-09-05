using Pegasus.Data;
using Pegasus.Extensions;
using Pegasus.Models.Domain;
using Pegasus.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Data.Repositories {
	public class WeekRepository : IWeekRepository {
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Week> _weeks;

		public WeekRepository(ApplicationDbContext dbContext) {
			_context = dbContext;
			_weeks = dbContext.Weeks;
		}

		public Week GetWeek(int weekOffset) {
			DateTime startOfWeek = DateTime.Now.AddDays(7 * weekOffset).StartOfWeek(DayOfWeek.Monday);
			return _weeks.Where(e => e.Start.Date == startOfWeek.Date)
					.Include(e => e.Trainings).ThenInclude(e => e.Trainers)
					.Include(e => e.Trainings).ThenInclude(e => e.Registrations)
					.AsSingleQuery()
					.FirstOrDefault();
		}

		public bool HasWeek(int weekOffset) {
			DateTime startOfWeek = DateTime.Now.AddDays(7 * weekOffset).StartOfWeek(DayOfWeek.Monday);
			return _weeks.Any(e => e.Start.Date == startOfWeek.Date);
		}

		public bool HasPreviousWeek(int weekOffset) {
			DateTime startOfWeek = DateTime.Now.AddDays(7 * weekOffset).StartOfWeek(DayOfWeek.Monday);
			return _weeks.Any(e => e.Start < startOfWeek);
		}

		public bool HasNextWeek(int weekOffset) {
			DateTime startOfWeek = DateTime.Now.AddDays(7 * weekOffset).StartOfWeek(DayOfWeek.Monday);
			return _weeks.Any(e => e.Start > startOfWeek);
		}

		public void AddWeek(Week week) {
			_weeks.Add(week);
		}

		public void SaveChanges() {
			_context.SaveChanges();
		}

	}
}
