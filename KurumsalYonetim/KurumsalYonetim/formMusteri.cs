using KurumsalYonetim.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
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
            dgvmusteri.SelectionChanged += dgvmusteri_SelectionChanged;
        }

        private async Task MusterileriGetir()
        {
            try
            {
                HttpResponseMessage yanit = await client.GetAsync(baseUrl);
                yanit.EnsureSuccessStatusCode();

                using (Stream akis = await yanit.Content.ReadAsStreamAsync())
                {
                    List<Musteriler> musteriler = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Musteriler>>(akis, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    dgvmusteri.DataSource = null;
                    dgvmusteri.DataSource = musteriler;
                    if (dgvmusteri.Columns["MusteriID"] != null)
                    {
                        dgvmusteri.Columns["MusteriID"].Visible = false;
                    }
                    dgvmusteri.Refresh();
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
                Musteriler yeniMusteri = new Musteriler
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

            Musteriler musteri = new Musteriler
            {
                MusteriID = seciliMusteriID,
                AdSoyad = tbAdSoyad.Text,
                Telefon = msktbTelefon.Text,
                Email = tbEmail.Text,
                Adres = rtbAdres.Text,
                KayitTarihi = dtpKayitTarih.Value
            };

            HttpResponseMessage response = await client.PutAsJsonAsync($"{baseUrl}/{seciliMusteriID}", musteri);
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

            DialogResult result = MessageBox.Show("Seçili müşteriyi silmek istediğinizden emin misiniz?",
                                                     "Silme Onayı",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/{seciliMusteriID}");

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
            else
            {

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

        private void dgvmusteri_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvmusteri.SelectedRows.Count > 0)
            {
                Musteriler musteri = dgvmusteri.SelectedRows[0].DataBoundItem as Musteriler;
                if (musteri != null)
                {
                    seciliMusteriID = musteri.MusteriID;
                    tbAdSoyad.Text = musteri.AdSoyad;
                    msktbTelefon.Text = musteri.Telefon ?? "";
                    tbEmail.Text = musteri.Email ?? "";
                    rtbAdres.Text = musteri.Adres ?? "";


                    if (musteri.KayitTarihi != DateTime.MinValue)
                    {
                        dtpKayitTarih.Value = musteri.KayitTarihi;
                    }
                    else
                    {
                        dtpKayitTarih.Value = DateTime.Now;
                    }
                }
            }
        }
    }
}