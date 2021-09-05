using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Get {
	public class RegistrationGetDTO {
		public DateTime TimeStamp { get; set; }
		public string Name { get; set; }

		public RegistrationGetDTO(Registration registration) {
			TimeStamp = registration.TimeStamp;
			Name = registration.Name;
		}
	}
}
