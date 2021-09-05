using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Post {
	public class TrainingTemplatePostDTO {

		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartHour { get; set; }
		public DateTime EndHour { get; set; }
		public Group Group { get; set; }
		public List<Trainer> Trainers { get; set; }

		public TrainingTemplate CreateDomainObject() {
			return new TrainingTemplate(DayOfWeek, StartHour, EndHour, Group, Trainers);
		}
	}
}
