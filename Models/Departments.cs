using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Departments
    {
        [Key]
       public int ID { get; set; }

        [Required]
       public string Department { get; set; }


    }
}
