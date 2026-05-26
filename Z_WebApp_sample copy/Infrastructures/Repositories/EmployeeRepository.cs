using Microsoft.EntityFrameworkCore;
using WebApp_Sample.Infrastructures.Context;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.Repositories;
using WebApp_Sample.Infrastructures.Adapters;
using WebApp_Sample.Exceptions;
namespace WebApp_Sample.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:従業員のCRUD操作インターフェイスの実装
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    /// <summary>
    /// アプリケーション用DbContext
    /// </summary>
    private readonly AppDbContext _context;
    /// <summary>
    /// ドメインモデル:従業員と従業員エンティティの相互変換インターフェイスの実装
    /// </summary>
    private readonly EmployeeEntityAdapter _employeeAdapter;
    /// <summary>
    /// ドメインモデル:部署と部署エンティティの相互変換インターフェイスの実装
    /// </summary>
    private readonly DepartmentEntityAdapter _departmentAdapter;

    public EmployeeRepository(
        AppDbContext context,
        EmployeeEntityAdapter employeeAdapter,
        DepartmentEntityAdapter departmentAdapter)
    {
        _context = context;
        _employeeAdapter = employeeAdapter;
        _departmentAdapter = departmentAdapter;
    }

    public void Create(Employee employee)
    {
        try
        {
            var entity = _employeeAdapter.Convert(employee);
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new InternalException(
                "従業員の永続化ができませんでした。", e);
        }
    }

    public List<Employee> FindAll()
    {
        try
        {
            var departmentMap = _context.Departments
                .AsNoTracking()
                .ToDictionary(d => d.DeptId, d => _departmentAdapter.Restore(d));

            var employees = _context.Employees.AsNoTracking().ToList();
            var results = new List<Employee>();
            foreach (var entity in employees)
            {
                Department? department = null;
                if (entity.DeptId.HasValue && departmentMap.TryGetValue(entity.DeptId.Value, out var dept))
                {
                    department = dept;
                }
                results.Add(new Employee(entity.EmpId, entity.EmpName, department));
            }
            return results;
        }
        catch (Exception e)
        {
            throw new InternalException("従業員一覧を取得できませんでした。", e);
        }
    }
}
