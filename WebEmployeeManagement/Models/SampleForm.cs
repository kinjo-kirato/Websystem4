using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
/// <summary>
/// リスト3-3 
/// フォームデータを保持するViewModel
/// </summary>
public class SampleForm
{
    /// <summary>
    /// 氏名プロパティ
    /// </summary>
    /// <value></value>
    [Display(Name = "氏名")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    public string? Name { get; set; }
    /// <summary>
    /// 年齢プロパティ
    /// </summary>
    /// <value></value>
    [Display(Name = "年齢")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 120, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int Age { get; set; }

    /// <summary>
    /// リスト4-4 HTML Formを作成するタグヘルパー
    /// </summary>

    /// <summary>
    /// 選択された結果を格納するプロパティ
    /// </summary>
    [Display(Name = "都道府県")]
    [Range(1, 3, ErrorMessage = "{0}を選択してください。")]
    public int PrefecturesId { get; set; }
    /// <summary>
    /// プルダウン表示するリスト
    /// </summary>
    /// <value></value>
    public List<SelectListItem> PrefecturesList { get; set; } = new List<SelectListItem>
    {
        new SelectListItem{ Text="--選択されていません--", Value="0" , Selected = true },
        new SelectListItem{ Text= "北海道", Value= "1" },
        new SelectListItem{ Text= "青森県", Value= "2" },
        new SelectListItem{ Text= "岩手県", Value= "3" },
    };
}