using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class FormCalisanlar : Form
    {
        private readonly string _apiBaseUrl = "http://localhost:5011";

        public class Calisan
        {
            public int CalisanID { get; set; }
            public string Ad { get; set; } = string.Empty;
            public string Soyad { get; set; } = string.Empty;
            public string Departman { get; set; } = string.Empty;
            public string Telefon { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string SicilNo { get; set; } = string.Empty;

            public string AdSoyad => $"{Ad} {Soyad}";
        }

        public FormCalisanlar()
        {
            InitializeComponent();
            msktb_telefon.Mask = "(999) 000-00-00";
            dgvPersonelListesi.SelectionChanged += dgvPersonelListesi_SelectionChanged;
            LoadPersonelData();
            ClearFormFields();
        }

        private async void LoadPersonelData()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{_apiBaseUrl}/api/Calisanlar");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Calisan> calisanList = JsonConvert.DeserializeObject<List<Calisan>>(responseBody);

                    dgvPersonelListesi.DataSource = calisanList;

                    dgvPersonelListesi.Columns["CalisanID"].Visible = false;
                    dgvPersonelListesi.Columns["Ad"].HeaderText = "Adı";
                    dgvPersonelListesi.Columns["Soyad"].HeaderText = "Soyadı";
                    dgvPersonelListesi.Columns["Departman"].HeaderText = "Departman";
                    dgvPersonelListesi.Columns["Telefon"].HeaderText = "Telefon";
                    dgvPersonelListesi.Columns["Email"].HeaderText = "E-Mail";
                    dgvPersonelListesi.Columns["SicilNo"].HeaderText = "Sicil No";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPersonelListesi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPersonelListesi.SelectedRows.Count > 0)
            {
                Calisan secilenCalisan = dgvPersonelListesi.SelectedRows[0].DataBoundItem as Calisan;
                if (secilenCalisan != null)
                {
                    tbAd.Text = secilenCalisan.Ad;
                    tbSoyad.Text = secilenCalisan.Soyad;
                    tbSicilNo.Text = secilenCalisan.SicilNo;
                    tbDepartman.Text = secilenCalisan.Departman;
                    msktb_telefon.Text = secilenCalisan.Telefon;
                    tbEmail.Text = secilenCalisan.Email;
                }
            }
        }

        private void ClearFormFields()
        {
            tbAd.Text = string.Empty;
            tbSoyad.Text = string.Empty;
            tbSicilNo.Text = string.Empty;
            tbDepartman.Text = string.Empty;
            msktb_telefon.Text = string.Empty;
            tbEmail.Text = string.Empty;
            dgvPersonelListesi.ClearSelection();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAd.Text) || string.IsNullOrWhiteSpace(tbSoyad.Text) || string.IsNullOrWhiteSpace(tbSicilNo.Text))
            {
                MessageBox.Show("Ad, Soyad ve Sicil No alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Calisan yeniCalisan = new Calisan
            {
                Ad = tbAd.Text.Trim(),
                Soyad = tbSoyad.Text.Trim(),
                SicilNo = tbSicilNo.Text.Trim(),
                Departman = tbDepartman.Text.Trim(),
                Telefon = msktb_telefon.Text.Trim(),
                Email = tbEmail.Text.Trim()
            };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(yeniCalisan);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(_apiBaseUrl + "/api/Calisanlar", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Çalışan başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                        LoadPersonelData();
                    }
                    else
                    {
                        MessageBox.Show("Çalışan eklenemedi: " + response.StatusCode, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "API Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvPersonelListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir çalışan seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCalisan = dgvPersonelListesi.SelectedRows[0].DataBoundItem as Calisan;
            if (selectedCalisan == null)
            {
                MessageBox.Show("Güncellenecek çalışan bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedCalisan.Ad = tbAd.Text.Trim();
            selectedCalisan.Soyad = tbSoyad.Text.Trim();
            selectedCalisan.SicilNo = tbSicilNo.Text.Trim();
            selectedCalisan.Departman = tbDepartman.Text.Trim();
            selectedCalisan.Telefon = msktb_telefon.Text.Trim();
            selectedCalisan.Email = tbEmail.Text.Trim();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(selectedCalisan);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"{_apiBaseUrl}/api/Calisanlar/{selectedCalisan.CalisanID}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Çalışan güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                        LoadPersonelData();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme hatası: " + response.StatusCode, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "API Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvPersonelListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir çalışan seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCalisan = dgvPersonelListesi.SelectedRows[0].DataBoundItem as Calisan;
            if (selectedCalisan == null)
            {
                MessageBox.Show("Silinecek çalışan bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bu çalışanı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync($"{_apiBaseUrl}/api/Calisanlar/{selectedCalisan.CalisanID}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Çalışan silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                        LoadPersonelData();
                    }
                    else
                    {
                        MessageBox.Show("Silme hatası: " + response.StatusCode, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "API Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormCalisanlar_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
