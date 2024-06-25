using Setareh.DAL.Models.Common;
using System.ComponentModel.DataAnnotations;


namespace Setareh.DAL.ViewModels.Skill
{
    public class FilterSkillViewModel:BasePaging<SkillDetailViewModel>
    {
        [Display(Name ="عنوان مهارت")]
        public string Title { get; set; }
    }
}
