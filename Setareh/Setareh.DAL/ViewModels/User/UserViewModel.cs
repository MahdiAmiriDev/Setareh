using Setareh.DAL.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Setareh.DAL.ViewModels.User
{
    public class CreateUserModel
    {
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
        public int Id { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class UserFilterViewModel : BasePaging<UserDetailViewModel>
    {
        [Display(Name = "موبایل")]
        public string? Mobile { get; set; }
        [Display(Name = "ایمیل")]
        public string? Email { get; set; }
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
