using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDatabase
{
    [Table(name: "Persons")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Column(name:"Name")]
        [Required(ErrorMessage = "Not column")]
        public string? FirstName { get; set; }

        [MaxLength(5, ErrorMessage = "Limit higher")]
        public string? LastName { get; set; }


        public int? EmployeeId { get; set; } 

        public Employee? Employee { get; set; }

        public int? AddressId { get; set; }

        public Address? Address { get; set; }


    }
}
