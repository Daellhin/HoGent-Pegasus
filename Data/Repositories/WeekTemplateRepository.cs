using Microsoft.EntityFrameworkCore;
using Pegasus.Data;
using Pegasus.Models.Domain;
using Pegasus.Models.Repositories;
using System.Linq;

namespace RecipeApi.Data.Repositories {
	public class WeekTemplateRepository : IWeekTemplateRepository {
		private readonly ApplicationDbContext _context;
		private readonly DbSet<WeekTemplate> _weekTemplates;

		public WeekTemplateRepository(ApplicationDbContext dbContext) {
			_context = dbContext;
			_weekTemplates = dbContext.WeekTemplates;
		}

		public WeekTemplate GetActiveTemplate() {
			return _weekTemplates.Where(e => e.Active)
					.Include(e => e.Trainings)
					.ThenInclude(e => e.Trainers)
					.SingleOrDefault();
		}

		public WeekTemplate GetTemplate(int id) {
			return _weekTemplates.Where(e => e.Id == id)
					.Include(e => e.Trainings)
					.ThenInclude(e => e.Trainers)
					.SingleOrDefault();
		}

		public TrainingTemplate GetTrainingTemplate(int weekTemplateId, int trainingTemplateId) {
			return _weekTemplates.Where(e => e.Id == weekTemplateId)
					.SelectMany(e => e.Trainings)
					.Include(e => e.Trainers)
					.Where(e => e.Id == trainingTemplateId)
					.SingleOrDefault();
		}

		public void CreateTrainingTemplate(int weekTemplateId, TrainingTemplate trainingTemplate) {
			WeekTemplate weekTemplate = GetActiveTemplate();
			trainingTemplate.Trainers = _context.Trainers.Where(e => trainingTemplate.Trainers.Contains(e)).ToList();
			weekTemplate.AddTraining(trainingTemplate);
		}

		public void UpdateTrainingTemplate(int weekTemplateId, TrainingTemplate trainingTemplate) {
			TrainingTemplate trainingTemplateDB = GetTrainingTemplate(weekTemplateId, trainingTemplate.Id);

			trainingTemplateDB.Trainers.AddRange(_context.Trainers.Where(e => trainingTemplate.Trainers.Contains(e)).ToList());
			trainingTemplateDB.Trainers.RemoveAll(j => !trainingTemplate.Trainers.Any(e => e.Name == j.Name));
			trainingTemplateDB.DayOfWeek = trainingTemplate.DayOfWeek;
			trainingTemplateDB.StartHour = trainingTemplate.StartHour;
			trainingTemplateDB.EndHour = trainingTemplate.EndHour;
			trainingTemplateDB.Group = trainingTemplate.Group;
		}

		public void DeleteTrainingTemplate(int weekTemplateId, TrainingTemplate trainingTemplate) {
			_weekTemplates.Where(e => e.Id == weekTemplateId)
					.Include(e => e.Trainings)
					.Single()
					.Trainings
					.Remove(trainingTemplate);
		}


		public void SaveChanges() {
			_context.SaveChanges();
		}

	}
}
