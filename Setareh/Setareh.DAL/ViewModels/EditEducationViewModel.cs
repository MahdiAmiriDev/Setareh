
using System.ComponentModel.DataAnnotations;


namespace Setareh.DAL.ViewModels
{
    public class EditEducationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage ="لطفا مقدار {0} را وارد کنید")]
        public string? Title { get; set; }

        [Display(Name = "تاریخ از")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public DateOnly Start { get; set; }

        [Display(Name = "تاریخ تا")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public DateOnly? End { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string Description { get; set; }
    }

    public enum EditEducationResult
    {    
        Success,
        Error,
        NotFound
    }
}
