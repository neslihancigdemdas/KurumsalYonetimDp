using System.ComponentModel.DataAnnotations;

namespace KurumsalYonetimAPI.Models
{
    public class LoginResponse
    {
        public string Message { get; set; } = string.Empty; 
        public string Rol { get; set; } = string.Empty;    
        public bool RequirePasswordChange { get; set; }    
    }
}