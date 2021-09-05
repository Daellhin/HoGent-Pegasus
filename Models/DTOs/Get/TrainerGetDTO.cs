using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Get {
	public class TrainerGetDTO {

		public string Name { get; set; }

		public TrainerGetDTO(Trainer trainer) {
			Name = trainer.Name;
		}
	}
}
