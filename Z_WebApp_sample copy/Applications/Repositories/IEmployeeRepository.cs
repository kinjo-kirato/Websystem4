using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:従業員のCRUD操作インターフェイス
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// 従業員を永続化する
    /// </summary>
    /// <param name="employee">永続化対象の従業員</param>
    void Create(Employee employee);

    /// <summary>
    /// すべての従業員を取得する
    /// </summary>
    /// <returns>従業員リスト</returns>
    List<Employee> FindAll();
}
