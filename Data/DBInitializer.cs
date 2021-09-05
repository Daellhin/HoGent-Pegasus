using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pegasus.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pegasus.Data {
	public class DBInitializer {
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public DBInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
			_context = context;
			_userManager = userManager;
		}

		public void MigrateDatabase() {
			_context.Database.Migrate();
			Console.WriteLine("Database migrated");
		}

		public void EnsureTemplatesCreated() {
			if (!_context.WeekTemplates.Any()) {
				CreateWeekTemplate();
				_context.SaveChanges();
				Console.WriteLine("Week Templates Created");
			}
		}

		public async Task InitializeData() {
			Console.WriteLine($"DataSource: {_context.Database.GetDbConnection().DataSource}");
			Console.WriteLine($"Database: {_context.Database.GetDbConnection().Database}");

			_context.Database.EnsureDeleted();
			Console.WriteLine("Database deleted");

			if (_context.Database.EnsureCreated()) {
				Console.WriteLine("Database created");

				// Create week template
				WeekTemplate weekTemplate = CreateWeekTemplate();

				// Create weeks
				Week week0 = weekTemplate.CreateWeek(-2);
				_context.Weeks.Add(week0);
				Week week1 = weekTemplate.CreateWeek(0);
				_context.Weeks.Add(week1);
				Week week2 = weekTemplate.CreateWeek();
				week2.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
				_context.Weeks.Add(week2);
				Week week3 = weekTemplate.CreateWeek(2);
				_context.Weeks.Add(week3);
				Week week4 = weekTemplate.CreateWeek(4);
				_context.Weeks.Add(week4);

				// Save changes to generate the Id keys of the trainings
				_context.SaveChanges();

				// Add registrations
				Training training10 = week1.Trainings.ElementAt(0);
				AddRegistrations(training10, new string[] {
					"Mats Andersen",
					"Luca D'hondt",
					"Toon van esbroeck",
					"Keny DAMART",
					"George Darie",
				});

				Training training11 = week1.Trainings.ElementAt(1);
				AddRegistrations(training11, new string[] {
					"Tibo Pollet",
					"Ray Impanis",
					"Laur Verheyden",
					"Raoul Verhaegen",
					"Raoul Verhaegen",
					"Adrien Van Vyve",
					"Victor mier y mier",
				});

				Training training12 = week1.Trainings.ElementAt(2);
				AddRegistrations(training12, new string[] {
					"Haeyley De Buck",
					"Glatt Manon",
					"Glatt Elisa",
					"Milo Van Schuerbeeck",
					"Lauren Geerinck",
					"Roselien De Proft",
					"Tess van der cammen",
					"Mit tierens",
					"Martin Shokouhi-Jah",
					"Flo van ongeval",
					"Tess van der cammen",
					"Ferris Scheers",
					"Walraevens Lise",
					"Suze Trossaert",
					"Okens Lise",
					"Maurine Van Vyve",
					"Louis",
					"Elinore Mier y Mier",
					"Lena Rochtus",
					"Zion Agnolo",
					"Hanne castenmiller",
				});

				Training training13 = week1.Trainings.ElementAt(3);
				AddRegistrations(training13, new string[] {
					"Naessens Louise",
					"Ella-Louise Brabants",
					"Xander Faes",
					"Imke Kempeneers",
					"Ruth van weverberg",
				});

				Training training14 = week1.Trainings.ElementAt(4);
				AddRegistrations(training14, new string[] {
					"Céleste Drieghe",
					"Joshua Rozo",
					"Jade Muyshondt",
					"Stan De Maeseneer",
					"Lente Pauwels",
				});

				Training training15 = week1.Trainings.ElementAt(5);
				AddRegistrations(training15, new string[] {
					"Juliette Naessens",
					"Marie-Lou Brabants",
					"Victor cauwenberghs",
					"Marthe Castenmiller",
				});

				Training training16 = week1.Trainings.ElementAt(6);
				AddRegistrations(training16, new string[] {
					"Céleste Drieghe",
					"Jade Muyshondt",
					"Lente Pauwels",
					"Seppe Brion",
				});

				Training training17 = week1.Trainings.ElementAt(7);
				AddRegistrations(training17, new string[] {
					"Wannes Gillis-D'Hamers",
					"Joppe Goubin",
					"Louise Rottiers",
				});

				Training training18 = week1.Trainings.ElementAt(8);
				AddRegistrations(training18, new string[] {
					"Naessens Louise",
					"Ella-Louise Brabants",
					"Ruth van weverberg",
				});

				Training training19 = week1.Trainings.ElementAt(9);
				AddRegistrations(training19, new string[] {
					"Mats Andersen",
					"Luca D'hondt",
					"Toon van esbroeck",
				});

				Training training20 = week2.Trainings.ElementAt(0);
				training20.AddRegistration(new Registration("Sterre De Maeyer"));

				await CreateUser("user@example.com", "Password1");

				// Save Changes
				_context.SaveChanges();

				Console.WriteLine("Database seeded");
			}
		}

		private WeekTemplate CreateWeekTemplate() {
			// Trainers
			Trainer kris = new("Kris");
			Trainer jorinde = new("Jorinde");
			Trainer hanne = new("Hanne");
			Trainer jeroen = new("Jeroen");
			Trainer helen = new("Helen");
			Trainer hans = new("Hans");
			Trainer marthe = new("Marthe");
			Trainer colette = new("Colette");
			Trainer jente = new("Jente");
			Trainer piet = new("Piet");
			Trainer lies = new("Lies");
			Trainer michiel = new("Michiel");

			// Training templates	
			TrainingTemplate training1 = new(DayOfWeek.Tuesday, new DateTime(1, 1, 1, 19, 30, 0), new DateTime(1, 1, 1, 21, 0, 0), Group.Spurters, new List<Trainer> { kris });
			TrainingTemplate training2 = new(DayOfWeek.Wednesday, new DateTime(1, 1, 1, 17, 30, 0), new DateTime(1, 1, 1, 18, 30, 0), Group.Kangoeroes, new List<Trainer> { jorinde, hanne });
			TrainingTemplate training3 = new(DayOfWeek.Wednesday, new DateTime(1, 1, 1, 17, 30, 0), new DateTime(1, 1, 1, 18, 30, 0), Group.Benjamins, new List<Trainer> { jeroen, helen });
			TrainingTemplate training4 = new(DayOfWeek.Wednesday, new DateTime(1, 1, 1, 19, 30, 0), new DateTime(1, 1, 1, 21, 0, 0), Group.Miniemen, new List<Trainer> { hans });
			TrainingTemplate training5 = new(DayOfWeek.Wednesday, new DateTime(1, 1, 1, 19, 30, 0), new DateTime(1, 1, 1, 21, 0, 0), Group.Cadetten, new List<Trainer> { marthe });
			TrainingTemplate training6 = new(DayOfWeek.Friday, new DateTime(1, 1, 1, 18, 0, 0), new DateTime(1, 1, 1, 19, 0, 0), Group.Pupillen, new List<Trainer> { colette, jente });
			TrainingTemplate training7 = new(DayOfWeek.Friday, new DateTime(1, 1, 1, 18, 0, 0), new DateTime(1, 1, 1, 19, 0, 0), Group.Cadetten, new List<Trainer> { marthe, helen });
			TrainingTemplate training8 = new(DayOfWeek.Friday, new DateTime(1, 1, 1, 18, 0, 0), new DateTime(1, 1, 1, 19, 0, 0), Group.Scholieren, new List<Trainer> { piet });
			TrainingTemplate training9 = new(DayOfWeek.Sunday, new DateTime(1, 1, 1, 10, 30, 0), new DateTime(1, 1, 1, 11, 30, 0), Group.Miniemen, new List<Trainer> { lies, michiel });
			TrainingTemplate training10 = new(DayOfWeek.Sunday, new DateTime(1, 1, 1, 10, 30, 0), new DateTime(1, 1, 1, 11, 30, 0), Group.Spurters, new List<Trainer> { kris });

			// Week templates
			WeekTemplate weekTemplate = new(true);
			weekTemplate.AddTraining(training1);
			weekTemplate.AddTraining(training2);
			weekTemplate.AddTraining(training3);
			weekTemplate.AddTraining(training4);
			weekTemplate.AddTraining(training5);
			weekTemplate.AddTraining(training6);
			weekTemplate.AddTraining(training7);
			weekTemplate.AddTraining(training8);
			weekTemplate.AddTraining(training9);
			weekTemplate.AddTraining(training10);

			_context.WeekTemplates.Add(weekTemplate);

			return weekTemplate;
		}

		private static void AddRegistrations(Training training, string[] names) {
			foreach (var name in names) {
				training.AddRegistration(new Registration(name));
			}
		}

		private async Task CreateUser(string email, string password) {
			var user = new IdentityUser { UserName = email, Email = email };
			await _userManager.CreateAsync(user, password);
		}
	}

}
