using FinalExam.BL.DTOs;
using FinalExam.BL.Exceptions;
using FinalExam.BL.Services.Abstractions;
using FinalExam.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class AccountController : Controller
{
	readonly IAccountService _service;

	public AccountController(IAccountService service)
	{
		_service = service;
	}

	public IActionResult Login()
	{
		if (User.Identity is not null && User.Identity.IsAuthenticated)
			return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/");

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(UserLoginDTO dto, string? returnUrl = null)
	{
		if (!ModelState.IsValid)
			return View(dto);

		try
		{
			await _service.LoginAsync(dto);
			return Redirect(returnUrl ?? (User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/"));
		}
		catch (BaseException ex)
		{
			ModelState.AddModelError("CustomError", ex.Message);
			return View(dto);
		}
		catch (Exception)
		{
			ModelState.AddModelError("CustomError", "Something went wrong!");
			return View(dto);
		}
	}

	public IActionResult Register()
	{
		if (User.Identity is not null && User.Identity.IsAuthenticated)
			return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/");

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register(UserRegisterDTO dto)
	{
		if (!ModelState.IsValid)
			return View(dto);

		try
		{
			await _service.RegisterAsync(dto);
			return RedirectToAction(nameof(Login));
		}
		catch (BaseException ex)
		{
			ModelState.AddModelError("CustomError", ex.Message);
			return View(dto);
		}
		catch (Exception)
		{
			ModelState.AddModelError("CustomError", "Something went wrong!");
			return View(dto);
		}
	}

	public async Task<IActionResult> Logout()
	{
		try
		{
			await _service.LogoutAsync();
			return Redirect("/");
		}
		catch (Exception)
		{
			return BadRequest("Something went wrong!");
		}
	}
}
