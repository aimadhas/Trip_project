using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trip_project.Interfaces;
using Trip_project.Midlleware;
using Trip_project.Models;
using Trip_project.Models.Dto_s;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trip_project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IPost ipostRepos;

        public PostController(IMapper _mapper, IPost ipostRepos)
        {
            mapper = _mapper;
            this.ipostRepos = ipostRepos;
        }


        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var post = await ipostRepos.GetAll();
            var PostDto = mapper.Map<List<PostDto>>(post);
            return Ok(PostDto);

        }


        // POST api/<PostController>
        [HttpPost]
        [ValidationClass]
        public async Task<IActionResult> CreatPost([FromBody] CreatPostDto postDto)
        {
            var Post = mapper.Map<Post>(postDto);
            var postcreated = await ipostRepos.CreatEntity(Post);
            var postdto = mapper.Map<PostDto>(postcreated);
            return Ok(postdto);

        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        [ValidationClass]
        public async Task<IActionResult> UpdatePost([FromRoute] Guid id, [FromBody] UpdatPost updatePostDto)
        {
            var post = mapper.Map<Post>(updatePostDto);
            var updatePost = await ipostRepos.UpdateEntity(id, post);
            if (updatePost == null)
            {
                return NotFound();
            }
            //var postDto = mapper.Map<PostDto>(updatePost);
            return Ok(updatePost);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await ipostRepos.DeleteEntity(id);
            if (post == null)
            {
                return NotFound();
            }
            var postDto = mapper.Map<PostDto>(post);
            return Ok(postDto);

        }
    }
}
