using FinalExam.BL.DTOs;
using FinalExam.BL.Exceptions;
using FinalExam.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.PL.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProfessionController : Controller
{
    readonly IProfessionService _service;

    public ProfessionController(IProfessionService service)
    {
        _service = service;
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProfessionCreateDTO dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        try
        {
            await _service.CreateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
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

    public async Task<IActionResult> Update(int id)
    {
        try
        {
            return View(await _service.GetByIdForUpdateAsync(id));
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
    public async Task<IActionResult> Update(ProfessionUpdateDTO dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        try
        {
            await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
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
            return View(await _service.GetByIdWithChildrenAsync(id));
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
