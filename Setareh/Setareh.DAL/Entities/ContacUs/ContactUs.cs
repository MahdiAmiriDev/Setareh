using Setareh.DAL.Entities.Common;

namespace Setareh.DAL.Entities.ContacUs
{
    public class ContactUs:BaseEntity<int>
    {
        public string Title { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string? Answer { get; set; }
    }
}
