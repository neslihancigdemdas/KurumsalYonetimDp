using KurumsalYonetim.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KurumsalYonetim.Models.Musteriler;


namespace KurumsalYonetim
{
    public partial class formServisKayit : Form
    {
        private List<ServisKayit> servisListesi = new List<ServisKayit>();
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _musteriApiUrl = "http://localhost:5011/api/Musteri";
        private readonly string _cihazApiUrl = "http://localhost:5011/api/Cihazlar";

        public formServisKayit()
        {
            InitializeComponent();
        }

        private async void formServisKayit_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            await KayitlariYukle();
            await MusterileriYukle();
            dgvserviskayit.SelectionChanged += dgvserviskayit_SelectionChanged;

        }
        private async Task KayitlariYukle()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5011/api/ServisKayit";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    servisListesi = JsonConvert.DeserializeObject<List<ServisKayit>>(json);
                    dgvserviskayit.DataSource = servisListesi;
                    dgvserviskayit.Columns["ServisKayitId"].Visible = false;
                    dgvserviskayit.Columns["MusteriId"].Visible = false;
                    dgvserviskayit.Columns["CihazId"].Visible = false;

                    dgvserviskayit.Columns["MusteriAdSoyad"].HeaderText = "Müşteri";
                    dgvserviskayit.Columns["CihazMarka"].HeaderText = "Cihaz Markası";
                    dgvserviskayit.Columns["Aciklama"].HeaderText = "Açıklama";
                    dgvserviskayit.Columns["KayitTarihi"].HeaderText = "Kayıt Tarihi";
                }
            }
        }
        private async Task MusterileriYukle()
        {
            try
            {
                var musteriler = await _httpClient.GetFromJsonAsync<List<Musteri>>(_musteriApiUrl);
                if (musteriler != null)
                {
                    musteriler.Insert(0, new Musteri { MusteriID = 0, AdSoyad = "" });
                    cmbMusteri.DataSource = musteriler;
                    cmbMusteri.DisplayMember = "AdSoyad";
                    cmbMusteri.ValueMember = "MusteriId";
                    cmbMusteri.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteri yüklenirken hata oluştu: {ex.Message}");
            }
        }
        private async Task CihazlariYukle(int musteriId)
        {
            try
            {
                var tumCihazlar = await _httpClient.GetFromJsonAsync<List<cihaz>>(_cihazApiUrl);
                if (tumCihazlar != null)
                {
                    var musteriCihazlari = tumCihazlar.FindAll(c => c.MusteriID == musteriId);
                    musteriCihazlari.Insert(0, new cihaz { CihazID = 0, Marka = "" });

                    cmbCihaz.DataSource = musteriCihazlari;
                    cmbCihaz.DisplayMember = "Marka";
                    cmbCihaz.ValueMember = "CihazId";
                    cmbCihaz.SelectedIndex = 0;
                    cmbCihaz.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cihaz yüklenirken hata oluştu: {ex.Message}");
            }
        }


        private async void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                ServisKayit yeniKayit = new ServisKayit
                {
                    CihazId = Convert.ToInt32(cmbCihaz.SelectedValue),
                    MusteriId = Convert.ToInt32(cmbMusteri.SelectedValue),
                    Aciklama = txtAciklama.Text,
                    KayitTarihi = DateTime.Now
                };

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "http://localhost:5011/api/ServisKayit";
                    string json = JsonConvert.SerializeObject(yeniKayit);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Kayıt başarıyla eklendi.");
                        await KayitlariYukle();
                        TemizleForm();
                    }
                    else
                    {
                        string hata = await response.Content.ReadAsStringAsync();
                        lblHataMesaji.Text = "Hata: " + hata;
                    }
                }
            }
            catch (Exception ex)
            {
                lblHataMesaji.Text = "İstisna: " + ex.Message;
            }
        }

        private void dgvserviskayit_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvserviskayit.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvserviskayit.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["ServisKayitId"].Value);

                ServisKayit secili = servisListesi.FirstOrDefault(s => s.ServisKayitId == id);
                if (secili != null)
                {
                    txtAciklama.Text = secili.Aciklama;
                    cmbCihaz.SelectedValue = secili.CihazId;
                    cmbMusteri.SelectedValue = secili.MusteriId;
                }
            }

        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvserviskayit.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçin.");
                return;
            }

            DataGridViewRow row = dgvserviskayit.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["ServisKayitId"].Value);

            DialogResult dr = MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes)
                return;

            using (HttpClient client = new HttpClient())
            {
                string url = $"http://localhost:5011/api/ServisKayit/{id}";
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Kayıt silindi.");
                    await KayitlariYukle();
                    TemizleForm();
                }
                else
                {
                    lblHataMesaji.Text = "Silme hatası: " + await response.Content.ReadAsStringAsync();
                }
            }
        }
        private void TemizleForm()
        {
            cmbCihaz.SelectedIndex = -1;
            cmbMusteri.SelectedIndex = -1;
            txtAciklama.Text = "";
            lblHataMesaji.Text = "";
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvserviskayit.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir kayıt seçin.");
                return;
            }

            try
            {
                DataGridViewRow row = dgvserviskayit.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["ServisKayitId"].Value);

                ServisKayit guncellenenKayit = new ServisKayit
                {
                    ServisKayitId = id,
                    CihazId = Convert.ToInt32(cmbCihaz.SelectedValue),
                    MusteriId = Convert.ToInt32(cmbMusteri.SelectedValue),
                    Aciklama = txtAciklama.Text,
                    KayitTarihi = DateTime.Now
                };

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"http://localhost:5011/api/ServisKayit/{id}";
                    string json = JsonConvert.SerializeObject(guncellenenKayit);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Kayıt başarıyla güncellendi.");
                        await KayitlariYukle();
                        TemizleForm();
                    }
                    else
                    {
                        string hata = await response.Content.ReadAsStringAsync();
                        lblHataMesaji.Text = "Güncelleme hatası: " + hata;
                    }
                }
            }
            catch (Exception ex)
            {
                lblHataMesaji.Text = "İstisna: " + ex.Message;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TemizleForm();
        }

        private async void cmbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMusteri.SelectedIndex <= 0)
            {
                cmbCihaz.DataSource = null;
                cmbCihaz.Enabled = false;
                return;
            }

            int secilenMusteriId = (int)cmbMusteri.SelectedValue;
            await CihazlariYukle(secilenMusteriId);
        }
    }
}
