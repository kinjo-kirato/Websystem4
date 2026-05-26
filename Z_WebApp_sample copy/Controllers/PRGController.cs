using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
/// <summary>
/// リスト5-2 PRGパターンとTempDataの利用
/// </summary>
[Route("PRG")]
public class PRGController : Controller
{
    /// <summary>
    /// 入力画面を出力する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new PRGForm();
        return View(form);
    }

    /// <summary>
    /// [送信]ボタンクリック
    /// Submit()メソッドに変更
    /// </summary>
    /// <param name="form">PRGForm</param>
    /// <returns></returns>
    [HttpPost("Submit")]
    public IActionResult Submit(PRGForm form)
    {
        // LoggerFactory を使って Logger を作成
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole(); // コンソール出力
        });
        ILogger logger = loggerFactory.CreateLogger("PRGController");
        // ログメッセージを表示する
        logger.LogInformation("[送信]ボタンクリック!!!");

        //　バリデーションチェック
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合、入力画面を表示する
            return View("Enter", form);
        }
        // PRGFormをJSON形式にシリアライズしてTempDataに登録する
        TempData["PRGForm"] = JsonSerializer.Serialize(form);
        // Resultアクションにリダイレクトする
        return RedirectToAction("Result");
    }

    /// <summary>
    /// 入力結果画面を表示する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Result")]
    public IActionResult Result()
    {
        // TempDataからシリアライズしたPRGFormを取り出す
        var json = (string)TempData["PRGForm"]!;
        if (string.IsNullOrEmpty(json))
        {
            // TempDataにPRGFormが存在しない場合、入力画面にリダイレクトする
            return RedirectToAction("Enter");
        }
        // PRGFormにデシリアライズする
        var form = JsonSerializer.Deserialize<PRGForm>(json!);
        // 入力された文字列の長さを取得する
        form!.Length = form.Text?.Length ?? 0;
        // 結果画面を表示する
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックに対するアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }
}