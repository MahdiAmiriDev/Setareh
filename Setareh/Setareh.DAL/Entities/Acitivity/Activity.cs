using Setareh.DAL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Entities.Acitivity
{
    public class Activity:BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

    }
}
