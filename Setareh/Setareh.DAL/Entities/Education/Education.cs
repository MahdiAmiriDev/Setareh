
using Setareh.DAL.Entities.Common;

namespace Setareh.DAL.Entities.Education
{
    public class Education : BaseEntity<int>
    {
        public string Title { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
        public string Description { get; set; }
    }
}
