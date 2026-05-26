using Microsoft.AspNetCore.Mvc;
using WebApp_Sample.Applications.Repositories;
using WebApp_Sample.Exceptions;

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
        try
        {
            var employees = _employeeRepository.FindAll();
            return View(employees);
        }
        catch (InternalException e)
        {
            ViewBag.ErrorMessage = $"従業員一覧を取得できませんでした。接続先DBを確認してください。詳細: {e.Message}";
            return View(new List<WebApp_Sample.Applications.Domains.Employee>());
        }
    }
}
