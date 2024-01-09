namespace Trip_project.Models.Dto_s
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Descreption { get; set; }

        public Guid UserId { get; set; }
    }
}
