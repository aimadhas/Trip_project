using Trip_project.Data;
using Trip_project.Interfaces;
using Trip_project.Models;

namespace Trip_project.Reposotory
{
    public class PostRepos : GenericReposClass<Post>, IPost
    {
        public PostRepos(TripdbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
