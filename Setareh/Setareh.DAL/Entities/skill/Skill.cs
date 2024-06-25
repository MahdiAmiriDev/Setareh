using Setareh.DAL.Entities.Common;


namespace Setareh.DAL.Entities.skill
{
    public class Skill: BaseEntity<int>
    {
        public string Title { get; set; }
        public int Percentage { get; set; }
    }
}
