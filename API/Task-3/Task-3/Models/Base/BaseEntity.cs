using System.ComponentModel.DataAnnotations;

namespace Task_3.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
