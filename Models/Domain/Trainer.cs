
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Pegasus.Models.Domain {
	public class Trainer {
		public string Name { get; set; }
		public ICollection<Training> Trainings { get; set; }
		public ICollection<TrainingTemplate> TrainingTemplates { get; set; }

		public Trainer(string name) {
			Name = name;
		}

		public override string ToString() {
			return $"{Name}";
		}

	}
}
