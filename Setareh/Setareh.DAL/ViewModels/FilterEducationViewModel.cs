using Setareh.DAL.Models.Common;
using System.ComponentModel.DataAnnotations;


namespace Setareh.DAL.ViewModels
{
    public class FilterEducationViewModel:BasePaging<EducationViewModel>
    {
        [Display(Name ="عنوان")]
        public string? Title { get; set; }

        [Display(Name = "تاریخ از")]
        public DateOnly? Start { get; set; }

        [Display(Name = "تاریخ تا")]
        public DateOnly? End { get; set; }
    }
}
