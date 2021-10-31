
namespace RestaurantManagementApp.GUI
{
    partial class Report_PopupScreen
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
            this.InvoiceReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ControlBar = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnMinimized = new System.Windows.Forms.PictureBox();
            this.invoiceReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceReportBindingSource)).BeginInit();
            this.ControlBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).BeginInit();
            this.SuspendLayout();
            // 
            // InvoiceReportBindingSource
            // 
            this.InvoiceReportBindingSource.DataSource = typeof(RestaurantManagementApp.Model.InvoiceReport);
            // 
            // ControlBar
            // 
            this.ControlBar.BackColor = System.Drawing.Color.Transparent;
            this.ControlBar.ColumnCount = 7;
            this.ControlBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.ControlBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.ControlBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.ControlBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.ControlBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.ControlBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.ControlBar.Controls.Add(this.btnExit, 6, 0);
            this.ControlBar.Controls.Add(this.btnMinimized, 4, 0);
            this.ControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBar.Location = new System.Drawing.Point(0, 0);
            this.ControlBar.Margin = new System.Windows.Forms.Padding(0);
            this.ControlBar.Name = "ControlBar";
            this.ControlBar.RowCount = 1;
            this.ControlBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlBar.Size = new System.Drawing.Size(800, 36);
            this.ControlBar.TabIndex = 10;
            this.ControlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlBar_MouseDown);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::RestaurantManagementApp.Properties.Resources.CloseButton;
            this.btnExit.Location = new System.Drawing.Point(767, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimized
            // 
            this.btnMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimized.Image = global::RestaurantManagementApp.Properties.Resources.MinimizeButton;
            this.btnMinimized.Location = new System.Drawing.Point(730, 3);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(30, 30);
            this.btnMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimized.TabIndex = 1;
            this.btnMinimized.TabStop = false;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // invoiceReportViewer
            // 
            this.invoiceReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InvoiceDataSet";
            reportDataSource1.Value = this.InvoiceReportBindingSource;
            this.invoiceReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.invoiceReportViewer.LocalReport.ReportEmbeddedResource = "RestaurantManagementApp.Report.InvoiceReport.rdlc";
            this.invoiceReportViewer.Location = new System.Drawing.Point(0, 36);
            this.invoiceReportViewer.Name = "invoiceReportViewer";
            this.invoiceReportViewer.ServerReport.BearerToken = null;
            this.invoiceReportViewer.Size = new System.Drawing.Size(800, 414);
            this.invoiceReportViewer.TabIndex = 11;
            // 
            // Report_PopupScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.invoiceReportViewer);
            this.Controls.Add(this.ControlBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Report_PopupScreen";
            this.Text = "Report_PopupScreen";
            this.Load += new System.EventHandler(this.Report_PopupScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceReportBindingSource)).EndInit();
            this.ControlBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ControlBar;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox btnMinimized;
        private Microsoft.Reporting.WinForms.ReportViewer invoiceReportViewer;
        private System.Windows.Forms.BindingSource InvoiceReportBindingSource;
    }
}