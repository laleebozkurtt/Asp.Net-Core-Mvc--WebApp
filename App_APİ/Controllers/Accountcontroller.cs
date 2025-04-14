using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App_API.Services;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly TokenService _tokenService;

    public AccountController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
            return Unauthorized("Kullanıcı bulunamadı");

        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
            return Unauthorized("Şifre hatalı");

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.GenerateToken(user.UserName, roles[0]); // ilk rolü alıyoruz

        return Ok(new { token });
    }
}
public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
