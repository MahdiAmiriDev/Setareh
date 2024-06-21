

using Setareh.DAL.Entities.Common;

namespace Setareh.DAL.Entities.AboutMe
{
    public class AboutMe : BaseEntity<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Position { get; set; }
        public DateOnly? birthDate { get; set; }
        public string? Location { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
