using KurumsalYonetim.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace KurumsalYonetim
{
    public partial class formCihaz : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiUrl = "http://localhost:5011/api/Cihazlar";
        public formCihaz()
        {
            InitializeComponent();
        }

        private async void formCihaz_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            await ListeleCihazlar();
            await ListeleMusteriler(cmbMusteriSec);

            dgvCihaz.SelectionChanged += dgvCihaz_SelectionChanged;

        }
        private async Task ListeleCihazlar()
        {
            List<cihaz> cihazlar = await _httpClient.GetFromJsonAsync<List<cihaz>>(_apiUrl);

            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5011/api/Musteri");
            List<Musteriler> musteriler = new List<Musteriler>();

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                musteriler = System.Text.Json.JsonSerializer.Deserialize<List<Musteriler>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            var cihazGoruntuListesi = cihazlar.Select(c => new CihazGoruntu
            {
                CihazID = c.CihazID,
                Marka = c.Marka,
                Model = c.Model,
                SeriNo = c.SeriNo,
                GarantiDurumu = c.GarantiDurumu ? "Var" : "Yok",
                Aciklama = c.Aciklama,
                KayitTarihi = c.KayitTarihi,
                MusteriAdi = musteriler.FirstOrDefault(m => m.MusteriID == c.MusteriID)?.AdSoyad ?? "Bilinmiyor"
            }).ToList();

            dgvCihaz.DataSource = cihazGoruntuListesi;

            dgvCihaz.Columns["CihazID"].Visible = false;
            dgvCihaz.Columns["MusteriAdi"].HeaderText = "Müşteri";
            dgvCihaz.Columns["GarantiDurumu"].HeaderText = "Garanti";
            dgvCihaz.Columns["KayitTarihi"].HeaderText = "Kayıt Tarihi";
        }


        private ComboBox GetCmbMusteriSec()
        {
            return cmbMusteriSec;
        }

        private async Task ListeleMusteriler(ComboBox cmbMusteriSec)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5011/api/Musteri");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<Musteriler> musteriListesi = System.Text.Json.JsonSerializer.Deserialize<List<Musteriler>>(jsonString, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                musteriListesi.Insert(0, new Musteriler { MusteriID = 0, AdSoyad = "" });

                cmbMusteriSec.DataSource = musteriListesi;
                cmbMusteriSec.DisplayMember = "AdSoyad";
                cmbMusteriSec.ValueMember = "MusteriID";
            }
            else
            {
                MessageBox.Show("Müşteri listesi yüklenirken hata oluştu.");
            }
        }
        private void Temizle()
        {
            cmbMusteriSec.SelectedIndex = -1;
            tbMarka.Clear();
            tbModel.Clear();
            tbSeriNumarası.Clear();
            rbtngarantivar.Checked = false;
            rbtngarantiyok.Checked = false;
            rtbaciklama.Clear();
            lbKayitTarihi.Text = string.Empty;
        }

        private void dgvCihaz_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCihaz.SelectedRows.Count > 0)
            {
                CihazGoruntu secilen = dgvCihaz.SelectedRows[0].DataBoundItem as CihazGoruntu;
                if (secilen != null)
                {
                    cmbMusteriSec.SelectedIndex = cmbMusteriSec.FindStringExact(secilen.MusteriAdi);
                    tbMarka.Text = secilen.Marka ?? "";
                    tbModel.Text = secilen.Model ?? "";
                    tbSeriNumarası.Text = secilen.SeriNo ?? "";

                    if (secilen.GarantiDurumu == "Var")
                    {
                        rbtngarantivar.Checked = true;
                    }
                    else
                    {
                        rbtngarantiyok.Checked = true;
                    }

                    rtbaciklama.Text = secilen.Aciklama ?? "";
                    lbKayitTarihi.Text = secilen.KayitTarihi.ToString("dd.MM.yyyy HH:mm");
                }
            }

        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            cihaz yeniCihaz = new cihaz()
            {
                MusteriID = (int)cmbMusteriSec.SelectedValue,
                Marka = tbMarka.Text,
                Model = tbModel.Text,
                SeriNo = tbSeriNumarası.Text,
                GarantiDurumu = rbtngarantivar.Checked,
                Aciklama = rtbaciklama.Text
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_apiUrl, yeniCihaz);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cihaz başarıyla eklendi.");
                await ListeleCihazlar();
                Temizle();
            }
            else
            {
                MessageBox.Show("Ekleme sırasında hata oluştu!");
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvCihaz.CurrentRow == null)
                return;

            CihazGoruntu secilenGoruntu = dgvCihaz.CurrentRow.DataBoundItem as CihazGoruntu;
            if (secilenGoruntu == null)
                return;

            var cihazlar = await _httpClient.GetFromJsonAsync<List<cihaz>>(_apiUrl);
            var secilen = cihazlar.FirstOrDefault(c => c.CihazID == secilenGoruntu.CihazID);
            if (secilen == null)
                return;

            secilen.MusteriID = (int)cmbMusteriSec.SelectedValue;
            secilen.Marka = tbMarka.Text;
            secilen.Model = tbModel.Text;
            secilen.SeriNo = tbSeriNumarası.Text;
            secilen.GarantiDurumu = rbtngarantivar.Checked;
            secilen.Aciklama = rtbaciklama.Text;

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_apiUrl}/{secilen.CihazID}", secilen);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cihaz başarıyla güncellendi.");
                await ListeleCihazlar();
            }
            else
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu!");
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvCihaz.CurrentRow == null)
                return;

            DialogResult dialogResult = MessageBox.Show("Seçili cihazı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                cihaz secilen = (cihaz)dgvCihaz.CurrentRow.DataBoundItem;

                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}/{secilen.CihazID}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cihaz başarıyla silindi.");
                    await ListeleCihazlar();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Silme sırasında hata oluştu!");
                }
            }
            else
            {

            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
