using Homework04.Models.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework04.Models.Repository
{
    [Table("User", Schema = "Test")]
    public sealed class User : BaseEntity<int>
    {
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
