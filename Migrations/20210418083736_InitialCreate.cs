using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pegasus.Migrations {
	public partial class InitialCreate : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Trainer",
				columns: table => new {
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Trainer", x => x.Name);
				});

			migrationBuilder.CreateTable(
				name: "Week",
				columns: table => new {
					Start = table.Column<DateTime>(type: "datetime2", nullable: false),
					HasPreviousWeek = table.Column<bool>(type: "bit", nullable: false),
					HasNextWeek = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Week", x => x.Start);
				});

			migrationBuilder.CreateTable(
				name: "WeekTemplate",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Active = table.Column<bool>(type: "bit", nullable: false),
					DayOfGeneration = table.Column<int>(type: "int", nullable: false),
					TimeOfGeneration = table.Column<DateTime>(type: "datetime2", nullable: false),
					WeeksInAdvance = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_WeekTemplate", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Training",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DayOfWeek = table.Column<int>(type: "int", nullable: false),
					StartHour = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndHour = table.Column<DateTime>(type: "datetime2", nullable: false),
					Group = table.Column<int>(type: "int", nullable: false),
					WeekStart = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Training", x => x.Id);
					table.ForeignKey(
						name: "FK_Training_Week_WeekStart",
						column: x => x.WeekStart,
						principalTable: "Week",
						principalColumn: "Start",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "TrainingTemplate",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DayOfWeek = table.Column<int>(type: "int", nullable: false),
					StartHour = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndHour = table.Column<DateTime>(type: "datetime2", nullable: false),
					Group = table.Column<int>(type: "int", nullable: false),
					WeekTemplateId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_TrainingTemplate", x => x.Id);
					table.ForeignKey(
						name: "FK_TrainingTemplate_WeekTemplate_WeekTemplateId",
						column: x => x.WeekTemplateId,
						principalTable: "WeekTemplate",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Inschrijving",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					TrainingId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Inschrijving", x => x.Id);
					table.ForeignKey(
						name: "FK_Inschrijving_Training_TrainingId",
						column: x => x.TrainingId,
						principalTable: "Training",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "TrainerTraining",
				columns: table => new {
					TrainersName = table.Column<string>(type: "nvarchar(450)", nullable: false),
					TrainingsId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_TrainerTraining", x => new { x.TrainersName, x.TrainingsId });
					table.ForeignKey(
						name: "FK_TrainerTraining_Trainer_TrainersName",
						column: x => x.TrainersName,
						principalTable: "Trainer",
						principalColumn: "Name",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TrainerTraining_Training_TrainingsId",
						column: x => x.TrainingsId,
						principalTable: "Training",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TrainerTrainingTemplate",
				columns: table => new {
					TrainersName = table.Column<string>(type: "nvarchar(450)", nullable: false),
					TrainingTemplatesId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_TrainerTrainingTemplate", x => new { x.TrainersName, x.TrainingTemplatesId });
					table.ForeignKey(
						name: "FK_TrainerTrainingTemplate_Trainer_TrainersName",
						column: x => x.TrainersName,
						principalTable: "Trainer",
						principalColumn: "Name",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TrainerTrainingTemplate_TrainingTemplate_TrainingTemplatesId",
						column: x => x.TrainingTemplatesId,
						principalTable: "TrainingTemplate",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Inschrijving_TrainingId",
				table: "Inschrijving",
				column: "TrainingId");

			migrationBuilder.CreateIndex(
				name: "IX_TrainerTraining_TrainingsId",
				table: "TrainerTraining",
				column: "TrainingsId");

			migrationBuilder.CreateIndex(
				name: "IX_TrainerTrainingTemplate_TrainingTemplatesId",
				table: "TrainerTrainingTemplate",
				column: "TrainingTemplatesId");

			migrationBuilder.CreateIndex(
				name: "IX_Training_WeekStart",
				table: "Training",
				column: "WeekStart");

			migrationBuilder.CreateIndex(
				name: "IX_TrainingTemplate_WeekTemplateId",
				table: "TrainingTemplate",
				column: "WeekTemplateId");
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Inschrijving");

			migrationBuilder.DropTable(
				name: "TrainerTraining");

			migrationBuilder.DropTable(
				name: "TrainerTrainingTemplate");

			migrationBuilder.DropTable(
				name: "Training");

			migrationBuilder.DropTable(
				name: "Trainer");

			migrationBuilder.DropTable(
				name: "TrainingTemplate");

			migrationBuilder.DropTable(
				name: "Week");

			migrationBuilder.DropTable(
				name: "WeekTemplate");
		}
	}
}
