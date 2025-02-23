//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SupermercadoAPI.Models;

//[Authorize] // Requiere autenticación para acceder a los endpoints
//[Route("api/[controller]")]
//[ApiController]
//public class UsersController : ControllerBase
//{
//    private static List<User> users = new List<User>
//    {
//        new User { Id = 1, Username = "admin" },
//        new User { Id = 2, Username = "user" }
//    };

//    [HttpGet]
//    public IActionResult GetUsers()
//    {
//        return Ok(users);
//    }

//    [HttpGet("me")]
//    public IActionResult GetCurrentUser()
//    {
//        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
//        var user = users.FirstOrDefault(u => u.Id.ToString() == userId);

//        if (user == null) return NotFound();

//        return Ok(user);
//    }
//}
