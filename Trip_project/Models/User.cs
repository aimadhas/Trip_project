namespace Trip_project.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecoundName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Post> Posts { get; set;}
    }
}
