using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//With Data Anotations We can do complex validations in one line 

namespace WebApplicationMVC.Models
{
    public class Student
    {

      //**1**
      [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

      //**2**
      [Required(ErrorMessage ="This feild is Required")]
      public string Name { get; set; }

        //Required is called as Annotation which is Present in System.ComponentModel.DataAnnotation Namespace For using it we have to import that namespace first
        // Required anotaion is usefull while getting the essential data from the end user
        //We also can pass error message in the required anotaion aregument

      //**3**
      [Required(ErrorMessage ="Required")]
        //[StringLength()]
      public string lastname { get; set; }


      //**4**
      [Required(ErrorMessage = "This Feild is Required")]
      [DataType(DataType.EmailAddress)]
        
      public string Email { get; set; }

        //Here above we have use another anotation DataType(Datatype.EmailAddress) which is also present in the System.ComponentModel.DataAnnotation Namespce use for the Data Validation at the runtime at user end
        //We have Email data validation aslo have the Phone number validation [DataType(DataType.PhoneNumner)]


      //**5**
      [Required]
      [DataType(DataType.PhoneNumber)]
      public string Mobile { get; set; }

      //**6**
      [Required]
      [Display(Name="Department")]
      public int DeptID { get; set; }


      //**7**
      [NotMapped]
      public string Department { get; set; }

     public string Description { get; set; }





     

    }
}
