using FinalExam.BL.Services.Abstractions;
using FinalExam.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.PL.Controllers;

public class HomeController : Controller
{
	readonly ICustomerService _customerService;

    public HomeController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
		try
		{
			HomeVM VM = new()
			{
				Customers = await _customerService.GetViewItemsAsync()
			};

			return View(VM);
		}
		catch (Exception)
		{
			return BadRequest("Something went wrong!");
		}
    }
}
