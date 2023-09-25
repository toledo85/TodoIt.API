using Microsoft.AspNetCore.Mvc;
using TodoIt.Application.Dtos.Todos;
using TodoIt.Application.Dtos.User;
using TodoIt.Application.Repositories.Auth;
using TodoIt.Application.Repositories.Todos;
using TodoIt.Domain;

namespace TodoIt.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase {
    private readonly IAuthRepository _authRepo;

    public AuthController(IAuthRepository authRepo) {
        _authRepo = authRepo;
    }

    [HttpPost("Register")] public async Task<IActionResult> Register(UserRegisterDto request) {
        var response = await _authRepo.Register(request);

        if (response.Success) {
            return Ok(response);
        }
        
        return BadRequest(response);
    }

    [HttpPost("Login")] public async Task<IActionResult> Login(UserLoginDto request) {
        var response = await _authRepo.Login(request.Username, request.Password);
        
        if (response.Success) {
            return Ok(response);
        }
        
        return BadRequest(response);
    }
}