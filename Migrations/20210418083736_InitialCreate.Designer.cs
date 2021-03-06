// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pegasus.Data;

namespace Pegasus.Migrations {
	[DbContext(typeof(ApplicationDbContext))]
	[Migration("20210418083736_InitialCreate")]
	partial class InitialCreate {
		protected override void BuildTargetModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("Relational:MaxIdentifierLength", 128)
				.HasAnnotation("ProductVersion", "5.0.5")
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Pegasus.Models.Domain.Registration", b => {
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("Name")
					.HasColumnType("nvarchar(max)");

				b.Property<DateTime>("TimeStamp")
					.HasColumnType("datetime2");

				b.Property<int?>("TrainingId")
					.HasColumnType("int");

				b.HasKey("Id");

				b.HasIndex("TrainingId");

				b.ToTable("Inschrijving");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.Trainer", b => {
				b.Property<string>("Name")
					.HasColumnType("nvarchar(450)");

				b.HasKey("Name");

				b.ToTable("Trainer");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.Training", b => {
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<int>("DayOfWeek")
					.HasColumnType("int");

				b.Property<DateTime>("EndHour")
					.HasColumnType("datetime2");

				b.Property<int>("Group")
					.HasColumnType("int");

				b.Property<DateTime>("StartHour")
					.HasColumnType("datetime2");

				b.Property<DateTime?>("WeekStart")
					.HasColumnType("datetime2");

				b.HasKey("Id");

				b.HasIndex("WeekStart");

				b.ToTable("Training");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.TrainingTemplate", b => {
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<int>("DayOfWeek")
					.HasColumnType("int");

				b.Property<DateTime>("EndHour")
					.HasColumnType("datetime2");

				b.Property<int>("Group")
					.HasColumnType("int");

				b.Property<DateTime>("StartHour")
					.HasColumnType("datetime2");

				b.Property<int?>("WeekTemplateId")
					.HasColumnType("int");

				b.HasKey("Id");

				b.HasIndex("WeekTemplateId");

				b.ToTable("TrainingTemplate");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.Week", b => {
				b.Property<DateTime>("Start")
					.HasColumnType("datetime2");

				b.Property<bool>("HasNextWeek")
					.HasColumnType("bit");

				b.Property<bool>("HasPreviousWeek")
					.HasColumnType("bit");

				b.HasKey("Start");

				b.ToTable("Week");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.WeekTemplate", b => {
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<bool>("Active")
					.HasColumnType("bit");

				b.Property<int>("DayOfGeneration")
					.HasColumnType("int");

				b.Property<DateTime>("TimeOfGeneration")
					.HasColumnType("datetime2");

				b.Property<int>("WeeksInAdvance")
					.HasColumnType("int");

				b.HasKey("Id");

				b.ToTable("WeekTemplate");
			});

			modelBuilder.Entity("TrainerTraining", b => {
				b.Property<string>("TrainersName")
					.HasColumnType("nvarchar(450)");

				b.Property<int>("TrainingsId")
					.HasColumnType("int");

				b.HasKey("TrainersName", "TrainingsId");

				b.HasIndex("TrainingsId");

				b.ToTable("TrainerTraining");
			});

			modelBuilder.Entity("TrainerTrainingTemplate", b => {
				b.Property<string>("TrainersName")
					.HasColumnType("nvarchar(450)");

				b.Property<int>("TrainingTemplatesId")
					.HasColumnType("int");

				b.HasKey("TrainersName", "TrainingTemplatesId");

				b.HasIndex("TrainingTemplatesId");

				b.ToTable("TrainerTrainingTemplate");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.Registration", b => {
				b.HasOne("Pegasus.Models.Domain.Training", null)
					.WithMany("Registrations")
					.HasForeignKey("TrainingId");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.Training", b => {
				b.HasOne("Pegasus.Models.Domain.Week", null)
					.WithMany("Trainings")
					.HasForeignKey("WeekStart");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.TrainingTemplate", b => {
				b.HasOne("Pegasus.Models.Domain.WeekTemplate", null)
					.WithMany("Trainings")
					.HasForeignKey("WeekTemplateId");
			});

			modelBuilder.Entity("TrainerTraining", b => {
				b.HasOne("Pegasus.Models.Domain.Trainer", null)
					.WithMany()
					.HasForeignKey("TrainersName")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Pegasus.Models.Domain.Training", null)
					.WithMany()
					.HasForeignKey("TrainingsId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("TrainerTrainingTemplate", b => {
				b.HasOne("Pegasus.Models.Domain.Trainer", null)
					.WithMany()
					.HasForeignKey("TrainersName")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Pegasus.Models.Domain.TrainingTemplate", null)
					.WithMany()
					.HasForeignKey("TrainingTemplatesId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});

			modelBuilder.Entity("Pegasus.Models.Domain.Training", b => {
				b.Navigation("Registrations");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.Week", b => {
				b.Navigation("Trainings");
			});

			modelBuilder.Entity("Pegasus.Models.Domain.WeekTemplate", b => {
				b.Navigation("Trainings");
			});
#pragma warning restore 612, 618
		}
	}
}
