
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Pegasus.Models.Domain {
	public class Training {
		public int Id { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartHour { get; set; }
		public DateTime EndHour { get; set; }
		public Group Group { get; set; }
		public ICollection<Trainer> Trainers { get; set; }
		public ICollection<Registration> Registrations { get; set; }

		public Training() {
			Registrations = new List<Registration>();
		}

		public Training(DayOfWeek day, DateTime startHour, DateTime endHour, Group group, ICollection<Trainer> trainers) : this() {
			DayOfWeek = day;
			StartHour = startHour;
			EndHour = endHour;
			Group = group;
			Trainers = trainers;
		}

		public void AddRegistration(Registration registration) {
			Registrations.Add(registration);
		}

		public Registration GetRegistration(int id) {
			return Registrations.SingleOrDefault(e => e.Id == id);
		}

		public override string ToString() {
			return $"{Id} {DayOfWeek} {StartHour:hh\\:mm}-{EndHour:hh\\:mm} {Group} {String.Join(" ", Trainers) }";
		}
	}
}
