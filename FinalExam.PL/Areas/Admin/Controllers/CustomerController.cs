using FinalExam.BL.DTOs;
using FinalExam.BL.Exceptions;
using FinalExam.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalExam.PL.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CustomerController : Controller
{
    readonly ICustomerService _service;
    readonly IProfessionService _professionService;

    public CustomerController(ICustomerService service, IProfessionService professionService)
    {
        _service = service;
        _professionService = professionService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _service.GetListItemsAsync());
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");

            return View();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");

            return View(dto);
        }

        try
        {
            await _service.CreateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Update(int id)
    {
        try
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");
            CustomerUpdateDTO customer = await _service.GetByIdForUpdateAsync(id);

            return View(customer);
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CustomerUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");

            return View(dto);
        }

        try
        {
            await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["Professions"] = new SelectList(await _professionService.GetListItemsAsync(), "Id", "Title");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            return View(await _service.GetByIdAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
}
