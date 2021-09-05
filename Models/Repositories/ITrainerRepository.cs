using Pegasus.Models.Domain;
using System.Collections.Generic;

namespace Pegasus.Models.Repositories {
	public interface ITrainerRepository {
		bool DoTrainersExist(IEnumerable<Trainer> trainers);
		IEnumerable<Trainer> GetTrainers();
		void SaveChanges();
	}
}
