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
    public partial class frmSatislariListele : Form
    {
        public frmSatislariListele()
        {
            InitializeComponent();
        }

        private void frmSatislariListele_Load(object sender, EventArgs e)
        {
            Veritabani.Listele(dataGridView1, "select * from TBLSatis");
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            int masaID = int.Parse(dataGridView1.CurrentRow.Cells["MasaID"].Value.ToString());
            int kullaniciID = int.Parse(dataGridView1.CurrentRow.Cells["KullaniciID"].Value.ToString());
            string masa = "MASA-" + masaID;
            string acilisTuru = dataGridView1.CurrentRow.Cells["AcilisTuru"].Value.ToString();
            DateTime baslangic = DateTime.Parse(dataGridView1.CurrentRow.Cells["BaslangicSaati"].Value.ToString());
            DateTime tarih = DateTime.Parse(dataGridView1.CurrentRow.Cells["Tarih"].Value.ToString());


            string sqlSorgu = "insert into TBLSepet(MasaID,Masa,AcilisTuru,Baslangic,Tarih) values(@MasaID, @Masa, @AcilisTuru, @Baslangic, @Tarih)";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@MasaID", masaID);
            komut.Parameters.AddWithValue("@Masa", masa);
            komut.Parameters.AddWithValue("@AcilisTuru", acilisTuru);
            komut.Parameters.AddWithValue("@Baslangic", baslangic);
            komut.Parameters.AddWithValue("@Tarih", tarih);
            Veritabani.ESG(komut,sqlSorgu);

            /////////////////////////////////

            string sorgu = "delete from TBLSatis where SatisID = '" + int.Parse(dataGridView1.CurrentRow.Cells["SatisID"].Value.ToString()) +"'";
            SqlCommand cmd = new SqlCommand();
            Veritabani.ESG(cmd,sorgu);

            this.Close();
            frmSatis frm = (frmSatis)Application.OpenForms["frmSatis"];
            frm.Yenile();
        }
    }
}
