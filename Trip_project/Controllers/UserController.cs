using AutoMapper;
using Azure.Core.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Text.Json;
using Trip_project.Data;
using Trip_project.Interfaces;
using Trip_project.Midlleware;
using Trip_project.Models;
using Trip_project.Models.Dto_s;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trip_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuser repos;
        private readonly IMapper mapper;
       
        public UserController(Iuser repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var data = await repos.GetAll();
            return Ok(mapper.Map<List<UserDto>>(data));
           
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid([FromRoute] Guid id)
        {
           var user =await repos.GetById(id);
            if(user == null)
            {
                return NotFound();
            }
            var userDto = mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        // POST api/<UserController>
        [HttpPost]
        [ValidationClass]
        public async Task<IActionResult> AddUser([FromBody] CreatUserDto creatUSER)
        {
            var user = mapper.Map<User>(creatUSER);
            await repos.CreatEntity(user);
            var userdto = mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(Getbyid), new { id = userdto.Id }, userdto);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ValidationClass]

        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDTO userDto)
        {
            var user = mapper.Map<User>(userDto);
           var user2 = await repos.UpdateEntity(id,user);
            if (user2 == null)
            {
                return NotFound();
            }
            var userDto1 = mapper.Map<UserDto>(user2);
            return Ok(userDto1);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var user = await repos.DeleteEntity(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(user));
        }
    }
}
