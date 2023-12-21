using Calendar.Api.DTO.Commands;
using Calendar.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Calendar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private static List<User> users = new();
        

        // TODO: read users from file 
        //string json = File.ReadAllText("myobjects.json");
        //var playerList = JsonConvert.DeserializeObject<List<Player>>(json);

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public IResult Login(UserCommand user)
        {
            var logedInUser = users.Find(u => u.UserId == user.UserId && u.Password == user.Password);
            if (logedInUser == null)
            {
                return Results.Unauthorized();
            }
            return Results.Ok(logedInUser);
        }


        [HttpPost]
        [Route("Register")]
        public IResult Register(User newUser)
        {
            users.Add(newUser);
            // TODO: save to file
            return Results.Ok();
        }
    }
}