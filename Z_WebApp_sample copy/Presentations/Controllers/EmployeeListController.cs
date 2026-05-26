using Microsoft.AspNetCore.Mvc;
using WebApp_Sample.Applications.Repositories;

namespace WebApp_Sample.Presentations.Controllers;

[Route("Employees")]
public class EmployeeListController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeListController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var employees = _employeeRepository.FindAll();
        return View(employees);
    }
}
