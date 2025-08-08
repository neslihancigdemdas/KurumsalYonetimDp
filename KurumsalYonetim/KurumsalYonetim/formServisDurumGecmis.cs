using KurumsalYonetim.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class formServisDurumGecmis : Form
    {
        private List<ServisDurumGecmisi> durumlar = new List<ServisDurumGecmisi>();
        private List<ServisKayit> servisKayitlar = new List<ServisKayit>();

        public formServisDurumGecmis()
        {
            InitializeComponent();
            dataGridViewDurumlar.SelectionChanged += dataGridViewDurumlar_SelectionChanged;
        }

        private async void formServisDurumGecmis_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            await KayitlariYukle();
            await ServisKayitlariYukle();
            dtpTarih.Value = DateTime.Now;
            dataGridViewDurumlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async Task KayitlariYukle()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5011/api/ServisDurumGecmisi";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    durumlar = JsonConvert.DeserializeObject<List<ServisDurumGecmisi>>(json);

                    BindingSource bs = new BindingSource();
                    bs.DataSource = durumlar;
                    dataGridViewDurumlar.DataSource = bs;

                    if (dataGridViewDurumlar.Columns.Contains("DurumId"))
                        dataGridViewDurumlar.Columns["DurumId"].Visible = false;
                    if (dataGridViewDurumlar.Columns.Contains("ServisKayitId"))
                        dataGridViewDurumlar.Columns["ServisKayitId"].Visible = false;
                    if (dataGridViewDurumlar.Columns.Contains("ServisKayit"))
                        dataGridViewDurumlar.Columns["ServisKayit"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Veri yüklenemedi: " + response.ReasonPhrase);
                }
            }
        }

        private async Task ServisKayitlariYukle()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5011/api/ServisKayit";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    servisKayitlar = JsonConvert.DeserializeObject<List<ServisKayit>>(json);

                    cmbServisKayit.DataSource = servisKayitlar;
                    cmbServisKayit.DisplayMember = "Aciklama"; // İhtiyaca göre değiştirilebilir
                    cmbServisKayit.ValueMember = "ServisKayitId";
                    cmbServisKayit.SelectedIndex = -1;
                }
            }
        }

        private void dataGridViewDurumlar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDurumlar.SelectedRows.Count > 0)
            {
                var secili = dataGridViewDurumlar.SelectedRows[0].DataBoundItem as ServisDurumGecmisi;
                if (secili != null)
                {
                    cmbServisKayit.SelectedValue = secili.ServisKayitId;
                    txtAciklama.Text = secili.Aciklama ?? "";
                    dtpTarih.Value = secili.Tarih;
                }
            }
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbServisKayit.SelectedIndex == -1)
            {
                lblHataMesaji.Text = "Lütfen bir servis kaydı seçin.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                lblHataMesaji.Text = "Durum alanı boş olamaz.";
                return;
            }

            ServisDurumGecmisi yeniDurum = new ServisDurumGecmisi
            {
                ServisKayitId = Convert.ToInt32(cmbServisKayit.SelectedValue),
                Durum = cmbServisKayit.Text,
                Tarih = dtpTarih.Value,
                Aciklama = txtAciklama.Text
            };

            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5011/api/ServisDurumGecmisi";
                string json = JsonConvert.SerializeObject(yeniDurum);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    lblHataMesaji.Text = "Durum başarıyla eklendi.";
                    await KayitlariYukle();
                    TemizleForm();
                }
                else
                {
                    string hataMesaji = await response.Content.ReadAsStringAsync();
                    lblHataMesaji.Text = "Ekleme hatası: " + hataMesaji;
                }
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewDurumlar.SelectedRows.Count == 0)
            {
                lblHataMesaji.Text = "Lütfen güncellenecek bir kayıt seçin.";
                return;
            }

            int id = Convert.ToInt32(dataGridViewDurumlar.SelectedRows[0].Cells["DurumId"].Value);

            ServisDurumGecmisi guncelDurum = new ServisDurumGecmisi
            {
                DurumId = id,
                ServisKayitId = Convert.ToInt32(cmbServisKayit.SelectedValue),
                Durum = txtAciklama.Text,
                Tarih = dtpTarih.Value,
                Aciklama = txtAciklama.Text
            };

            using (HttpClient client = new HttpClient())
            {
                string url = $"http://localhost:5011/api/ServisDurumGecmisi/{id}";
                string json = JsonConvert.SerializeObject(guncelDurum);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    lblHataMesaji.Text = "Durum başarıyla güncellendi.";
                    await KayitlariYukle();
                    TemizleForm();
                }
                else
                {
                    string hataMesaji = await response.Content.ReadAsStringAsync();
                    lblHataMesaji.Text = "Güncelleme hatası: " + hataMesaji;
                }
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewDurumlar.SelectedRows.Count == 0)
            {
                lblHataMesaji.Text = "Lütfen silinecek bir kayıt seçin.";
                return;
            }

            int id = Convert.ToInt32(dataGridViewDurumlar.SelectedRows[0].Cells["DurumId"].Value);

            DialogResult dr = MessageBox.Show("Bu durumu silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes)
                return;

            using (HttpClient client = new HttpClient())
            {
                string url = $"http://localhost:5011/api/ServisDurumGecmisi/{id}";
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    lblHataMesaji.Text = "Durum silindi.";
                    await KayitlariYukle();
                    TemizleForm();
                }
                else
                {
                    string hataMesaji = await response.Content.ReadAsStringAsync();
                    lblHataMesaji.Text = "Silme hatası: " + hataMesaji;
                }
            }
        }

        private void TemizleForm()
        {
            cmbServisKayit.SelectedIndex = -1;
            txtAciklama.Text = "";
            dtpTarih.Value = DateTime.Now;
            lblHataMesaji.Text = "";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TemizleForm();
        }
    }
}
