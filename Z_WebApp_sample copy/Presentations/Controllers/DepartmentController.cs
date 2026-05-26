using Microsoft.AspNetCore.Mvc;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.Repositories;
using WebApp_Sample.Presentations.ViewModels;

namespace WebApp_Sample.Presentations.Controllers;

[Route("Departments")]
public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var departments = _departmentRepository.FindAll();
        return View(departments);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View(new DepartmentRegisterViewModel());
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(DepartmentRegisterViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var department = new Department(viewModel.Name);
        _departmentRepository.Create(department);
        return RedirectToAction(nameof(Index));
    }
}
