using Pegasus.Data;
using Pegasus.Extensions;
using Pegasus.Models.Domain;
using Pegasus.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Data.Repositories {
	public class TrainerRepository : ITrainerRepository {
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Trainer> _trainers;

		public TrainerRepository(ApplicationDbContext dbContext) {
			_context = dbContext;
			_trainers = dbContext.Trainers;
		}

		public bool DoTrainersExist(IEnumerable<Trainer> trainers) {
			return trainers.All(e => _trainers.Contains(e));
		}

		public IEnumerable<Trainer> GetTrainers() {
			return _trainers.ToList();
		}

		public void SaveChanges() {
			_context.SaveChanges();
		}
	}
}
