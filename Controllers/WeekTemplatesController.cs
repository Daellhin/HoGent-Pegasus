using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pegasus.Models.Domain;
using Pegasus.Models.DTOs.Get;
using Pegasus.Models.DTOs.Post;
using Pegasus.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pegasus.Controllers {
	[ApiConventionType(typeof(DefaultApiConventions))]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class WeekTemplatesController : ControllerBase {

		private readonly IWeekTemplateRepository _weekTemplateRepository;
		private readonly IWeekRepository _weekRepository;
		private readonly ITrainerRepository _trainerRepository;

		public WeekTemplatesController(IWeekTemplateRepository weekTemplateRepository, IWeekRepository weekRepository, ITrainerRepository trainerRepository) {
			_weekTemplateRepository = weekTemplateRepository;
			_weekRepository = weekRepository;
			_trainerRepository = trainerRepository;
		}

		/// <summary>
		/// Gets active template
		/// </summary>
		/// <response code="200">Returns active template</response>
		/// <response code="404">No active template was found</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<WeekTemplateGetDTO> GetActiveTemplate() {
			WeekTemplate template = _weekTemplateRepository.GetActiveTemplate();
			if (template == null) {
				return NotFound();
			}

			return new WeekTemplateGetDTO(template);
		}

		/// <summary>
		/// Creates next week, or week ofset by weekOffset
		/// </summary>
		/// <param name="weekOffset">Offset of week to create, negative = in the past, positive = in the future</param>
		/// <response code="200">Returns the created week</response>
		/// <response code="400">Can't create week, a week already exists</response>
		/// <response code="404">Can't create week, there is no active week template</response>
		[HttpGet("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<WeekGetDTO> CreateWeek(int weekOffset = 1) {
			if (_weekRepository.HasWeek(weekOffset)) {
				return BadRequest();
			}

			WeekTemplate template = _weekTemplateRepository.GetActiveTemplate();
			if (template == null) {
				return NotFound();
			}

			Week week = template.CreateWeek(weekOffset);
			_weekRepository.AddWeek(week);
			_weekRepository.SaveChanges();

			return new WeekGetDTO(week, true, false);
		}

		[HttpGet("trainers")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IEnumerable<TrainerGetDTO> GetTrainers() {
			return _trainerRepository.GetTrainers().Select(e => new TrainerGetDTO(e));
		}

		[HttpGet("{weekTemplateId}/trainingTemplate/{trainingTemplateId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<TrainingTemplateGetDTO> GetTemplate(int weekTemplateId, int trainingTemplateId) {
			TrainingTemplate trainingTemplate = _weekTemplateRepository.GetTrainingTemplate(weekTemplateId, trainingTemplateId);
			if (trainingTemplate == null) {
				return NotFound();
			}
			return new TrainingTemplateGetDTO(trainingTemplate);
		}

		[HttpPost("{weekTemplateId}/trainingTemplate")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult PostTrainingTemplate(int weekTemplateId, TrainingTemplatePostDTO trainingTemplate) {
			if (!_trainerRepository.DoTrainersExist(trainingTemplate.Trainers)) {
				return BadRequest($"All traininers should already exist: (trainers: {String.Join(" ", trainingTemplate.Trainers)})");
			}

			TrainingTemplate createdTrainingTemplate = trainingTemplate.CreateDomainObject();
			_weekTemplateRepository.CreateTrainingTemplate(weekTemplateId, createdTrainingTemplate);
			_weekTemplateRepository.SaveChanges();

			return CreatedAtAction(nameof(GetTemplate), new { weekTemplateId = weekTemplateId, trainingTemplateId = createdTrainingTemplate.Id }, new TrainingTemplateGetDTO(createdTrainingTemplate));
		}

		[HttpPut("{weekTemplateId}/trainingTemplate/{trainingTemplateId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult PutTrainingTemplate(int weekTemplateId, int trainingTemplateId, TrainingTemplate trainingTemplate) {
			if (trainingTemplateId != trainingTemplate.Id) {
				return BadRequest($"IDs should be equal: (trainingTemplateId: {trainingTemplateId}) != (trainingTemplateId: {trainingTemplate.Id})");
			}

			if (!_trainerRepository.DoTrainersExist(trainingTemplate.Trainers)) {
				return BadRequest($"All traininers should already exist: (trainers: {String.Join(" ", trainingTemplate.Trainers)})");
			}
			_weekTemplateRepository.UpdateTrainingTemplate(weekTemplateId, trainingTemplate);
			_weekTemplateRepository.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{weekTemplateId}/trainingTemplate/{trainingTemplateId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteTrainingTemplate(int weekTemplateId, int trainingTemplateId) {
			TrainingTemplate trainingTemplate = _weekTemplateRepository.GetTrainingTemplate(weekTemplateId, trainingTemplateId);
			if (trainingTemplate == null) {
				return NotFound();
			}
			_weekTemplateRepository.DeleteTrainingTemplate(weekTemplateId, trainingTemplate);
			_weekTemplateRepository.SaveChanges();
			return NoContent();
		}

	}
}
