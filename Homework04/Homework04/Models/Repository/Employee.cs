using System.ComponentModel.DataAnnotations.Schema;

namespace Homework04.Models.Repository
{
    [Table("Employee", Schema = "Test")]
    public sealed class Employee : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
    }
}
