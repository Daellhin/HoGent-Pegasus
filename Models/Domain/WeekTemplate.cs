using Pegasus.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pegasus.Models.Domain {
	public class WeekTemplate {
		public int Id { get; set; }
		public bool Active { get; set; }
		public ICollection<TrainingTemplate> Trainings { get; set; }

		public WeekTemplate() {
			Trainings = new List<TrainingTemplate>();
		}

		public WeekTemplate(bool active) : this() {
			Active = active;
		}

		public void AddTraining(TrainingTemplate training) {
			Trainings.Add(training);
		}

		public Week CreateWeek(int weekOffset = 1) {
			ICollection<Training> trainings = new List<Training>();
			foreach (var training in Trainings) {
				trainings.Add(training.CreateTraining());
			}
			return new Week(DateTime.Now.AddDays(7 * (weekOffset)).StartOfWeek(DayOfWeek.Monday), trainings);
		}

		public override string ToString() {
			return $"{Id} {Active} {String.Join("\n", Trainings)}";
		}

	}
}
