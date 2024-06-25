using System.ComponentModel.DataAnnotations;

namespace Setareh.DAL.ViewModels.ContactUs
{
    public class CreateContactUsViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(350, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Title { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(13, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Mobile { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string FirstName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(350, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string LastName { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(1000, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Description { get; set; }

        public string? Answer { get; set; }
    }

    public enum CreateContactUsResult
    {
        Success,
        Error
    }
}
