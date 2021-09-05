using Pegasus.Models.Domain;
using Pegasus.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pegasus.Models.DTOs;
using Pegasus.Extensions;
using Pegasus.Models.DTOs.Get;

namespace Pegasus.Controllers {

	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiConventionType(typeof(DefaultApiConventions))]
	[ApiController]
	public class WeeksController : ControllerBase {

		private readonly IWeekRepository _weekRepository;

		public WeeksController(IWeekRepository weekRepository) {
			_weekRepository = weekRepository;
		}

		/// <summary>
		/// Gets current week, or week ofset by weekOffset
		/// </summary>
		/// <param name="weekOffset">Offset of week, negative = in the past, positive = in the future</param>
		/// <response code="200">Returns the week</response>
		[HttpGet("{weekOffset}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<WeekGetDTO> GetWeek(int weekOffset = 0) {
			Week week = _weekRepository.GetWeek(weekOffset);
			bool hasPreviousWeek = _weekRepository.HasPreviousWeek(weekOffset);
			bool hasNextWeek = _weekRepository.HasNextWeek(weekOffset);

			if (week == null) {
				return new WeekGetDTO(weekOffset, hasPreviousWeek, hasNextWeek);
			}
			return new WeekGetDTO(week, hasPreviousWeek, hasNextWeek);
		}

	}
}
