using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurumsalYonetim
{
    public partial class FormDemirbaslarıAtama : Form
    {
        private readonly HttpClient client = new HttpClient();
        private List<Calisan> _calisanlarCache;
        private List<Demirbas> _demirbaslarCache;
        private List<Demirbas> _availableDemirbaslarForComboBox;

        public FormDemirbaslarıAtama()
        {
            InitializeComponent();
            this.Load += FormDemirbaslarıAtama_Load;
            dgvAtamalar.SelectionChanged += dgvAtamalar_SelectionChanged;
        }

        public class Atama
        {
            public int AtamaID { get; set; }
            public int DemirbasID { get; set; }
            public int CalisanID { get; set; }
            public DateTime AtamaTarihi { get; set; }
            public DateTime? TeslimTarihi { get; set; }
        }

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

        public class Demirbas
        {
            public int DemirbasID { get; set; }
            public string DemirbasAdi { get; set; }
            public string SeriNo { get; set; }
        }

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

            public int OriginalCalisanID { get; set; }
            public int OriginalDemirbasID { get; set; }
        }

        private async Task LoadAtamalarAsync()
        {
            if (_calisanlarCache == null || !_calisanlarCache.Any())
            {
                await LoadCalisanAsync();
            }

            List<Atama> atamaListesi = await client.GetFromJsonAsync<List<Atama>>("http://localhost:5011/api/atamalar");

            List<AtamaDisplayModel> displayList = atamaListesi.Select(a => new AtamaDisplayModel
            {
                AtamaID = a.AtamaID,
                CalisanAdSoyad = _calisanlarCache?.FirstOrDefault(c => c.CalisanID == a.CalisanID)?.TamAd ?? "Bilinmiyor",
                DemirbasAdi = _demirbaslarCache?.FirstOrDefault(d => d.DemirbasID == a.DemirbasID)?.DemirbasAdi ?? "Bilinmiyor",
                AtamaTarihi = a.AtamaTarihi,
                TeslimTarihi = a.TeslimTarihi,
                OriginalCalisanID = a.CalisanID,
                OriginalDemirbasID = a.DemirbasID
            }).ToList();

            dgvAtamalar.DataSource = displayList;
            dgvAtamalar.AutoGenerateColumns = true;

            if (dgvAtamalar.Columns.Contains("OriginalCalisanID"))
            {
                dgvAtamalar.Columns["OriginalCalisanID"].Visible = false;
            }
            if (dgvAtamalar.Columns.Contains("OriginalDemirbasID"))
            {
                dgvAtamalar.Columns["OriginalDemirbasID"].Visible = false;
            }
            if (dgvAtamalar.Columns.Contains("AtamaID"))
            {
                dgvAtamalar.Columns["AtamaID"].Visible = false;
            }

        }

        private async void FormDemirbaslarıAtama_Load(object sender, EventArgs e)
        {
            await LoadCalisanAsync();
            await LoadDemirbaslarAsync();
            await LoadAtamalarAsync();

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
            List<Demirbas> allDemirbaslar = await client.GetFromJsonAsync<List<Demirbas>>("http://localhost:5011/api/demirbaslar");
            _demirbaslarCache = allDemirbaslar;

            List<Atama> allAtamalar = await client.GetFromJsonAsync<List<Atama>>("http://localhost:5011/api/atamalar");

            HashSet<int> assignedDemirbasIds = new HashSet<int>(
                allAtamalar.Where(a => a.TeslimTarihi == null)
                           .Select(a => a.DemirbasID));

            _availableDemirbaslarForComboBox = allDemirbaslar
                .Where(d => !assignedDemirbasIds.Contains(d.DemirbasID))
                .ToList();

            cmbdemirbassec.DataSource = _availableDemirbaslarForComboBox;
            cmbdemirbassec.DisplayMember = "DemirbasAdi";
            cmbdemirbassec.ValueMember = "DemirbasID";
        }

        private async void btnAta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbcalisansec.SelectedValue == null || cmbdemirbassec.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir çalışan ve demirbaş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Atama atama = new Atama();
                atama.CalisanID = (int)cmbcalisansec.SelectedValue;
                atama.DemirbasID = (int)cmbdemirbassec.SelectedValue;
                atama.AtamaTarihi = dtpAtamatarih.Value;
                atama.TeslimTarihi = null;

                HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:5011/api/atamalar", atama);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Atama başarıyla yapıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadDemirbaslarAsync();
                    await LoadAtamalarAsync();
                    btnTemizle_Click(null, null);
                }
                else
                {
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
                HttpResponseMessage response = await client.PutAsync(
                    $"http://localhost:5011/api/atamalar/teslim/{secilenAtamaDisplay.AtamaID}", null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Demirbaş başarıyla teslim edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDemirbaslarAsync();
                    await LoadAtamalarAsync();
                    btnTemizle_Click(null, null);
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
            cmbcalisansec.SelectedIndex = -1;
            cmbdemirbassec.SelectedIndex = -1;
            dtpAtamatarih.Value = DateTime.Today;
            dgvAtamalar.ClearSelection();
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvAtamalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir atama seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AtamaDisplayModel secilenAtamaDisplay = (AtamaDisplayModel)dgvAtamalar.SelectedRows[0].DataBoundItem;

            if (cmbcalisansec.SelectedValue == null || cmbdemirbassec.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir çalışan ve demirbaş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Atama guncellenenAtama = new Atama
            {
                AtamaID = secilenAtamaDisplay.AtamaID,
                CalisanID = (int)cmbcalisansec.SelectedValue,
                DemirbasID = (int)cmbdemirbassec.SelectedValue,
                AtamaTarihi = dtpAtamatarih.Value,
                TeslimTarihi = secilenAtamaDisplay.TeslimTarihi
            };
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("http://localhost:5011/api/atamalar/" + guncellenenAtama.AtamaID, guncellenenAtama);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Atama başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadDemirbaslarAsync();
                    await LoadAtamalarAsync();
                    btnTemizle_Click(null, null);
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
