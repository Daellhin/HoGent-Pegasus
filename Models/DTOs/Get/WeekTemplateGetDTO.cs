using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Get {
	public class WeekTemplateGetDTO {
		public int Id { get; set; }
		public bool Active { get; set; }
		public ICollection<TrainingTemplateGetDTO> Trainings { get; set; }

		public WeekTemplateGetDTO(WeekTemplate weekTemplate) {
			Id = weekTemplate.Id;
			Active = weekTemplate.Active;
			Trainings = weekTemplate.Trainings.Select(e => new TrainingTemplateGetDTO(e)).ToList();
		}
	}
}
