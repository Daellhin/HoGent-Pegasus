using Pegasus.Data;
using Pegasus.Models.Domain;
using Pegasus.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Data.Repositories {
	public class TrainingRepository : ITrainingRepository {
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Training> _trainings;

		public TrainingRepository(ApplicationDbContext dbContext) {
			_context = dbContext;
			_trainings = dbContext.Trainings;
		}

		public Training GetTraining(int id) {
			return _trainings.Include(t => t.Registrations).FirstOrDefault(t => t.Id == id);
		}

		public void SaveChanges() {
			_context.SaveChanges();
		}
	}
}
