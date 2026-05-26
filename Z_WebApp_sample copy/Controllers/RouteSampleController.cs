using Microsoft.AspNetCore.Mvc;
namespace WebApp_Sample.Controllers;
/// <summary>
/// リスト2-2
/// ルーティング属性を使用するコントローラ
/// </summary>  
[Route("samples")]
public class RouteSampleController : Controller
{
    /// <summary>
    /// デフォルトアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index()
    {
        return Content("/samples");
    }

    /// <summary>
    /// SampleContentアクション
    /// </summary>
    /// <returns></returns>
    [HttpPost("content")]
    public IActionResult SampleContent()
    {
        return Content("/samples/content");
    }
}