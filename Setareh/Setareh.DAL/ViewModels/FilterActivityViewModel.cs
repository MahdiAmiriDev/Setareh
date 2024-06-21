using Setareh.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.ViewModels
{
    public class FilterActivityViewModel: BasePaging<ActivityDetailViewModel>
    {
        [Display(Name ="عنوان")]
        public string? Title { get; set; }
    }
}
