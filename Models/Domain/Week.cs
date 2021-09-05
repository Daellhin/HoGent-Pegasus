using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.Domain {
	public class Week {
		public DateTime Start { get; set; }
		public string Message { get; set; }
		public ICollection<Training> Trainings { get; set; }

		public Week() {
		}

		public Week(DateTime start, ICollection<Training> trainings) : this() {
			Start = start.Date;
			Trainings = trainings;
		}

		public override string ToString() {
			return $"{Start} {Message} {String.Join("\n", Trainings)}";
		}

	}
}
