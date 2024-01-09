using AutoMapper;
using Trip_project.Models;
using Trip_project.Models.Dto_s;

namespace Trip_project.Data
{
    public class Automapperprofil : Profile
    {
        public Automapperprofil() { 
        
        CreateMap<UpdateUserDTO,User>().ReverseMap();
        CreateMap<UserDto,User>().ReverseMap();
        CreateMap<CreatUserDto, User>().ReverseMap();
        CreateMap<PostDto, Post>().ReverseMap();
        CreateMap<CreatPostDto, Post>().ReverseMap();
        CreateMap<CreatPostDto, Post>().ReverseMap();
        CreateMap<UpdatPost, Post>().ReverseMap();


    }
    }
}
