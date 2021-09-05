using Pegasus.Models.Domain;

namespace Pegasus.Models.Repositories {
	public interface IWeekTemplateRepository {
		WeekTemplate GetActiveTemplate();
		TrainingTemplate GetTrainingTemplate(int weekTemplatteID, int trainingTemplateId);
		void CreateTrainingTemplate(int weekTemplateId, TrainingTemplate trainingTemplate);
		void UpdateTrainingTemplate(int weekTemplateId, TrainingTemplate trainingTemplate);
		void DeleteTrainingTemplate(int weekTemplateId, TrainingTemplate trainingTemplate);
		void SaveChanges();
	}
}
