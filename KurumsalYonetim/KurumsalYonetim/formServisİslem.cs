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
    public partial class formServisIslem : Form
    {
        private List<ServisIslem> islemler = new List<ServisIslem>();
        private List<ServisKayit> servisKayitlar = new List<ServisKayit>();

        public formServisIslem()
        {
            InitializeComponent();
        }

        private async Task KayitlariYukle()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5011/api/ServisIslem";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<ServisIslem> tempIslemler = JsonConvert.DeserializeObject<List<ServisIslem>>(json);
                    islemler = tempIslemler;
                    dataGridViewIslemler.DataSource = islemler;
                    dataGridViewIslemler.Columns["IslemId"].Visible = false;
                    dataGridViewIslemler.Columns["ServisKayitId"].Visible = false;
                    dataGridViewIslemler.Columns["ServisKayit"].Visible = false;
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
                    List<ServisKayit> tempServisKayitlar = JsonConvert.DeserializeObject<List<ServisKayit>>(json);

                    servisKayitlar = tempServisKayitlar;

                    cmbServisKayit.DataSource = servisKayitlar;
                    cmbServisKayit.DisplayMember = "Aciklama";
                    cmbServisKayit.ValueMember = "ServisKayitId";
                    cmbServisKayit.SelectedIndex = -1;
                }
            }
        }

        private void dataGridViewIslemler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewIslemler.Rows[e.RowIndex];
                ServisIslem secili = row.DataBoundItem as ServisIslem;
                if (secili != null)
                {
                    cmbServisKayit.SelectedValue = secili.ServisKayitId;
                    txtYapilanIslem.Text = secili.YapilanIslem;
                    dtpTarih.Value = secili.Tarih;
                    txtUcret.Text = secili.Ucret?.ToString() ?? "";
                }
                else
                {
                    MessageBox.Show("Seçili kayıt okunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!decimal.TryParse(txtUcret.Text, out decimal ucret))
            {
                lblHataMesaji.Text = "Ücret alanına geçerli bir sayı giriniz (örnek: 100.50).";
                return;
            }

            ServisIslem yeniIslem = new ServisIslem
            {
                ServisKayitId = Convert.ToInt32(cmbServisKayit.SelectedValue),
                YapilanIslem = txtYapilanIslem.Text,
                Tarih = dtpTarih.Value,
                Ucret = ucret
            };

            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5011/api/ServisIslem";
                string json = JsonConvert.SerializeObject(yeniIslem);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    lblHataMesaji.Text = "Kayıt başarıyla eklendi.";
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
            if (dataGridViewIslemler.SelectedRows.Count == 0)
            {
                lblHataMesaji.Text = "Lütfen güncellenecek bir kayıt seçin.";
                return;
            }

            int id = Convert.ToInt32(dataGridViewIslemler.SelectedRows[0].Cells["IslemId"].Value);

            ServisIslem guncelIslem = new ServisIslem
            {
                IslemId = id,
                ServisKayitId = Convert.ToInt32(cmbServisKayit.SelectedValue),
                YapilanIslem = txtYapilanIslem.Text,
                Tarih = dtpTarih.Value,
                Ucret = decimal.TryParse(txtUcret.Text, out decimal ucret) ? (decimal?)ucret : null
            };

            using (HttpClient client = new HttpClient())
            {
                string url = $"http://localhost:5011/api/ServisIslem/{id}";
                string json = JsonConvert.SerializeObject(guncelIslem);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    lblHataMesaji.Text = "Kayıt başarıyla güncellendi.";
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
            if (dataGridViewIslemler.SelectedRows.Count == 0)
            {
                lblHataMesaji.Text = "Lütfen silinecek bir kayıt seçin.";
                return;
            }

            int id = Convert.ToInt32(dataGridViewIslemler.SelectedRows[0].Cells["IslemId"].Value);

            DialogResult dr = MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes)
                return;

            using (HttpClient client = new HttpClient())
            {
                string url = $"http://localhost:5011/api/ServisIslem/{id}";
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    lblHataMesaji.Text = "Kayıt silindi.";
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
            txtYapilanIslem.Text = "";
            txtUcret.Text = "";
            dtpTarih.Value = DateTime.Now;
            lblHataMesaji.Text = "";
        }
        private async void formServisIslem_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dataGridViewIslemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIslemler.MultiSelect = false;
            await KayitlariYukle();
            await ServisKayitlariYukle();
            dtpTarih.Value = DateTime.Now;

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}
