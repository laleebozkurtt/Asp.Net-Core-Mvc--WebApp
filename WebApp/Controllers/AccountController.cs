using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.Error = "E-posta ve şifre zorunludur.";
            return View();
        }

        // Kullanıcıyı e-posta adresine göre veritabanından çekiyoruz
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            ViewBag.Error = "Hatalı e-posta veya şifre. Bu e-posta ile kayıtlı bir kullanıcı bulunamadı.";
            return View();
        }

        // Kullanıcı doğrulama işlemi
        var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Hatalı e-posta veya şifre!";
        return View();
    }
    // Şifre Değiştirme Sayfasını Görüntüleme (GET)
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    // Şifre Değiştirme İşlemi (POST)
    [HttpPost]
    public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(user);  // Oturumu yenile
            ViewBag.Message = "Şifre başarıyla değiştirildi.";
        }
        else
        {
            ViewBag.Message = "Şifre değiştirilirken hata oluştu.";
            foreach (var error in result.Errors)
            {
                ViewBag.Message += error.Description + "<br/>";
            }
        }
        return View();  // Geriye View döndürülüyor

    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
