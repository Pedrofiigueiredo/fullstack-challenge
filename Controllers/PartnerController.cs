using System.Collections.Generic;
using System.Threading.Tasks;
using Cotabox.Models;
using Cotabox.Repositories;
using Cotabox.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cotabox.Controllers
{
  [ApiController]
	[Route("v1/partners")]
	public class PartnerController : ControllerBase
	{
		private readonly PartnerRepository _repository;

		public PartnerController(PartnerRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("", Name = "GetPartner")]
		public async Task<ActionResult<List<Partner>>> Get() =>
			await _repository.Get();
		
		[HttpPost("")]
		public async Task<ActionResult<dynamic>> Create([FromBody]EditPartnerViewModel partner)
		{
			partner.Validate();
			if (partner.Invalid)
				return BadRequest(new { message = partner.Notifications });

			await _repository.Create(partner);

			return CreatedAtRoute("GetPartner", partner);
		}
	}
}
