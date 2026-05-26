using Microsoft.AspNetCore.Mvc;
/// <summary>
/// リスト4-3 
/// Razor構文の利用
/// </summary>
[Route("Razor")]
public class RazorSyntaxSampleController : Controller
{
    /// <summary>
    /// ViewModel SampleFormのListをRazor View Show.cshtmlに渡す
    /// </summary>
    /// <returns></returns>
    [HttpGet("ShowData")]
    public ActionResult Show()
    {
        var list = new List<SampleForm>();
        list.Add(new SampleForm { Name = "山田太郎", Age = 25 });
        list.Add(new SampleForm { Name = "鈴木花子", Age = 23 });
        list.Add(new SampleForm { Name = "田中次郎", Age = 26 });
        list.Add(new SampleForm { Name = "佐藤かおり", Age = 25 });
        ViewData["list"] = list;
        //return View(list);
        return View();
    }
}