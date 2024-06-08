

using System.ComponentModel.DataAnnotations;

namespace Setareh.DAL.ViewModels
{
    public class CreateUserModel
    {
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [StringLength(350,ErrorMessage ="تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string LastName { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(15, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Mobile { get; set; }

        [Display(Name = "نام")]
        [StringLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FirstName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Password { get; set; }

        [Display(Name = "فعال است ؟")]
        public bool IsActive { get; set; }
    }

    public class UserEditModel
    {

        public int Id { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(350, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string LastName { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(15, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string Mobile { get; set; }

        [Display(Name = "نام")]
        [StringLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FirstName { get; set; }

        [Display(Name = "فعال است ؟")]
        public bool IsActive { get; set; }
    }

    public class UserDetailViewModel
    {

    }

    public class UserFilterViewModel
    {

    }

    public enum CreateUserResult
    {
        Success,
        Error
    }

    public enum EditUserResult
    {
        Success,
        Error,
        UserNotFound,
        EmailDuplicated,
        MobileDuplicated
    }
}
