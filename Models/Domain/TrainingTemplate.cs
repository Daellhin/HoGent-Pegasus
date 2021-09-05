using System;
using System.Collections.Generic;

namespace Pegasus.Models.Domain {
	public class TrainingTemplate {
		public int Id { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartHour { get; set; }
		public DateTime EndHour { get; set; }
		public Group Group { get; set; }
		public List<Trainer> Trainers { get; set; }

		public TrainingTemplate() {
		}

		public TrainingTemplate(DayOfWeek day, DateTime startHour, DateTime endHour, Group group, List<Trainer> trainers) : this() {
			DayOfWeek = day;
			StartHour = startHour;
			EndHour = endHour;
			Group = group;
			Trainers = trainers;
		}

		public Training CreateTraining() {
			return new Training(DayOfWeek, StartHour, EndHour, Group, Trainers);
		}

		public override string ToString() {
			return $"{Id} {DayOfWeek} {StartHour:hh\\:mm}-{EndHour:hh\\:mm} {Group} {String.Join(" ", Trainers)}";
		}

	}
}
