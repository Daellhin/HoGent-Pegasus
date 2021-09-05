using Pegasus.Extensions;
using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Get {
	public class WeekGetDTO {
		public DateTime Start { get; set; }
		public string Message { get; set; }
		public ICollection<TrainingGetDTO> Trainings { get; set; }
		public bool HasPreviousWeek { get; set; }
		public bool HasNextWeek { get; set; }

		public WeekGetDTO(Week week, bool hasPreviousWeek, bool hasNextWeek) {
			Start = week.Start;
			Message = week.Message;
			Trainings = week.Trainings.Select(e => new TrainingGetDTO(e)).ToList();
			HasPreviousWeek = hasPreviousWeek;
			HasNextWeek = hasNextWeek;
		}

		public WeekGetDTO(int weekOffset, bool hasPreviousWeek, bool hasNextWeek) {
			Start = DateTime.Now.AddDays(7 * weekOffset).StartOfWeek(DayOfWeek.Monday);
			Message = "Er zijn (nog) geen trainingen voor deze week";
			Trainings = new List<TrainingGetDTO>();
			HasPreviousWeek = hasPreviousWeek;
			HasNextWeek = hasNextWeek;
		}

	}
}
