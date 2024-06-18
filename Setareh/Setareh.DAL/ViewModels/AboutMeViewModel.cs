using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.ViewModels
{
    public class AboutMeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(100, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string? FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(100, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string? LastName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(200, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string? Mobile { get; set; }
        [Display(Name = "سمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(100, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string? Position { get; set; }
        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateOnly? BirthDate { get; set; }
        [Display(Name = "محل زندگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(13, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد")]
        public string? Location { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }
    }
}
