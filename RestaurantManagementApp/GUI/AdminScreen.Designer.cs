
namespace RestaurantManagementApp.GUI
{
    partial class AdminScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlWindow = new System.Windows.Forms.Panel();
            this.ControlBar = new System.Windows.Forms.TableLayoutPanel();
            this.btnMinimized = new System.Windows.Forms.PictureBox();
            this.btnMaximized = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.icoStatistical = new FontAwesome.Sharp.IconButton();
            this.icoDashboard = new FontAwesome.Sharp.IconButton();
            this.icoEmployee = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.icoLogout = new FontAwesome.Sharp.IconButton();
            this.picLogoHome = new System.Windows.Forms.PictureBox();
            this.icoMenu = new FontAwesome.Sharp.IconButton();
            this.btnNavigation = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.ControlBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pnlWindow);
            this.panel1.Controls.Add(this.ControlBar);
            this.panel1.Controls.Add(this.pnlMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 900);
            this.panel1.TabIndex = 0;
            // 
            // pnlWindow
            // 
            this.pnlWindow.BackColor = System.Drawing.Color.Transparent;
            this.pnlWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWindow.Location = new System.Drawing.Point(265, 36);
            this.pnlWindow.Name = "pnlWindow";
            this.pnlWindow.Size = new System.Drawing.Size(1335, 864);
            this.pnlWindow.TabIndex = 9;
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
            this.ControlBar.Controls.Add(this.btnMinimized, 2, 0);
            this.ControlBar.Controls.Add(this.btnMaximized, 4, 0);
            this.ControlBar.Controls.Add(this.btnExit, 6, 0);
            this.ControlBar.Controls.Add(this.lblTitle, 0, 0);
            this.ControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBar.Location = new System.Drawing.Point(265, 0);
            this.ControlBar.Margin = new System.Windows.Forms.Padding(0);
            this.ControlBar.Name = "ControlBar";
            this.ControlBar.RowCount = 1;
            this.ControlBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlBar.Size = new System.Drawing.Size(1335, 36);
            this.ControlBar.TabIndex = 8;
            this.ControlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlBar_MouseDown);
            // 
            // btnMinimized
            // 
            this.btnMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimized.Image = global::RestaurantManagementApp.Properties.Resources.MinimizeButton;
            this.btnMinimized.Location = new System.Drawing.Point(1228, 3);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(30, 30);
            this.btnMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimized.TabIndex = 1;
            this.btnMinimized.TabStop = false;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnMaximized
            // 
            this.btnMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximized.Image = global::RestaurantManagementApp.Properties.Resources.MaximizeButton;
            this.btnMaximized.Location = new System.Drawing.Point(1265, 3);
            this.btnMaximized.Name = "btnMaximized";
            this.btnMaximized.Size = new System.Drawing.Size(30, 30);
            this.btnMaximized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMaximized.TabIndex = 1;
            this.btnMaximized.TabStop = false;
            this.btnMaximized.Click += new System.EventHandler(this.btnMaximized_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::RestaurantManagementApp.Properties.Resources.CloseButton;
            this.btnExit.Location = new System.Drawing.Point(1302, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(81, 36);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "ADMIN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlMenu.Controls.Add(this.icoStatistical);
            this.pnlMenu.Controls.Add(this.icoDashboard);
            this.pnlMenu.Controls.Add(this.icoEmployee);
            this.pnlMenu.Controls.Add(this.panel4);
            this.pnlMenu.Controls.Add(this.picUser);
            this.pnlMenu.Controls.Add(this.icoLogout);
            this.pnlMenu.Controls.Add(this.picLogoHome);
            this.pnlMenu.Controls.Add(this.icoMenu);
            this.pnlMenu.Controls.Add(this.btnNavigation);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(265, 900);
            this.pnlMenu.TabIndex = 6;
            // 
            // icoStatistical
            // 
            this.icoStatistical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icoStatistical.FlatAppearance.BorderSize = 0;
            this.icoStatistical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoStatistical.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icoStatistical.ForeColor = System.Drawing.Color.White;
            this.icoStatistical.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.icoStatistical.IconColor = System.Drawing.Color.White;
            this.icoStatistical.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoStatistical.IconSize = 40;
            this.icoStatistical.Location = new System.Drawing.Point(5, 510);
            this.icoStatistical.Name = "icoStatistical";
            this.icoStatistical.Size = new System.Drawing.Size(253, 60);
            this.icoStatistical.TabIndex = 9;
            this.icoStatistical.Tag = "Hóa đơn";
            this.icoStatistical.Text = "     Hóa đơn     ";
            this.icoStatistical.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icoStatistical.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icoStatistical.UseVisualStyleBackColor = true;
            this.icoStatistical.Click += new System.EventHandler(this.icoStatistical_Click);
            // 
            // icoDashboard
            // 
            this.icoDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icoDashboard.FlatAppearance.BorderSize = 0;
            this.icoDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoDashboard.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icoDashboard.ForeColor = System.Drawing.Color.White;
            this.icoDashboard.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.icoDashboard.IconColor = System.Drawing.Color.White;
            this.icoDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoDashboard.IconSize = 40;
            this.icoDashboard.Location = new System.Drawing.Point(5, 440);
            this.icoDashboard.Name = "icoDashboard";
            this.icoDashboard.Size = new System.Drawing.Size(253, 60);
            this.icoDashboard.TabIndex = 8;
            this.icoDashboard.Tag = "Doanh thu";
            this.icoDashboard.Text = "     Doanh thu";
            this.icoDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icoDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icoDashboard.UseVisualStyleBackColor = true;
            this.icoDashboard.Click += new System.EventHandler(this.icoDashboard_Click);
            // 
            // icoEmployee
            // 
            this.icoEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icoEmployee.FlatAppearance.BorderSize = 0;
            this.icoEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoEmployee.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icoEmployee.ForeColor = System.Drawing.Color.White;
            this.icoEmployee.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.icoEmployee.IconColor = System.Drawing.Color.White;
            this.icoEmployee.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoEmployee.IconSize = 40;
            this.icoEmployee.Location = new System.Drawing.Point(5, 300);
            this.icoEmployee.Name = "icoEmployee";
            this.icoEmployee.Size = new System.Drawing.Size(253, 60);
            this.icoEmployee.TabIndex = 7;
            this.icoEmployee.Tag = "Nhân viên";
            this.icoEmployee.Text = "     Nhân viên";
            this.icoEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icoEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icoEmployee.UseVisualStyleBackColor = true;
            this.icoEmployee.Click += new System.EventHandler(this.icoEmployee_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.lbUsername);
            this.panel4.Controls.Add(this.lbName);
            this.panel4.Location = new System.Drawing.Point(82, 180);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(176, 78);
            this.panel4.TabIndex = 6;
            // 
            // lbUsername
            // 
            this.lbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.Cyan;
            this.lbUsername.Location = new System.Drawing.Point(3, 57);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(125, 21);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Tag = "a";
            this.lbUsername.Text = "Something here";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbName.Location = new System.Drawing.Point(3, 2);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(137, 22);
            this.lbName.TabIndex = 0;
            this.lbName.Tag = "a";
            this.lbName.Text = "Something here";
            // 
            // picUser
            // 
            this.picUser.Image = global::RestaurantManagementApp.Properties.Resources.User;
            this.picUser.Location = new System.Drawing.Point(4, 180);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(75, 78);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 5;
            this.picUser.TabStop = false;
            // 
            // icoLogout
            // 
            this.icoLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icoLogout.FlatAppearance.BorderSize = 0;
            this.icoLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoLogout.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icoLogout.ForeColor = System.Drawing.Color.White;
            this.icoLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.icoLogout.IconColor = System.Drawing.Color.White;
            this.icoLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoLogout.IconSize = 40;
            this.icoLogout.Location = new System.Drawing.Point(4, 803);
            this.icoLogout.Name = "icoLogout";
            this.icoLogout.Size = new System.Drawing.Size(258, 40);
            this.icoLogout.TabIndex = 4;
            this.icoLogout.Tag = "Đăng xuất";
            this.icoLogout.Text = "     Đăng xuất    ";
            this.icoLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icoLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icoLogout.UseVisualStyleBackColor = true;
            this.icoLogout.Click += new System.EventHandler(this.icoLogout_Click);
            // 
            // picLogoHome
            // 
            this.picLogoHome.Image = global::RestaurantManagementApp.Properties.Resources.Logo;
            this.picLogoHome.Location = new System.Drawing.Point(0, 0);
            this.picLogoHome.Name = "picLogoHome";
            this.picLogoHome.Size = new System.Drawing.Size(201, 179);
            this.picLogoHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogoHome.TabIndex = 1;
            this.picLogoHome.TabStop = false;
            this.picLogoHome.Click += new System.EventHandler(this.picLogoHome_Click);
            // 
            // icoMenu
            // 
            this.icoMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icoMenu.FlatAppearance.BorderSize = 0;
            this.icoMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoMenu.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icoMenu.ForeColor = System.Drawing.Color.White;
            this.icoMenu.IconChar = FontAwesome.Sharp.IconChar.ConciergeBell;
            this.icoMenu.IconColor = System.Drawing.Color.White;
            this.icoMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoMenu.IconSize = 40;
            this.icoMenu.Location = new System.Drawing.Point(5, 370);
            this.icoMenu.Name = "icoMenu";
            this.icoMenu.Size = new System.Drawing.Size(253, 60);
            this.icoMenu.TabIndex = 0;
            this.icoMenu.Tag = "Thực đơn";
            this.icoMenu.Text = "     Thực đơn";
            this.icoMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icoMenu.UseVisualStyleBackColor = true;
            this.icoMenu.Click += new System.EventHandler(this.icoMenu_Click);
            // 
            // btnNavigation
            // 
            this.btnNavigation.FlatAppearance.BorderSize = 0;
            this.btnNavigation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavigation.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btnNavigation.IconColor = System.Drawing.Color.White;
            this.btnNavigation.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNavigation.IconSize = 30;
            this.btnNavigation.Location = new System.Drawing.Point(207, 0);
            this.btnNavigation.Name = "btnNavigation";
            this.btnNavigation.Size = new System.Drawing.Size(47, 60);
            this.btnNavigation.TabIndex = 0;
            this.btnNavigation.Tag = " ";
            this.btnNavigation.UseVisualStyleBackColor = true;
            this.btnNavigation.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // AdminScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminScreen";
            this.Text = "AdminScreen";
            this.panel1.ResumeLayout(false);
            this.ControlBar.ResumeLayout(false);
            this.ControlBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlWindow;
        private System.Windows.Forms.TableLayoutPanel ControlBar;
        private System.Windows.Forms.PictureBox btnMinimized;
        private System.Windows.Forms.PictureBox btnMaximized;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMenu;
        private FontAwesome.Sharp.IconButton icoStatistical;
        private FontAwesome.Sharp.IconButton icoDashboard;
        private FontAwesome.Sharp.IconButton icoEmployee;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox picUser;
        private FontAwesome.Sharp.IconButton icoLogout;
        private System.Windows.Forms.PictureBox picLogoHome;
        private FontAwesome.Sharp.IconButton icoMenu;
        private FontAwesome.Sharp.IconButton btnNavigation;
    }
}