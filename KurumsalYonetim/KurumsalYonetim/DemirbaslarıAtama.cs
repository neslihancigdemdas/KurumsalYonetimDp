using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KurumsalYonetim.FormCalisanlar; // Bu satırın varlığını korudum, ancak FormCalisanlar içindeki Calisan sınıfına bağlıdır.

namespace KurumsalYonetim
{
    public partial class FormDemirbaslarıAtama : Form
    {
        private readonly HttpClient client = new HttpClient();
        private List<Calisan> _calisanlarCache;
        private List<Demirbas> _demirbaslarCache; // Tüm demirbaşları tutacak cache (display için)
        private List<Demirbas> _availableDemirbaslarForComboBox; // Sadece atanabilir demirbaşları tutacak liste

        public FormDemirbaslarıAtama()
        {
            InitializeComponent();
            this.Load += FormDemirbaslarıAtama_Load;
            dgvAtamalar.SelectionChanged += dgvAtamalar_SelectionChanged;
        }

        // Atama sınıfı (API ile iletişim için)
        public class Atama
        {
            public int AtamaID { get; set; }
            public int DemirbasID { get; set; }
            public int CalisanID { get; set; }
            public DateTime AtamaTarihi { get; set; }
            public DateTime? TeslimTarihi { get; set; }
        }

        // Çalışan sınıfı (Diğer formdan veya API'den geliyor olabilir)
        public class Calisan
        {
            public int CalisanID { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string TamAd
            {
                get { return $"{Ad} {Soyad}"; }
            }
        }

        // Demirbaş sınıfı (API ile iletişim için)
        public class Demirbas
        {
            public int DemirbasID { get; set; }
            public string DemirbasAdi { get; set; }
            public string SeriNo { get; set; }
        }

        // DataGridView'de göstermek için kullanılan model
        public class AtamaDisplayModel
        {
            public int AtamaID { get; set; }
            [DisplayName("Çalışan Adı Soyadı")]
            public string CalisanAdSoyad { get; set; }
            [DisplayName("Demirbaş Adı")]
            public string DemirbasAdi { get; set; }
            [DisplayName("Atama Tarihi")]
            public DateTime AtamaTarihi { get; set; }
            [DisplayName("Teslim Tarihi")]
            public DateTime? TeslimTarihi { get; set; }

            // Gerekirse orijinal ID'leri tutmak için
            public int OriginalCalisanID { get; set; }
            public int OriginalDemirbasID { get; set; }
        }

        private async Task LoadAtamalarAsync()
        {
            // Eğer cache'ler boşsa, önce çalışanları ve demirbaşları yükle
            if (_calisanlarCache == null || !_calisanlarCache.Any())
            {
                await LoadCalisanAsync();
            }
            // LoadDemirbaslarAsync çağrısı zaten tüm demirbaşları _demirbaslarCache'e atıyor
            // ve ComboBox için filtrelenmiş listeyi ayarlıyor.
            // Bu nedenle burada tekrar çağırmaya gerek yok, Form_Load'da çağrılıyor.

            // Tüm atamaları API'den çek
            List<Atama> atamaListesi = await client.GetFromJsonAsync<List<Atama>>("http://localhost:5011/api/atamalar");

            // Display için AtamaDisplayModel listesini oluştur
            List<AtamaDisplayModel> displayList = atamaListesi.Select(a => new AtamaDisplayModel
            {
                AtamaID = a.AtamaID,
                CalisanAdSoyad = _calisanlarCache?.FirstOrDefault(c => c.CalisanID == a.CalisanID)?.TamAd ?? "Bilinmiyor",
                // Burada _demirbaslarCache'deki tüm demirbaşları kullanıyoruz
                // çünkü DGV'de teslim edilmiş demirbaşların da adları görünmeli.
                DemirbasAdi = _demirbaslarCache?.FirstOrDefault(d => d.DemirbasID == a.DemirbasID)?.DemirbasAdi ?? "Bilinmiyor",
                AtamaTarihi = a.AtamaTarihi,
                TeslimTarihi = a.TeslimTarihi,
                OriginalCalisanID = a.CalisanID,
                OriginalDemirbasID = a.DemirbasID
            }).ToList();

            dgvAtamalar.DataSource = displayList;
            dgvAtamalar.AutoGenerateColumns = true; // Sütunları otomatik oluştur

            // Gizlenmesi gereken sütunları gizle
            if (dgvAtamalar.Columns.Contains("OriginalCalisanID"))
            {
                dgvAtamalar.Columns["OriginalCalisanID"].Visible = false;
            }
            if (dgvAtamalar.Columns.Contains("OriginalDemirbasID"))
            {
                dgvAtamalar.Columns["OriginalDemirbasID"].Visible = false;
            }
        }

        private async void FormDemirbaslarıAtama_Load(object sender, EventArgs e)
        {
            await LoadCalisanAsync();
            await LoadDemirbaslarAsync(); // Bu, hem _demirbaslarCache'i hem de cmbdemirbassec'i günceller
            await LoadAtamalarAsync(); // Bu, dgvAtamalar'ı günceller

            // Form yüklendiğinde ComboBox'ları temizle
            cmbcalisansec.SelectedIndex = -1;
            cmbdemirbassec.SelectedIndex = -1;
        }

        private async Task LoadCalisanAsync()
        {
            _calisanlarCache = await client.GetFromJsonAsync<List<Calisan>>("http://localhost:5011/api/Calisanlar");
            cmbcalisansec.DataSource = _calisanlarCache;
            cmbcalisansec.DisplayMember = "TamAd";
            cmbcalisansec.ValueMember = "CalisanID";
        }

        private async Task LoadDemirbaslarAsync()
        {
            // Tüm demirbaşları API'den çek ve _demirbaslarCache'e kaydet (DGV display için)
            List<Demirbas> allDemirbaslar = await client.GetFromJsonAsync<List<Demirbas>>("http://localhost:5011/api/demirbaslar");
            _demirbaslarCache = allDemirbaslar; // Tüm demirbaşları cache'e kaydet

            // Tüm atamaları API'den çek
            List<Atama> allAtamalar = await client.GetFromJsonAsync<List<Atama>>("http://localhost:5011/api/atamalar");

            // Teslim tarihi NULL (yani hala birine atanmış ve teslim edilmemiş) olan demirbaş ID'lerini bul
            HashSet<int> assignedDemirbasIds = new HashSet<int>(
                allAtamalar.Where(a => a.TeslimTarihi == null)
                           .Select(a => a.DemirbasID));

            // Yalnızca atanabilir (yani şu anda atanmamış veya atanmış olup teslim edilmiş) demirbaşları filtrele
            _availableDemirbaslarForComboBox = allDemirbaslar
                .Where(d => !assignedDemirbasIds.Contains(d.DemirbasID))
                .ToList();

            // ComboBox'ın DataSource'una filtrelenmiş listeyi ata
            cmbdemirbassec.DataSource = _availableDemirbaslarForComboBox;
            cmbdemirbassec.DisplayMember = "DemirbasAdi";
            cmbdemirbassec.ValueMember = "DemirbasID";
        }

        private async void btnAta_Click(object sender, EventArgs e)
        {
            try
            {
                // ComboBox'tan geçerli bir seçim yapılmamışsa uyar
                if (cmbcalisansec.SelectedValue == null || cmbdemirbassec.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir çalışan ve demirbaş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Atama atama = new Atama();
                atama.CalisanID = (int)cmbcalisansec.SelectedValue;
                atama.DemirbasID = (int)cmbdemirbassec.SelectedValue;
                atama.AtamaTarihi = dtpAtamatarih.Value;
                atama.TeslimTarihi = null; // Yeni atamalarda teslim tarihi başlangıçta null'dır

                HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:5011/api/atamalar", atama);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Atama başarıyla yapıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Atama yapıldıktan sonra listeleri ve ComboBox'ı yenile
                    await LoadDemirbaslarAsync(); // Demirbaşlar listesini günceller (atanmış olanı çıkarır)
                    await LoadAtamalarAsync();    // Atamalar DGV'sini günceller
                    btnTemizle_Click(null, null); // Alanları temizle
                }
                else
                {
                    // Hata detayını daha iyi görmek için
                    string errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Atama işlemi sırasında hata oluştu: {response.StatusCode} - {errorContent}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAtamalar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAtamalar.SelectedRows.Count > 0)
            {
                
                AtamaDisplayModel secilenAtamaDisplay = (AtamaDisplayModel)dgvAtamalar.SelectedRows[0].DataBoundItem;

                
                cmbcalisansec.SelectedValue = secilenAtamaDisplay.OriginalCalisanID;
                cmbdemirbassec.SelectedValue = secilenAtamaDisplay.OriginalDemirbasID;
                dtpAtamatarih.Value = secilenAtamaDisplay.AtamaTarihi;
            }
        }

        private async void btnTeslimEt_Click(object sender, EventArgs e)
        {
            if (dgvAtamalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen teslim etmek için bir atama seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            AtamaDisplayModel secilenAtamaDisplay = (AtamaDisplayModel)dgvAtamalar.SelectedRows[0].DataBoundItem;

            
            if (secilenAtamaDisplay.TeslimTarihi != null)
            {
                MessageBox.Show("Seçilen demirbaş zaten teslim edilmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // API'ye PutAsync isteği gönderirken AtamaID'yi AtamaDisplayModel'den al
                HttpResponseMessage response = await client.PutAsync(
                    $"http://localhost:5011/api/atamalar/teslim/{secilenAtamaDisplay.AtamaID}", null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Demirbaş başarıyla teslim edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Teslim edildikten sonra listeleri ve ComboBox'ı yenile
                    await LoadDemirbaslarAsync(); // Teslim edilen demirbaş artık atanabilir listesine döner
                    await LoadAtamalarAsync();    // Atamalar DGV'sini günceller
                    btnTemizle_Click(null, null); // Alanları temizle
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Teslim etme işlemi başarısız oldu: {response.StatusCode} - {errorContent}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAtamalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir atama seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DataBoundItem'ı AtamaDisplayModel tipine dönüştür
            AtamaDisplayModel secilenAtamaDisplay = (AtamaDisplayModel)dgvAtamalar.SelectedRows[0].DataBoundItem;

            DialogResult confirmResult = MessageBox.Show(
                $"'{secilenAtamaDisplay.DemirbasAdi}' demirbaşının '{secilenAtamaDisplay.CalisanAdSoyad}' çalışanına ait atamasını silmek istediğinize emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    
                    HttpResponseMessage response = await client.DeleteAsync(
                   "http://localhost:5011/api/atamalar/" + secilenAtamaDisplay.AtamaID);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Atama başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        await LoadDemirbaslarAsync();
                        await LoadAtamalarAsync();   
                        btnTemizle_Click(null, null); 
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Silme işlemi başarısız oldu: {response.StatusCode} - {errorContent}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // ComboBox seçimlerini temizle
            cmbcalisansec.SelectedIndex = -1;
            cmbdemirbassec.SelectedIndex = -1;
            // Tarih seçiciyi bugünün tarihine ayarla
            dtpAtamatarih.Value = DateTime.Today; // datetime.Now yerine today daha uygun olabilir
            // DataGridView seçimini temizle
            dgvAtamalar.ClearSelection();
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvAtamalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir atama seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DataBoundItem'ı AtamaDisplayModel tipine dönüştür
            AtamaDisplayModel secilenAtamaDisplay = (AtamaDisplayModel)dgvAtamalar.SelectedRows[0].DataBoundItem;

            // ComboBox'tan geçerli bir seçim yapılmamışsa uyar
            if (cmbcalisansec.SelectedValue == null || cmbdemirbassec.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir çalışan ve demirbaş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Atama guncellenenAtama = new Atama
            {
                AtamaID = secilenAtamaDisplay.AtamaID, // AtamaDisplayModel'den AtamaID'yi kullan
                CalisanID = (int)cmbcalisansec.SelectedValue,
                DemirbasID = (int)cmbdemirbassec.SelectedValue,
                AtamaTarihi = dtpAtamatarih.Value,
                TeslimTarihi = secilenAtamaDisplay.TeslimTarihi // Mevcut TeslimTarihi'ni koru
            };
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("http://localhost:5011/api/atamalar/" + guncellenenAtama.AtamaID, guncellenenAtama);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Atama başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Güncelleme işleminden sonra listeleri ve ComboBox'ı yenile
                    await LoadDemirbaslarAsync(); // Demirbaşlar listesini günceller
                    await LoadAtamalarAsync();    // Atamalar DGV'sini günceller
                    btnTemizle_Click(null, null); // Alanları temizle
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Güncelleme işlemi sırasında hata oluştu: {response.StatusCode} - {errorContent}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDemirbaslarıAtama_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void dgvAtamalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}