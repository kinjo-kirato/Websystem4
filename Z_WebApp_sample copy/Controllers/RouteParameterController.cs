using Microsoft.AspNetCore.Mvc;
/// <summary>
/// リスト3-2
/// ルートパラメータを取得するコントローラ
/// </summary>
[Route("RouteParameter")]
public class RouteParameterController : Controller
{
    /// <summary>
    /// 取得したルートパラメータを返す
    /// </summary>
    /// <param name="value">ルートパラメータ</param>
    /// <returns></returns>
    [HttpGet("Param/{value}")]
    public IActionResult GetRouteParameter(int value)
    {
        if (!ModelState.IsValid)
        {
            return Content("パラメータが整数変換できません。");
        }
        return Content($"パラメータ:{value}");
    }
}