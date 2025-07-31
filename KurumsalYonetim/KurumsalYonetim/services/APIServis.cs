
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KurumsalYonetim.Models; 

namespace KurumsalYonetim.Controllers
{
    public class APIServis
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public APIServis(string baseApiUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30); 
            _baseApiUrl = baseApiUrl;
        }

        public async Task<(bool success, string message, string role, bool requirePasswordChange)> LoginAsync(string kullaniciAdi, string sifre)
        {
            try
            {
                
                LoginRequest loginRequest = new LoginRequest
                {
                    KullaniciAdi = kullaniciAdi,
                    Sifre = sifre
                };
                StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_baseApiUrl}/api/Auth/login", jsonContent);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    LoginResponse result = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                    return (true, result.Message, result.Role, result.RequirePasswordChange);
                }
                else
                {
                    dynamic errorResult = JsonConvert.DeserializeObject(responseContent);
                    string errorMessage = errorResult.Message ?? "Bilinmeyen bir hata oluştu.";
                    return (false, errorMessage, string.Empty, false);
                }
            }
            catch (HttpRequestException ex)
            {
                return (false, $"API bağlantı hatası: {ex.Message}. API'nin çalıştığından ve doğru URL'yi kullandığınızdan emin olun ({_baseApiUrl}).", string.Empty, false);
            }
            catch (JsonSerializationException ex)
            {
                return (false, $"API yanıtı deserialize edilirken hata oluştu: {ex.Message}", string.Empty, false);
            }
            catch (Exception ex)
            {
                return (false, $"Beklenmeyen bir hata oluştu: {ex.Message}", string.Empty, false);
            }
        }

        public async Task<(bool success, string message)> SetPasswordAsync(string kullaniciAdi, string yeniSifre)
        {
            try
            {
                SetPasswordRequest setPasswordRequest = new SetPasswordRequest
                {
                    KullaniciAdi = kullaniciAdi,
                    YeniSifre = yeniSifre
                };
                StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(setPasswordRequest), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_baseApiUrl}/api/Auth/set-password", jsonContent);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // API'nin doğrudan string döndürdüğünü varsayarak tırnakları temizliyoruz
                    return (true, responseContent.Replace("\"", ""));
                }
                else
                {
                    dynamic errorResult = JsonConvert.DeserializeObject(responseContent);
                    string errorMessage = errorResult.Message ?? "Bilinmeyen bir hata oluştu.";
                    return (false, errorMessage);
                }
            }
            catch (HttpRequestException ex)
            {
                return (false, $"API bağlantı hatası: {ex.Message}. API'nin çalıştığından ve doğru URL'yi kullandığınızdan emin olun ({_baseApiUrl}).");
            }
            catch (JsonSerializationException ex)
            {
                return (false, $"API yanıtı deserialize edilirken hata oluştu: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Beklenmeyen bir hata oluştu: {ex.Message}");
            }
        }

    }
}