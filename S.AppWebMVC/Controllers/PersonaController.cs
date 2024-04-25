using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S.AppWebMVC.Models.DTOs;
using S.BL.Services;
using S.EN;

namespace S.AppWebMVC.Controllers;

public class PersonaController : Controller
{
    private readonly IPersonService _personService;

    public PersonaController(IPersonService personService)
    {
        _personService = personService ?? throw new ArgumentNullException();
    }

    // GET: PersonaController
    public async Task<ActionResult> Index(string nombre)
    {
        try
        {
            IEnumerable<PersonaS> personas;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                personas = _personService.Search(nombre);
            } else
            {
                personas = await _personService.GetAll();
            }

            return View(personas);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return View();
        }
    }

    


    // GET: PersonaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PersonaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(PersonaS persona)
    {
        try
        {
            await _personService.Crear(persona);
            return RedirectToAction(nameof(Index));
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View();
        }
    }

    // GET: PersonaController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var persona = await _personService.GetById(id);
        return View(persona);
    }

    // POST: PersonaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(PersonaS persona)
    {
        try
        {
            int result = await _personService.Update(persona);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PersonaController/Delete/5
    public async Task<ActionResult> Delete()
    {
        int.TryParse(Request.Query["d"], out int id);

        var persona = await _personService.GetById(id);
        return View(persona);
    }

    // POST: PersonaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            int result = await _personService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // POST: PersonaController/Search
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Search(string nombre, string apellido)
    {
        try
        {
            var persona = _personService.Search(nombre);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
