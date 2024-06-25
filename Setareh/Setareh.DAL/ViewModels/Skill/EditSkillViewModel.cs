
using System.ComponentModel.DataAnnotations;


namespace Setareh.DAL.ViewModels.Skill
{
    public class EditSkillViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان مهارت")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "میزان مهارت")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public int Percentage { get; set; }
    }

    public enum EditSkillResult
    {
        Success,
        Error,
        NotFound
    }
}
