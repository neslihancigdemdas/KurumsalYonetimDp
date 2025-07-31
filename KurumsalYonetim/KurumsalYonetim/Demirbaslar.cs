using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class FormDemirbaslar : Form
    {
        public FormDemirbaslar()
        {
            InitializeComponent();
        }
        public class Demirbas
        {
            public int DemirbasID { get; set; }
            public string DemirbasAdi { get; set; }
            public string DemirbasTuru { get; set; }
            public string Marka { get; set; }
            public string Model { get; set; }
            public string SeriNumarasi { get; set; }
            public string Durum { get; set; }
           
        }
        private async void btnEkle_Click(object sender, EventArgs e)
        {
            Demirbas yeniDemirbas = new Demirbas
            {
                DemirbasAdi = tbDemirbasAd.Text.Trim(),
                DemirbasTuru = tbDemirbasTuru.Text.Trim(),
                Marka = tbMarka.Text.Trim(),
                Model = tbModel.Text.Trim(),
                SeriNumarasi = tbSeriNo.Text.Trim(),
                Durum = cmbDurum.SelectedItem?.ToString() ?? ""
            };
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(yeniDemirbas);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    string apiBaseUrl = "http://localhost:5011"; 
                    HttpResponseMessage response = await client.PostAsync($"{apiBaseUrl}/api/Demirbaslar", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Demirbaş başarıyla eklendi.");
                        FormAlanlariniTemizle();
                        DemirbasListele(); 
                    }
                    else
                    {
                        string hata = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Hata: {hata}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
                }
            }
        }
        private async void DemirbasListele()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiBaseUrl = "http://localhost:5011"; 
                    HttpResponseMessage response = await client.GetAsync(apiBaseUrl + "/api/Demirbaslar");
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    List<Demirbas> demirbasListesi = JsonConvert.DeserializeObject<List<Demirbas>>(json);
                    dgvDemirbaslar.DataSource = demirbasListesi;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Demirbaşlar listelenirken hata oluştu: " + ex.Message);
                }
            }
        }
        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvDemirbaslar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir demirbaş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult onay = MessageBox.Show("Seçili demirbaşı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay != DialogResult.Yes)
                return;
            DataGridViewRow seciliSatir = dgvDemirbaslar.SelectedRows[0];
            Demirbas seciliDemirbas = seciliSatir.DataBoundItem as Demirbas;
            if (seciliDemirbas == null)
            {
                MessageBox.Show("Silinecek demirbaş bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiBaseUrl = "http://localhost:5011";
                    string url = apiBaseUrl + "/api/Demirbaslar/" + seciliDemirbas.DemirbasID;

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Demirbaş başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DemirbasListele();
                    }
                    else
                    {
                        string hata = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Silme başarısız: " + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show("API bağlantı hatası: " + httpEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
        private void FormAlanlariniTemizle()
        {
            tbDemirbasAd.Text = "";
            tbDemirbasTuru.Text = "";
            tbMarka.Text = "";
            tbModel.Text = "";
            tbSeriNo.Text = "";
            cmbDurum.SelectedIndex = -1;
        }
        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvDemirbaslar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir demirbaş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Demirbas seciliDemirbas = dgvDemirbaslar.SelectedRows[0].DataBoundItem as Demirbas;
            if (seciliDemirbas == null)
            {
                MessageBox.Show("Geçerli bir demirbaş seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            seciliDemirbas.DemirbasAdi = tbDemirbasAd.Text.Trim();
            seciliDemirbas.DemirbasTuru = tbDemirbasTuru.Text.Trim();
            seciliDemirbas.Marka = tbMarka.Text.Trim();
            seciliDemirbas.Model = tbModel.Text.Trim();
            seciliDemirbas.SeriNumarasi = tbSeriNo.Text.Trim();
            seciliDemirbas.Durum = cmbDurum.SelectedItem?.ToString() ?? "";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiBaseUrl = "http://localhost:5011";
                    string url = apiBaseUrl + "/api/Demirbaslar/" + seciliDemirbas.DemirbasID;
                    string json = JsonConvert.SerializeObject(seciliDemirbas);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Demirbaş başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormAlanlariniTemizle(); 
                    }
                    else
                    {
                        string hataMesaji = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Güncelleme başarısız: {response.StatusCode}\n{hataMesaji}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DemirbasListele();
        }

        private void FormDemirbaslar_Load(object sender, EventArgs e)
        {
            DemirbasListele();
            dgvDemirbaslar.SelectionChanged += dgvDemirbaslar_SelectionChanged;
            this.WindowState = FormWindowState.Maximized;
        }
        private void dgvDemirbaslar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDemirbaslar.SelectedRows.Count > 0)
            {
                var demirbas = dgvDemirbaslar.SelectedRows[0].DataBoundItem as Demirbas;
                if (demirbas != null)
                {
                    tbDemirbasAd.Text = demirbas.DemirbasAdi;
                    tbDemirbasTuru.Text = demirbas.DemirbasTuru;
                    tbMarka.Text = demirbas.Marka;
                    tbModel.Text = demirbas.Model;
                    tbSeriNo.Text = demirbas.SeriNumarasi;
                    cmbDurum.SelectedItem = demirbas.Durum;
                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormAlanlariniTemizle();
        }
    }
}
