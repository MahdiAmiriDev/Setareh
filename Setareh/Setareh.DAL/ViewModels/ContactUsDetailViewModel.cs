using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.ViewModels
{
    public class ContactUsDetailViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Mobile { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }

        [Display(Name ="پاسخ")]
        [Required(ErrorMessage ="لطفا مقدار {0} را وارد نمایید.")]
        public string? Answer { get; set; }

        public DateTime CreateDate { get; set; }
    }

    public enum AnswerResult
    {
        Success,
        ContactUsNotFound,
        Error,
        AnswerIsNull
    }
}
