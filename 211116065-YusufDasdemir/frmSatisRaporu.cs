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
    public partial class frmSatisRaporu : Form
    {
        public frmSatisRaporu()
        {
            InitializeComponent();
        }

        private void frmSatisRaporu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'InternetCafeDataSet.TBLSatis' table. You can move, or remove it, as needed.
            this.TBLSatisTableAdapter.Fill(this.InternetCafeDataSet.TBLSatis);

            this.reportViewer1.RefreshReport();
        }
    }
}
