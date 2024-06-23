using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211116065_YusufDasdemir
{
    public partial class frmKullanici : Form
    {
        public frmKullanici()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kullanici.KullaniciGirisi(txtKullaniciAdi, txtSifre);
            if (Kullanici.durum == true)
            {
                frmSatis frm = new frmSatis();
                frm.Show();
                this.Hide();
            }
            else if (Kullanici.durum == false)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre hatalı!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblSifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
