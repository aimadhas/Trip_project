namespace Trip_project.Models.Dto_s
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecoundName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
