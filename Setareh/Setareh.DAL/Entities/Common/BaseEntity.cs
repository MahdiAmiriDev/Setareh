

using System.ComponentModel.DataAnnotations;

namespace Setareh.DAL.Entities.Common
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }


        public DateTime CreateDate { get; set; }
    }
}
