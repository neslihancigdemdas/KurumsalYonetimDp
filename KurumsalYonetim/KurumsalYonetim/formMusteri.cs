using KurumsalYonetim.Models; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class formMusteri : Form
    {
        private int seciliMusteriID = 0;
        private readonly HttpClient client = new HttpClient();
        private const string baseUrl = "http://localhost:5011/api/Musteri";  

        public formMusteri()
        {
            InitializeComponent();
        }

        private async void formMusteri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            await MusterileriGetir();

        }
        private async Task MusterileriGetir()
        {
            try
            {  
                HttpResponseMessage yanit = await client.GetAsync(baseUrl);
                yanit.EnsureSuccessStatusCode(); 

                
                using (Stream akis = await yanit.Content.ReadAsStreamAsync())
                {
                    List<Musteri> musteriler = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Musteri>>(akis, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    dgvmusteri.DataSource = musteriler;
                }
            }
            catch (HttpRequestException httpEx) 
            {
                MessageBox.Show("API çağrısı sırasında hata oluştu: " + httpEx.Message);
            }
            catch (System.Text.Json.JsonException jsonEx) 
            {
                MessageBox.Show("Veri ayrıştırma sırasında hata oluştu: " + jsonEx.Message);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message);
            }
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri yeniMusteri = new Musteri
                {
                    AdSoyad = tbAdSoyad.Text,
                    Telefon = msktbTelefon.Text,
                    Email = tbEmail.Text,
                    Adres = rtbAdres.Text,
                    KayitTarihi = dtpKayitTarih.Value
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(baseUrl, yeniMusteri);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Müşteri eklendi.");
                    await MusterileriGetir();  
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Ekleme işlemi başarısız oldu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliMusteriID == 0)
            {
                MessageBox.Show("Lütfen güncellenecek müşteri seçin.");
                return;
            }

            Musteri musteri = new Musteri
            {
                MusteriID = seciliMusteriID,
                AdSoyad = tbAdSoyad.Text,
                Telefon = msktbTelefon.Text,
                Email = tbEmail.Text,
                Adres = rtbAdres.Text,
                KayitTarihi = dtpKayitTarih.Value
            };

            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Musteri/{seciliMusteriID}", musteri);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Güncelleme başarılı.");
                await MusterileriGetir();
                Temizle();
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız.");
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliMusteriID == 0)
            {
                MessageBox.Show("Lütfen silinecek müşteri seçin.");
                return;
            }

            HttpResponseMessage response = await client.DeleteAsync($"api/Musteri/{seciliMusteriID}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Silme işlemi başarılı.");
                await MusterileriGetir();
                Temizle();
            }
            else
            {
                MessageBox.Show("Silme işlemi başarısız.");
            }
        }
        private void Temizle()
        {
            seciliMusteriID = 0;
            tbAdSoyad.Clear();
            msktbTelefon.Clear();
            tbEmail.Clear();
            rtbAdres.Clear();
            dtpKayitTarih.Value = DateTime.Now;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void dgvmusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvmusteri.Rows[e.RowIndex];
                seciliMusteriID = Convert.ToInt32(row.Cells["MusteriID"].Value);
                tbAdSoyad.Text = row.Cells["AdSoyad"].Value.ToString();
                msktbTelefon.Text = row.Cells["Telefon"].Value.ToString();
                tbEmail.Text = row.Cells["Email"].Value.ToString();
                rtbAdres.Text = row.Cells["Adres"].Value.ToString();
                dtpKayitTarih.Value = Convert.ToDateTime(row.Cells["KayitTarihi"].Value);

            }
        }
    }
}
