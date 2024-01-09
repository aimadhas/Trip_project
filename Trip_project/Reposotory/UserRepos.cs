using Trip_project.Data;
using Trip_project.Interfaces;
using Trip_project.Models;

namespace Trip_project.Reposotory
{
    public class UserRepos :GenericReposClass<User>,Iuser
    {
        public UserRepos(TripdbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
