using Microsoft.AspNetCore.Mvc;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.Repositories;
using WebApp_Sample.Exceptions;
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
        try
        {
            var departments = _departmentRepository.FindAll();
            return View(departments);
        }
        catch (InternalException e)
        {
            ViewBag.ErrorMessage = $"部署一覧を取得できませんでした。接続先DBを確認してください。詳細: {e.Message}";
            return View(new List<Department>());
        }
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

        try
        {
            var department = new Department(viewModel.Name);
            _departmentRepository.Create(department);
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException e)
        {
            ModelState.AddModelError(string.Empty, $"部署登録に失敗しました。接続先DBを確認してください。詳細: {e.Message}");
            return View(viewModel);
        }
    }
}
