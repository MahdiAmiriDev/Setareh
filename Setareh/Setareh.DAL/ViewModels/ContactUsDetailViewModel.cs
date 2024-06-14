using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.ViewModels
{
    public class ContactUsDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string? Answer { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
