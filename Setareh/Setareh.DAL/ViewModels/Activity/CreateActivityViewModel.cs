

using System.ComponentModel.DataAnnotations;

namespace Setareh.DAL.ViewModels.Activity
{
    public class CreateActivityViewModel
    {
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "آیکون")]
        public string Icon { get; set; }
    }

    public enum CreateActivityResult
    {
        Success,
        Error
    }
}
