using System.ComponentModel.DataAnnotations;
/// <summary>
/// リスト5-2 PRGパターンとTempDataの利用
/// </summary>
public class PRGForm
{
    [Required(ErrorMessage = "{0}は必須です。")]
    [Display(Name = "入力文字列")]
    public string? Text { get; set; }
    public int Length { get; set; }
}