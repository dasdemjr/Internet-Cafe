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

namespace _211116065_YusufDasdemir
{
    public partial class frmMasaKapat : Form
    {
        public frmMasaKapat()
        {
            InitializeComponent();
        }

        private void btnMasaKapat_Click(object sender, EventArgs e)
        {
            //string sqlSorgu = "update TBLMasalar set Durumu = 'BOŞ' where MasaID = '" + txtMasaID.Text + "'";
            //SqlCommand komut = new SqlCommand();
            //Veritabani.ESG(komut,sqlSorgu);
            //string sqlSorgu2 = "delete TBLSepet where SepetID = '"+txtID.Text+"'";
            //SqlCommand komut2 = new SqlCommand();
            //Veritabani.ESG(komut2,sqlSorgu2);

            string sorgu = "insert into TBLSatis (KullaniciID,MasaID,AcilisTuru,BaslangicSaati,BitisSaati,Sure,Tutar,Aciklama,Tarih) " +
                           "values ('" + Kullanici.KullaniciID + "','" + int.Parse(txtMasaID.Text) + "','" + txtAcilisTuru.Text + "',@Baslangic,@Bitis,@Sure,@Tutar,'Yapılmadı',@Tarih)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Baslangic", DateTime.Parse(txtBaslamaSaati.Text));
            cmd.Parameters.AddWithValue("@Bitis", DateTime.Parse(txtBitisSaati.Text));
            cmd.Parameters.AddWithValue("@Sure", Decimal.Parse(txtSure.Text));
            cmd.Parameters.AddWithValue("@Tutar", Decimal.Parse(txtTutar.Text));
            cmd.Parameters.AddWithValue("@Tarih", DateTime.Parse(txtTarih.Text));
            Veritabani.ESG(cmd, sorgu);


            frmSatis frm = (frmSatis)Application.OpenForms["frmSatis"];
            frm.Yenile();
            this.Close();

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
