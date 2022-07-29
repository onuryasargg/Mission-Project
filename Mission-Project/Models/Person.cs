using Microsoft.AspNetCore.Mvc.Rendering; // Select List Item
using System.ComponentModel.DataAnnotations; //veri tipinin özelliklerini belirtmek için required gibi.

namespace Mission_Project.Models
{
    public class CheckBoxModel
    {
        public byte Value { get; set; }
        public string? Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        //[Required]
        //[Required(ErrorMessage = "Please, enter your age.")]
        //[Range(1,100, ErrorMessage ="Plase, assign 1 between 100")]
        //public byte Age { get; set; }
        //public List<CheckBoxModel>? Technologies { get; set; }
        [Required(ErrorMessage ="You must sign your ID.")]
        //[MaxLength(11, ErrorMessage = "Your ID must be 11 characters.")]
        [Range(10000000000, 99999999999, ErrorMessage = "Your Identity Number must be 11 characters.Not more or less.")]
        public long identityNumber { get; set; }
        //[Required(ErrorMessage = "How many work experience")]
        //public byte experiencedWork { get; set; }
    }
}
