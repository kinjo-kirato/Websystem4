using System.ComponentModel.DataAnnotations;

namespace WebApp_Sample.Presentations.ViewModels;

public class DepartmentRegisterViewModel
{
    [Display(Name = "部署名")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [StringLength(20, ErrorMessage = "{0}は{1}文字以内で入力してください。")]
    public string Name { get; set; } = string.Empty;
}
