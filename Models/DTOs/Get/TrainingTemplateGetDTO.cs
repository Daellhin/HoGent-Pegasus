using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Get {
	public class TrainingTemplateGetDTO {
		public int Id { get; private set; }
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartHour { get; set; }
		public DateTime EndHour { get; set; }
		public Group Group { get; set; }
		public ICollection<TrainerGetDTO> Trainers { get; set; }
		public ICollection<RegistrationGetDTO> Registrations { get; set; }

		public TrainingTemplateGetDTO(TrainingTemplate trainingTemplate) {
			Id = trainingTemplate.Id;
			DayOfWeek = trainingTemplate.DayOfWeek;
			StartHour = trainingTemplate.StartHour;
			EndHour = trainingTemplate.EndHour;
			Group = trainingTemplate.Group;
			Trainers = trainingTemplate.Trainers.Select(e => new TrainerGetDTO(e)).ToList();
			Registrations = new List<RegistrationGetDTO>();
		}
	}
}
