
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using KurumsalYonetimAPI.Models; 
using KurumsalYonetimAPI.Helpers; 
using KurumsalYonetimAPI.Data;
using System; 

namespace KurumsalYonetimAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] 
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        // Constructor Dependency Injection ile DbContext'i alırız
        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Auth/register (Kullanıcı kaydı için - test amaçlı veya Admin tarafından)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.KullaniciAdi) || string.IsNullOrEmpty(request.Sifre) || string.IsNullOrEmpty(request.Rol))
            {
                return BadRequest("Kullanıcı adı, şifre ve rol boş bırakılamaz.");
            }

            if (await _context.Kullanicilar.AnyAsync(u => u.KullaniciAdi == request.KullaniciAdi))
            {
                return Conflict("Bu kullanıcı adı zaten mevcut.");
            }

            string salt = SifreYardimcisi.GenerateSalt();
            string hashedPassword = SifreYardimcisi.HashSifre(request.Sifre, salt);

            Kullanici yeniKullanici = new Kullanici
            {
                KullaniciAdi = request.KullaniciAdi,
                SifreHash = hashedPassword,
                SifreSalt = salt,
                Rol = request.Rol,
                AktifMi = true,
                SifreDegistirilmelidir = true,
                OlusturmaTarihi = DateTime.Now
            };

            _context.Kullanicilar.Add(yeniKullanici);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Kullanıcı başarıyla kaydedildi.", KullaniciAdi = yeniKullanici.KullaniciAdi });
        }

        // POST: api/Auth/login (Kullanıcı girişi için)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.KullaniciAdi) || string.IsNullOrEmpty(request.Sifre))
            {
                return BadRequest("Kullanıcı adı ve şifre girin.");
            }

            Kullanici? kullanici = await _context.Kullanicilar
                                           .FirstOrDefaultAsync(u => u.KullaniciAdi == request.KullaniciAdi);


            if (kullanici == null)
            {
                return Unauthorized("Kullanıcı adı veya şifre yanlış."); 
            }

            if (!kullanici.AktifMi)
            {
                return Unauthorized("Hesabınız pasif durumda. Lütfen yöneticinizle iletişime geçin.");
            }

            string girilenSifreHash = SifreYardimcisi.HashSifre(request.Sifre, kullanici.SifreSalt);

            if (girilenSifreHash != kullanici.SifreHash)
            {
                
                if (kullanici.SifreDegistirilmelidir)
                {
                    return Unauthorized("Kullanıcı adı veya şifre yanlış.");
                }
                return Unauthorized("Kullanıcı adı veya şifre yanlış."); 
            }

           
            if (kullanici.SifreDegistirilmelidir)
            {
                return Ok(new { Message = "Giriş başarılı ancak şifrenizi değiştirmeniz gerekiyor.", RequirePasswordChange = true });
            }

            kullanici.SonGirisTarihi = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Giriş başarılı!", Rol = kullanici.Rol, RequirePasswordChange = false });
        }

        // POST: api/Auth/set-password (Kullanıcının şifresini belirlemesi/değiştirmesi için)
        [HttpPost("set-password")]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.KullaniciAdi) || string.IsNullOrEmpty(request.YeniSifre))
            {
                return BadRequest("Kullanıcı adı ve yeni şifre boş bırakılamaz.");
            }

             Kullanici? kullanici = await _context.Kullanicilar
                                          .FirstOrDefaultAsync(u => u.KullaniciAdi == request.KullaniciAdi);


            if (kullanici == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            string newSalt = SifreYardimcisi.GenerateSalt();
            string newHashedPassword = SifreYardimcisi.HashSifre(request.YeniSifre, newSalt);

            kullanici.SifreHash = newHashedPassword;
            kullanici.SifreSalt = newSalt;
            kullanici.SifreDegistirilmelidir = false; // Şifre artık belirlendi

            await _context.SaveChangesAsync();

            return Ok("Şifreniz başarıyla belirlendi/değiştirildi.");
        }
    }

    // API İstek (Request) Modelleri (Controller sınıfının içinde tanımlanabilir)
    public class LoginRequest
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
    }

    public class RegisterRequest
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }

    public class SetPasswordRequest
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string YeniSifre { get; set; } = string.Empty;
    }
}