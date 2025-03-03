using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Mehmet", Surname = "Deniz", Email = "mehmetdeniz@gmail.com" },
            new User { Id=2, Name="Ahmet",Surname="Yildiz",Email="ahmetyildiz@gmail.com"},
            new User { Id = 3, Name = "Veli", Surname = "Parlak", Email = "veliparlak@gmail.comn" }
        };

        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }
        [HttpGet("getByIdUsers")]
        public IActionResult GetByIdUsers(int id)
        {
            var value = users.Where(x => x.Id == id).FirstOrDefault();
            if (value == null)
            {
                return NotFound("Kullanici bulunamadi.");  
            }
            return Ok(value);
        }
        [HttpPost("createUser")]
        public IActionResult CreateUser(User item)
        {
            users.Add(item);
            return Ok(users);
        }
        [HttpPut("updateUser")]
        public IActionResult UpdateUser(User item)
        {
            var value = users.Where(x => x.Id == item.Id).FirstOrDefault();
            if(value == null)
            {
                return NotFound("Kullanici bulunamadi.");
            }
            value.Name = item.Name;
            value.Surname = item.Surname;
            value.Email = item.Email;
            return Ok(value);
        }
        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.Where(x => x.Id == id).FirstOrDefault();
            if(user == null)
            {
                return NotFound("Kullanici bulunamadi.");
            }
            users.Remove(user);
            return Ok("Kullanici silindi.");
        }
    }
}
