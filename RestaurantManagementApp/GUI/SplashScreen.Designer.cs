
namespace RestaurantManagementApp.GUI
{
    partial class SplashScreen
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
            this.timerSplashScreen = new System.Windows.Forms.Timer(this.components);
            this.pnlTotal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.tbPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.tbPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pnlTotal.SuspendLayout();
            this.tbPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            this.tbPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerSplashScreen
            // 
            this.timerSplashScreen.Enabled = true;
            this.timerSplashScreen.Interval = 15;
            this.timerSplashScreen.Tick += new System.EventHandler(this.timerSplashScreen_Tick);
            // 
            // pnlTotal
            // 
            this.pnlTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotal.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotal.ColumnCount = 1;
            this.pnlTotal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTotal.Controls.Add(this.pnlLoad, 0, 3);
            this.pnlTotal.Controls.Add(this.tbPanel2, 0, 1);
            this.pnlTotal.Controls.Add(this.tbPanel1, 0, 2);
            this.pnlTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.RowCount = 4;
            this.pnlTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.pnlTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlTotal.Size = new System.Drawing.Size(801, 450);
            this.pnlTotal.TabIndex = 2;
            // 
            // pnlLoad
            // 
            this.pnlLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlLoad.Location = new System.Drawing.Point(0, 430);
            this.pnlLoad.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(19, 20);
            this.pnlLoad.TabIndex = 2;
            // 
            // tbPanel2
            // 
            this.tbPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPanel2.ColumnCount = 3;
            this.tbPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbPanel2.Controls.Add(this.picBox1, 1, 0);
            this.tbPanel2.Location = new System.Drawing.Point(3, 46);
            this.tbPanel2.Name = "tbPanel2";
            this.tbPanel2.RowCount = 1;
            this.tbPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPanel2.Size = new System.Drawing.Size(795, 295);
            this.tbPanel2.TabIndex = 0;
            // 
            // picBox1
            // 
            this.picBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBox1.Image = global::RestaurantManagementApp.Properties.Resources.Logo;
            this.picBox1.Location = new System.Drawing.Point(241, 3);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(312, 289);
            this.picBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox1.TabIndex = 0;
            this.picBox1.TabStop = false;
            // 
            // tbPanel1
            // 
            this.tbPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPanel1.ColumnCount = 1;
            this.tbPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPanel1.Controls.Add(this.lblVersion, 0, 1);
            this.tbPanel1.Controls.Add(this.lblCopyright, 0, 0);
            this.tbPanel1.Location = new System.Drawing.Point(3, 347);
            this.tbPanel1.Name = "tbPanel1";
            this.tbPanel1.RowCount = 2;
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbPanel1.Size = new System.Drawing.Size(795, 80);
            this.tbPanel1.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Red;
            this.lblVersion.Location = new System.Drawing.Point(698, 50);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(94, 30);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Something here";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(3, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(789, 50);
            this.lblCopyright.TabIndex = 3;
            this.lblCopyright.Text = "SOMETHING HERE";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.pnlTotal.ResumeLayout(false);
            this.tbPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            this.tbPanel1.ResumeLayout(false);
            this.tbPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerSplashScreen;
        private System.Windows.Forms.TableLayoutPanel pnlTotal;
        private System.Windows.Forms.TableLayoutPanel tbPanel2;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TableLayoutPanel tbPanel1;
        private System.Windows.Forms.Panel pnlLoad;
        private System.Windows.Forms.Label lblCopyright;
    }
}