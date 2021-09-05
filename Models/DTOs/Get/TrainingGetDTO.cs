using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Get {
	public class TrainingGetDTO {
		public int Id { get; private set; }
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartHour { get; set; }
		public DateTime EndHour { get; set; }
		public Group Group { get; set; }
		public ICollection<TrainerGetDTO> Trainers { get; set; }
		public ICollection<RegistrationGetDTO> Registrations { get; set; }

		public TrainingGetDTO(Training training) {
			Id = training.Id;
			DayOfWeek = training.DayOfWeek;
			StartHour = training.StartHour;
			EndHour = training.EndHour;
			Group = training.Group;
			Trainers = training.Trainers.Select(e => new TrainerGetDTO(e)).ToList();
			Registrations = training.Registrations.Select(e => new RegistrationGetDTO(e)).ToList();
		}
	}
}
