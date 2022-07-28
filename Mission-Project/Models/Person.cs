using System.ComponentModel.DataAnnotations; //veri tipinin özelliklerini belirtmek için required gibi.

namespace Mission_Project.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Range (0,100)]

        [Required(ErrorMessage = "Please enter your age")]
        public byte age { get; set; }
        //[Required(ErrorMessage = "Choose your technologies")]
        //public string[] technologies { get; set; }
        //[Required(ErrorMessage = "Text your identityNumber")]
        //[MaxLength (11)]
        //[MinLength (11)]
        //public long identityNumber { get; set; }
        //[Required(ErrorMessage = "How many work experience")]
        //public byte experiencedWork { get; set; }
    }
}
