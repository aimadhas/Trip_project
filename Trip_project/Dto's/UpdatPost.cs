using System.ComponentModel.DataAnnotations;

namespace Trip_project.Models.Dto_s
{
    public class UpdatPost
    {
        [Required]

        public Guid Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Too short please entre a name has more than 3 word")]
        public string Title { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Too short please entre a name has more than 10 word")]
        public string Descreption { get; set; }
        [Required]

        public Guid UserId { get; set; }


    }
}
