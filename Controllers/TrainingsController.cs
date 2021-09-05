using Pegasus.Models.Domain;
using Pegasus.Models.DTOs;
using Pegasus.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Pegasus.Models.DTOs.Get;
using Pegasus.Models.DTOs.Post;

namespace Pegasus.Controllers {
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiConventionType(typeof(DefaultApiConventions))]
	[ApiController]
	public class TrainingsController : ControllerBase {

		private readonly ITrainingRepository _trainingRepository;

		public TrainingsController(ITrainingRepository trainingRepository) {
			_trainingRepository = trainingRepository;
		}

		/// <summary>
		/// Gets a registration of a training
		/// </summary>
		/// <param name="trainingId">Id of the training</param>
		/// <param name="registrationId">Id of the registration</param>
		/// <response code="200">Returns the registration</response>
		/// <response code="404">No training with trainingId or registration with registrationId exists</response>
		[HttpGet("{trainingId}/registrations/{registrationId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<RegistrationGetDTO> GetRegistration(int trainingId, int registrationId) {
			Training training = _trainingRepository.GetTraining(trainingId);
			if (training == null) {
				return NotFound();
			}
			Registration registration = training.GetRegistration(registrationId);
			if (registration == null) {
				return NotFound();
			}
			return new RegistrationGetDTO(registration);
		}

		/// <summary>
		/// Adds an registration to a training
		/// </summary>
		/// <param name="trainingId">The id of the training</param>
		/// <param name="registration">The registration to be added</param>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="404">No training with trainingId exists</response>
		[HttpPost("{trainingId}/registrations")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<RegistrationGetDTO> PostRegistration(int trainingId, RegistrationPostDTO registration) {
			Training training = _trainingRepository.GetTraining(trainingId);
			if (training == null) {
				return NotFound();
			}

			Registration createdRegistration = registration.CreateDomainObject();
			training.AddRegistration(createdRegistration);
			_trainingRepository.SaveChanges();

			return CreatedAtAction(nameof(GetRegistration), new { trainingId = training.Id, registrationId = createdRegistration.Id }, createdRegistration);
		}

	}
}
