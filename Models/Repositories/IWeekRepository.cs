using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;

namespace Pegasus.Models.Repositories {
	public interface IWeekRepository {

		Week GetWeek(int weekOffset);
		bool HasWeek(int weekOffset);
		bool HasPreviousWeek(int weekOffset);
		bool HasNextWeek(int weekOffset);
		void AddWeek(Week week);
		void SaveChanges();

	}
}
