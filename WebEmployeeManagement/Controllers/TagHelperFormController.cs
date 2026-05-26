using Microsoft.AspNetCore.Mvc;
/// <summary>
/// タグヘルパーを利用するコントローラ
/// </summary>
[Route("FormSample")]
public class TagHelperFormController : Controller
{
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        // SampleFormを生成する
        var form = new SampleForm();
        // Enter.cshtmlにSampleFormを渡す
        return View(form);
    }

    /// <summary>
    /// [送信]ボタンクリックに対するアクション
    /// </summary>
    /// <param name="form">入力された値を保持するSampleForm</param>
    /// <returns></returns>
    [HttpPost("Result")]
    public IActionResult Result(SampleForm form)
    {
        // バリデーションチェック
        if (!ModelState.IsValid)
        {
            // 入力画面にリダイレクトする
            return RedirectToAction("Enter");
        }
        return View(form);
    }
    /// <summary>
    /// [戻る]ボタンクリックに対するアクション
    /// </summary>
    /// <param name="form">入力された値を保持するSampleForm</param>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back(SampleForm form)
    {
        // 入力画面を出力する
        return View("Enter", form);
    }
}