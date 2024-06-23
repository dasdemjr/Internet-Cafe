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
    public partial class frmHareketlerRaporu : Form
    {
        public frmHareketlerRaporu()
        {
            InitializeComponent();
        }

        private void frmHareketlerRaporu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'InternetCafeDataSet.TBLHareketler' table. You can move, or remove it, as needed.
            this.TBLHareketlerTableAdapter.Fill(this.InternetCafeDataSet.TBLHareketler);

            this.reportViewer1.RefreshReport();
        }
    }
}
