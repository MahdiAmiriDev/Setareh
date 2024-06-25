using System.ComponentModel.DataAnnotations;


namespace Setareh.DAL.ViewModels.Skill
{
    public class CreateSkillViewModel
    {
        [Display(Name = "عنوان مهارت")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "میزان مهارت")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public int Percentage { get; set; }
    }

    public enum CreateSkillResult
    {
        Success,
        Error
    }
}
