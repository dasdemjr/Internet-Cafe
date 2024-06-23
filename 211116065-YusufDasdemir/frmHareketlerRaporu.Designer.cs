namespace _211116065_YusufDasdemir
{
    partial class frmHareketlerRaporu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InternetCafeDataSet = new _211116065_YusufDasdemir.InternetCafeDataSet();
            this.TBLHareketlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TBLHareketlerTableAdapter = new _211116065_YusufDasdemir.InternetCafeDataSetTableAdapters.TBLHareketlerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InternetCafeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLHareketlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TBLHareketlerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "_211116065_YusufDasdemir.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // InternetCafeDataSet
            // 
            this.InternetCafeDataSet.DataSetName = "InternetCafeDataSet";
            this.InternetCafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TBLHareketlerBindingSource
            // 
            this.TBLHareketlerBindingSource.DataMember = "TBLHareketler";
            this.TBLHareketlerBindingSource.DataSource = this.InternetCafeDataSet;
            // 
            // TBLHareketlerTableAdapter
            // 
            this.TBLHareketlerTableAdapter.ClearBeforeFill = true;
            // 
            // frmHareketlerRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHareketlerRaporu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hareket Raporu ";
            this.Load += new System.EventHandler(this.frmHareketlerRaporu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InternetCafeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLHareketlerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TBLHareketlerBindingSource;
        private InternetCafeDataSet InternetCafeDataSet;
        private InternetCafeDataSetTableAdapters.TBLHareketlerTableAdapter TBLHareketlerTableAdapter;
    }
}