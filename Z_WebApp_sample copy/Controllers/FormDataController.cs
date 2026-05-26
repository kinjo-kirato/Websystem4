using Microsoft.AspNetCore.Mvc;
/// <summary>
/// リスト3-3 
/// フォームデータを取得するコントローラ
/// </summary>
[Route("Form")]
public class FormDataController : Controller
{
    /// <summary>
    /// HTML Formに入力された値を出力する
    /// </summary>
    /// <param name="form">入力データを保持するViewModel</param>
    /// <returns></returns>
    [HttpPost("Enter")]
    public IActionResult InputData(SampleForm form)
    {
        return Content($"氏名:{form.Name} , 年齢:{form.Age}");
    }
}