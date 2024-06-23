using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Office.Utils;
using DevExpress.Utils.Extensions;

namespace _211116065_YusufDasdemir
{
    public partial class frmSatis : Form
    {
        private SqlConnection baglanti = new SqlConnection("Server=DASDEMJR\\SQLEXPRESS;Database=InternetCafe;Trusted_Connection=true");
        public frmSatis()
        {
            InitializeComponent();
        }

        private Button btn;

        private void SecileneGore(object sender, MouseEventArgs e)
        {
            btn = sender as Button;
            if (btn.BackColor == Color.OrangeRed)
            {
                süresliMasaAçmaİsteğiGönderToolStripMenuItem.Visible = false;
                süresizMasaAçmaİsteğiGönderToolStripMenuItem.Visible = false;
            }

            if (btn.BackColor == Color.LightGreen)
            {
                süresliMasaAçmaİsteğiGönderToolStripMenuItem.Visible = true;
                süresizMasaAçmaİsteğiGönderToolStripMenuItem.Visible = true;
            }
        }

        RadioButton radio;
        private void RadioButtonSeciliyeGore(object sender, EventArgs e)
        {
            radio = sender as RadioButton;
        }

        private void frmSatis_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'internetCafeDataSet.TBLSaatUcreti' table. You can move, or remove it, as needed.
            this.tBLSaatUcretiTableAdapter.Fill(this.internetCafeDataSet.TBLSaatUcreti);
            rbSuresiz.Checked = true;
            Yenile();
            cmbBosMasa.Text = null;
            timer1.Start();
        }

        public void Yenile()
        {
            #region Eski
            //baglanti.Open();
            //SqlDataAdapter adtr = new SqlDataAdapter("select * from TBLMasalar where Durumu = 'BOŞ'", baglanti);
            //DataTable tbl = new DataTable();
            //adtr.Fill(tbl);
            //cmbBosMasa.DataSource = tbl;
            //cmbBosMasa.DisplayMember = "Masalar";
            //cmbBosMasa.ValueMember = "MasaID";
            //baglanti.Close(); 
            #endregion

            foreach (Control groupBoxControl in groupBox1.Controls)
            {
                if (groupBoxControl is Button && groupBoxControl.Name != btnMasaAc.Name)
                {
                    try
                    {
                        Veritabani.baglanti.Open();
                        SqlCommand komut = new SqlCommand("SELECT * FROM TBLMasalar WHERE Masalar = @masaAdi", Veritabani.baglanti);
                        komut.Parameters.AddWithValue("@masaAdi", groupBoxControl.Text);
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            string durum = dr["Durumu"].ToString();
                            groupBoxControl.BackColor = durum == "BOŞ" ? Color.LightGreen : Color.OrangeRed;
                        }
                        else
                        {
                            MessageBox.Show("Masanın durumu bulunamadı: " + groupBoxControl.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                    finally
                    {
                        Veritabani.baglanti.Close();
                    }
                }
            }

            foreach (Control groupBoxControl in groupBox2.Controls)
            {
                if (groupBoxControl is Button && groupBoxControl.Name != btnMasaAc.Name)
                {
                    try
                    {
                        Veritabani.baglanti.Open();
                        SqlCommand komut = new SqlCommand("SELECT * FROM TBLMasalar WHERE Masalar = @masaAdi", Veritabani.baglanti);
                        komut.Parameters.AddWithValue("@masaAdi", groupBoxControl.Text);
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            string durum = dr["Durumu"].ToString();
                            groupBoxControl.BackColor = durum == "BOŞ" ? Color.LightGreen : Color.OrangeRed;
                        }
                        else
                        {
                            MessageBox.Show("Masanın durumu bulunamadı: " + groupBoxControl.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                    finally
                    {
                        Veritabani.baglanti.Close();
                    }
                }
            }


            Veritabani.SepetListele(dataGridView1);
            Veritabani.ComboyaBosMasaGetir(cmbBosMasa);
            Veritabani.ListViewdeKayitlariGoster(listView1);


            #region Hatalı

            //foreach (Control item in Controls)
            //{
            //    if (item is Button)
            //    {
            //        if (item.Name != btnMasaAc.Name)
            //        {
            //            baglanti.Open();
            //            SqlCommand komut = new SqlCommand("select * from TBLMasalar", baglanti);
            //            SqlDataReader dr = komut.ExecuteReader();
            //            while (dr.Read())
            //            {
            //                if (dr["Durumu"].ToString() == "BOŞ" && dr["Masalar"].ToString() == item.Text)
            //                {
            //                    item.BackColor = Color.LightGreen;
            //                }
            //                if (dr["Durumu"].ToString() == "DOLU" && dr["Masalar"].ToString() == item.Text)
            //                {
            //                    item.BackColor = Color.OrangeRed;
            //                }
            //            }
            //            baglanti.Close();
            //        }
            //    }
            //} 

            #endregion

        }

        private void btnMasaAc_Click(object sender, EventArgs e)
        {
            if (Kullanici.KullaniciID == 1)
            {
                string sqlSorgu = "insert into TBLSepet (MasaID,Masa,AcilisTuru,Baslangic,Tarih) values('" + cmbBosMasa.Text.Substring(5) + "','" + cmbBosMasa.Text + "','" + radio.Text + "','" + DateTime.Parse(DateTime.Now.ToString()) + "','" + DateTime.Parse(DateTime.Now.ToString()) + "')";
                SqlCommand komut = new SqlCommand();
                Veritabani.ESG(komut, sqlSorgu);
                MessageBox.Show(cmbBosMasa.Text.Substring(5) + " nolu masa açıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                rbSuresiz.Checked = true;
            }
            else
            {
                MessageBox.Show("Masa Açma yetkiniz bulunmuyor", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmSatis_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Hesapla"].Index)
            {
                if (cmbSaatUcreti.Text != "")
                {
                    DateTime BitisTarihi = DateTime.Now;
                    DateTime BaslangicTarihi = DateTime.Parse(dataGridView1.CurrentRow.Cells["BaslamaSaati"].Value.ToString());
                    TimeSpan saatFarki = BitisTarihi - BaslangicTarihi;
                    double saatfarki2 = saatFarki.TotalHours;
                    dataGridView1.CurrentRow.Cells["Sure"].Value = saatfarki2.ToString("0.00");
                    double toplamtutar = saatfarki2 * double.Parse(cmbSaatUcreti.Text);
                    dataGridView1.CurrentRow.Cells["Tutar"].Value = toplamtutar.ToString("0.00");
                    dataGridView1.CurrentRow.Cells["BitisSaati"].Value = BitisTarihi;
                }

                if (cmbSaatUcreti.Text == "")
                {
                    MessageBox.Show("Lütfen saat ücreti seçiniz");
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["MasaKapat"].Index)
            {
                if (dataGridView1.CurrentRow.Cells["BitisSaati"].Value != null)
                {
                    frmMasaKapat frm = new frmMasaKapat();
                    frm.txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    frm.txtMasaID.Text = dataGridView1.CurrentRow.Cells["_MasaID"].Value.ToString();
                    frm.txtMasa.Text = dataGridView1.CurrentRow.Cells["_Masa"].Value.ToString();
                    frm.txtAcilisTuru.Text = dataGridView1.CurrentRow.Cells["AcilisTuru"].Value.ToString();
                    frm.txtBaslamaSaati.Text = dataGridView1.CurrentRow.Cells["BaslamaSaati"].Value.ToString();
                    frm.txtBitisSaati.Text = dataGridView1.CurrentRow.Cells["BitisSaati"].Value.ToString();
                    frm.txtSure.Text = dataGridView1.CurrentRow.Cells["Sure"].Value.ToString();
                    frm.txtTutar.Text = dataGridView1.CurrentRow.Cells["Tutar"].Value.ToString();
                    frm.txtTarih.Text = dataGridView1.CurrentRow.Cells["_Tarih"].Value.ToString();
                    frm.txtSaatUcreti.Text = cmbSaatUcreti.Text;
                    frm.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells["BitisSaati"].Value == null)
                {
                    MessageBox.Show("Önce hesaplama işlemini yapınız", "UYARI", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private string istek = "";
        private void yöneticiCağırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            istek = "Yöneticiyi çağırıyor";
            Istekler();
        }

        private void Istekler()
        {
            string sqlSorgu = "insert into TBLHareketler (KullaniciID,MasaID,Masa,IstekTuru,Aciklama,Tarih) values('" + Kullanici.KullaniciID + "','" + btn.Text.Substring(5) + "','" + btn.Text + "','" + istek + "','Yapılmadı',@Tarih)";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@Tarih", DateTime.Parse(DateTime.Now.ToString()));
            Veritabani.ESG(komut, sqlSorgu);
            Veritabani.ListViewdeKayitlariGoster(listView1);
        }

        private void süresizMasaAçmaİsteğiGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            istek = "Süresiz masa açma isteği";
            Istekler();
        }

        private void masaDeğiştirmeİsteğiGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            istek = "Masa değiştirme talebinde bulundu";
            Istekler();
        }

        private ToolStripMenuItem item;
        private void SureliIstekSecilirse(object sender, EventArgs e)
        {
            item = sender as ToolStripMenuItem;
            istek = item.Text + " dk süre ile masa açma isteğinde bulundu";
            Istekler();
        }

        private int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac > 29)
            {
                if (cmbSaatUcreti.Text != "")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DateTime BitisTarihi = DateTime.Now;
                        DateTime BaslangicTarihi = DateTime.Parse(dataGridView1.Rows[i].Cells["BaslamaSaati"].Value.ToString());
                        TimeSpan saatFarki = BitisTarihi - BaslangicTarihi;
                        double saatfarki2 = saatFarki.TotalHours;
                        dataGridView1.Rows[i].Cells["Sure"].Value = saatfarki2.ToString("0.00");
                        double toplamtutar = saatfarki2 * double.Parse(cmbSaatUcreti.Text);
                        dataGridView1.Rows[i].Cells["Tutar"].Value = toplamtutar.ToString("0.00");
                        dataGridView1.Rows[i].Cells["BitisSaati"].Value = BitisTarihi;
                    }
                }

                if (cmbSaatUcreti.Text == "")
                {
                    MessageBox.Show("Lütfen saat ücreti seçiniz");
                }
            }
        }

        private void btnMasaDegistir_Click(object sender, EventArgs e)
        {
            int _SepetID = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            int _MasaID = int.Parse(dataGridView1.CurrentRow.Cells["_MasaID"].Value.ToString());
            string masaadi = dataGridView1.CurrentRow.Cells["_Masa"].Value.ToString();

            string sql = "update TBLSepet set MasaID = '" + int.Parse(cmbBosMasa.Text.Substring(5)) + "' , Masa = '" + cmbBosMasa.Text + "' where SepetID = '" + _SepetID + "' ";
            SqlCommand cmd = new SqlCommand();
            Veritabani.ESG(cmd, sql);
            ////////////////////////////////////

            string sql2 = "update TBLMasalar set Durumu = 'BOŞ' where MasaID = '" + _MasaID + "'";
            SqlCommand cmd2 = new SqlCommand();
            Veritabani.ESG(cmd2, sql2);
            ////////////////////////////////////

            string sql3 = "update TBLMasalar set Durumu = 'DOLU' where MasaID = '" + int.Parse(cmbBosMasa.Text.Substring(5)) + "'";
            SqlCommand cmd3 = new SqlCommand();
            Veritabani.ESG(cmd3, sql3);

            MessageBox.Show(masaadi + " " + cmbBosMasa.Text + " ile değiştirildi");
            Yenile();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Sure"].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells["AcilisTuru"].Value.ToString() != "Süresiz")
                    {
                        double sure = double.Parse(dataGridView1.Rows[i].Cells["Sure"].Value.ToString()) * 60;
                        double AcilisTuru = double.Parse(dataGridView1.Rows[i].Cells["AcilisTuru"].Value.ToString());
                        if (AcilisTuru - sure <= 5.0)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            frmSatislariListele frm = new frmSatislariListele();
            frm.btnGeriAl.Enabled = true;
            frm.ShowDialog();
        }

        private void btnSatisRapor_Click(object sender, EventArgs e)
        {
            frmSatisRaporu frm = new frmSatisRaporu();
            frm.ShowDialog();
        }

        private void btnHareketlerRapor_Click(object sender, EventArgs e)
        {
            frmHareketlerRaporu frm = new frmHareketlerRaporu();
            frm.ShowDialog();
        }
    }
}
