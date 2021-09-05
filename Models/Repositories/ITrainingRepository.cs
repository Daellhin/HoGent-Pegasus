using Pegasus.Models.Domain;
using System.Collections.Generic;

namespace Pegasus.Models.Repositories {
	public interface ITrainingRepository {
		Training GetTraining(int id);
		void SaveChanges();
	}
}
