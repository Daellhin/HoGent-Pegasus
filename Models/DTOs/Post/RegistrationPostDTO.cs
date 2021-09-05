using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Models.DTOs.Post {
	public class RegistrationPostDTO {
		[Required]
		public string Name { get; set; }

		public Registration CreateDomainObject() {
			return new Registration(Name);
		}
	}
}
