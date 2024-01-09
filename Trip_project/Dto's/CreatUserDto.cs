using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Trip_project.Models.Dto_s
{
    public class CreatUserDto
    {
        [Required]
        [MinLength(2,ErrorMessage ="Too short please entre a name has more than 3 word")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Too short please entre a name has more than 3 word")]
        public string SecoundName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
       
    }
}
