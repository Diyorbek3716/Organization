using Microsoft.AspNetCore.Mvc;
using StateInfo.Domain.DTOs;
using StateInfo.Domain.Models;
using StateOrganization.Models;
using StrateInfo.Application.Services;
using System.Diagnostics;

namespace StateOrganization.Controllers
{
	public class HomeController : Controller
	{
		private readonly IStateOrganizationService _organizationService;

		public HomeController(IStateOrganizationService organizationService)
		{
			_organizationService=organizationService;
		}

		public async Task<ActionResult<List<StateOrganizationAllDTO>>> GetAllOrganization()
		{
			var result= await _organizationService.GetAllOrganizationAsync();
			return View(result);
		}

		public async Task<IActionResult> Details(Guid id)
		{
			var organization= await _organizationService.GetByIdOrganization(id);
			if (organization == null)
			{
				return NotFound("id not found!");
			}

			return View(organization); 
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
