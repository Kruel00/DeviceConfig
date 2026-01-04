using DeviceConfigUserData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DeviceConfigApi;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly JwtTokenService _jwt;

    public AuthController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        JwtTokenService jwt )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwt = jwt;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if(user == null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if(!result.Succeeded) return Unauthorized();

        var token = await _jwt.GetToken(user, _userManager);
        return Ok(new { token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            EmployeeId = "A" +_userManager.Users.Count().ToString(),
            UserName = request.Email,
        };

        var result = await _userManager
            .CreateAsync(user, request.Password);
        
        if(!result.Succeeded)
            return BadRequest(result.Errors);

        var roleResult = await _userManager
            .AddToRoleAsync(user, "User");

        if(!roleResult.Succeeded)
            return BadRequest(roleResult.Errors);

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = _userManager.Users.ToList();
        return Ok(users);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("setadmin/{userId}")]
    public async Task<IActionResult> SetAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if(user == null)
            return NotFound();

        var result = await _userManager.AddToRoleAsync(user, "Admin");
        if(!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok();
    }
    

}

public record LoginRequest(string Email, string Password);
public record RegisterRequest(string? FirstName,  string? LastName, string Email, string Password);