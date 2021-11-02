
namespace RestaurantManagementApp.GUI
{
    partial class Order_PopupScreen
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
            this.ControlBar = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMinimized = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAlimentDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlAliment = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendChef = new RestaurantManagementApp.Custom._Button();
            this.txtEmployeeName = new RestaurantManagementApp.Custom._TextBox();
            this.btnUpdateInvoice = new RestaurantManagementApp.Custom._Button();
            this.txtExcessCash = new RestaurantManagementApp.Custom._TextBox();
            this.txtPay = new RestaurantManagementApp.Custom._TextBox();
            this.txtTotal = new RestaurantManagementApp.Custom._TextBox();
            this.btnPay = new RestaurantManagementApp.Custom._Button();
            this.cboAlimentType = new RestaurantManagementApp.Custom._Combobox();
            this.ControlBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnl.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
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
            this.ControlBar.Controls.Add(this.lblTitle, 0, 0);
            this.ControlBar.Controls.Add(this.btnMinimized, 4, 0);
            this.ControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBar.Location = new System.Drawing.Point(0, 0);
            this.ControlBar.Margin = new System.Windows.Forms.Padding(0);
            this.ControlBar.Name = "ControlBar";
            this.ControlBar.RowCount = 1;
            this.ControlBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlBar.Size = new System.Drawing.Size(1600, 36);
            this.ControlBar.TabIndex = 9;
            this.ControlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlBar_MouseDown);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::RestaurantManagementApp.Properties.Resources.CloseButton;
            this.btnExit.Location = new System.Drawing.Point(1567, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(85, 36);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "ORDER";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimized
            // 
            this.btnMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimized.Image = global::RestaurantManagementApp.Properties.Resources.MinimizeButton;
            this.btnMinimized.Location = new System.Drawing.Point(1530, 3);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(30, 30);
            this.btnMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimized.TabIndex = 1;
            this.btnMinimized.TabStop = false;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 864);
            this.panel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1600, 823);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.pnl);
            this.panel5.Controls.Add(this.pnlAliment);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1600, 761);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(804, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(6, 761);
            this.panel6.TabIndex = 3;
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.pnlAlimentDetails);
            this.pnl.Controls.Add(this.panel10);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(804, 761);
            this.pnl.TabIndex = 2;
            // 
            // pnlAlimentDetails
            // 
            this.pnlAlimentDetails.AutoScroll = true;
            this.pnlAlimentDetails.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlAlimentDetails.Location = new System.Drawing.Point(3, 3);
            this.pnlAlimentDetails.Name = "pnlAlimentDetails";
            this.pnlAlimentDetails.Size = new System.Drawing.Size(798, 509);
            this.pnlAlimentDetails.TabIndex = 0;
            this.pnlAlimentDetails.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlAlimentDetails_ControlAdded);
            this.pnlAlimentDetails.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlAlimentDetails_ControlRemoved);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.Control;
            this.panel10.Controls.Add(this.btnSendChef);
            this.panel10.Controls.Add(this.txtEmployeeName);
            this.panel10.Controls.Add(this.label10);
            this.panel10.Controls.Add(this.btnUpdateInvoice);
            this.panel10.Controls.Add(this.txtExcessCash);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.txtPay);
            this.panel10.Controls.Add(this.label8);
            this.panel10.Controls.Add(this.txtTotal);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Controls.Add(this.btnPay);
            this.panel10.Location = new System.Drawing.Point(3, 518);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(798, 285);
            this.panel10.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 22);
            this.label10.TabIndex = 10;
            this.label10.Text = "Nhân Viên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(391, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 22);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tiền Thừa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(389, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 22);
            this.label8.TabIndex = 5;
            this.label8.Text = "Khách Trả";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(389, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 22);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tổng Thành Tiền";
            // 
            // pnlAliment
            // 
            this.pnlAliment.AutoScroll = true;
            this.pnlAliment.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAliment.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAliment.Location = new System.Drawing.Point(810, 0);
            this.pnlAliment.Name = "pnlAliment";
            this.pnlAliment.Size = new System.Drawing.Size(790, 761);
            this.pnlAliment.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 761);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1600, 62);
            this.panel4.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1600, 41);
            this.panel2.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(804, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(6, 41);
            this.panel9.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cboAlimentType);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(810, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(790, 41);
            this.panel8.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(804, 41);
            this.panel7.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(195, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "SIZE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(358, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "SL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(476, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "ĐƠN GIÁ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(617, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "THÀNH TIỀN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "TÊN MÓN/GHI CHÚ";
            // 
            // btnSendChef
            // 
            this.btnSendChef.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnSendChef.BackgroundColor = System.Drawing.Color.MediumVioletRed;
            this.btnSendChef.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnSendChef.BorderRadius = 15;
            this.btnSendChef.BorderSize = 0;
            this.btnSendChef.FlatAppearance.BorderSize = 0;
            this.btnSendChef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendChef.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendChef.ForeColor = System.Drawing.Color.White;
            this.btnSendChef.Location = new System.Drawing.Point(196, 190);
            this.btnSendChef.Name = "btnSendChef";
            this.btnSendChef.Size = new System.Drawing.Size(314, 47);
            this.btnSendChef.TabIndex = 14;
            this.btnSendChef.Text = "Báo Chế Biến";
            this.btnSendChef.TextColor = System.Drawing.Color.White;
            this.btnSendChef.UseVisualStyleBackColor = false;
            this.btnSendChef.Click += new System.EventHandler(this.btnSendChef_Click);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmployeeName.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtEmployeeName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtEmployeeName.BorderRadius = 0;
            this.txtEmployeeName.BorderSize = 2;
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmployeeName.Location = new System.Drawing.Point(145, 49);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmployeeName.Multiline = false;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEmployeeName.PasswordChar = false;
            this.txtEmployeeName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmployeeName.PlaceholderText = "";
            this.txtEmployeeName.Size = new System.Drawing.Size(191, 36);
            this.txtEmployeeName.TabIndex = 11;
            this.txtEmployeeName.Texts = "";
            this.txtEmployeeName.UnderlinedStyle = false;
            // 
            // btnUpdateInvoice
            // 
            this.btnUpdateInvoice.BackColor = System.Drawing.Color.DarkBlue;
            this.btnUpdateInvoice.BackgroundColor = System.Drawing.Color.DarkBlue;
            this.btnUpdateInvoice.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnUpdateInvoice.BorderRadius = 15;
            this.btnUpdateInvoice.BorderSize = 0;
            this.btnUpdateInvoice.FlatAppearance.BorderSize = 0;
            this.btnUpdateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateInvoice.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInvoice.ForeColor = System.Drawing.Color.White;
            this.btnUpdateInvoice.Location = new System.Drawing.Point(196, 137);
            this.btnUpdateInvoice.Name = "btnUpdateInvoice";
            this.btnUpdateInvoice.Size = new System.Drawing.Size(314, 47);
            this.btnUpdateInvoice.TabIndex = 9;
            this.btnUpdateInvoice.Text = "Cập Nhật Hóa Đơn";
            this.btnUpdateInvoice.TextColor = System.Drawing.Color.White;
            this.btnUpdateInvoice.UseVisualStyleBackColor = false;
            this.btnUpdateInvoice.Click += new System.EventHandler(this.btnUpdateInvoice_Click);
            // 
            // txtExcessCash
            // 
            this.txtExcessCash.BackColor = System.Drawing.SystemColors.Window;
            this.txtExcessCash.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtExcessCash.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtExcessCash.BorderRadius = 0;
            this.txtExcessCash.BorderSize = 2;
            this.txtExcessCash.Enabled = false;
            this.txtExcessCash.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExcessCash.ForeColor = System.Drawing.Color.Red;
            this.txtExcessCash.Location = new System.Drawing.Point(549, 95);
            this.txtExcessCash.Margin = new System.Windows.Forms.Padding(4);
            this.txtExcessCash.Multiline = false;
            this.txtExcessCash.Name = "txtExcessCash";
            this.txtExcessCash.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtExcessCash.PasswordChar = false;
            this.txtExcessCash.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtExcessCash.PlaceholderText = "";
            this.txtExcessCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExcessCash.Size = new System.Drawing.Size(238, 37);
            this.txtExcessCash.TabIndex = 8;
            this.txtExcessCash.Texts = "0";
            this.txtExcessCash.UnderlinedStyle = false;
            // 
            // txtPay
            // 
            this.txtPay.BackColor = System.Drawing.SystemColors.Info;
            this.txtPay.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtPay.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPay.BorderRadius = 0;
            this.txtPay.BorderSize = 2;
            this.txtPay.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPay.ForeColor = System.Drawing.Color.Red;
            this.txtPay.Location = new System.Drawing.Point(549, 48);
            this.txtPay.Margin = new System.Windows.Forms.Padding(4);
            this.txtPay.Multiline = false;
            this.txtPay.Name = "txtPay";
            this.txtPay.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPay.PasswordChar = false;
            this.txtPay.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPay.PlaceholderText = "";
            this.txtPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPay.Size = new System.Drawing.Size(238, 37);
            this.txtPay.TabIndex = 6;
            this.txtPay.Texts = "0";
            this.txtPay.UnderlinedStyle = false;
            this.txtPay._TextChanged += new System.EventHandler(this.txtPay__TextChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotal.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtTotal.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTotal.BorderRadius = 0;
            this.txtTotal.BorderSize = 2;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Blue;
            this.txtTotal.Location = new System.Drawing.Point(549, 4);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Multiline = false;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTotal.PasswordChar = false;
            this.txtTotal.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTotal.PlaceholderText = "";
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(238, 37);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Texts = "";
            this.txtTotal.UnderlinedStyle = false;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.DarkRed;
            this.btnPay.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btnPay.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnPay.BorderRadius = 15;
            this.btnPay.BorderSize = 0;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(516, 139);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(271, 98);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "THANH TOÁN [F4]";
            this.btnPay.TextColor = System.Drawing.Color.White;
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // cboAlimentType
            // 
            this.cboAlimentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboAlimentType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboAlimentType.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cboAlimentType.BorderSize = 1;
            this.cboAlimentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboAlimentType.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlimentType.ForeColor = System.Drawing.Color.DimGray;
            this.cboAlimentType.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cboAlimentType.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cboAlimentType.ListTextColor = System.Drawing.Color.Black;
            this.cboAlimentType.Location = new System.Drawing.Point(55, 5);
            this.cboAlimentType.MinimumSize = new System.Drawing.Size(200, 30);
            this.cboAlimentType.Name = "cboAlimentType";
            this.cboAlimentType.Padding = new System.Windows.Forms.Padding(1);
            this.cboAlimentType.Size = new System.Drawing.Size(246, 30);
            this.cboAlimentType.TabIndex = 0;
            this.cboAlimentType.Texts = "";
            this.cboAlimentType.OnSelectedIndexChanged += new System.EventHandler(this.cboAlimentType_OnSelectedIndexChanged);
            // 
            // Order_PopupScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ControlBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Order_PopupScreen";
            this.Text = "Order_PopupScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Order_PopupScreen_FormClosed);
            this.Load += new System.EventHandler(this.Order_PopupScreen_Load);
            this.ControlBar.ResumeLayout(false);
            this.ControlBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnl.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ControlBar;
        private System.Windows.Forms.PictureBox btnMinimized;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.FlowLayoutPanel pnl;
        private System.Windows.Forms.FlowLayoutPanel pnlAliment;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private Custom._Combobox cboAlimentType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel pnlAlimentDetails;
        private System.Windows.Forms.Panel panel10;
        private Custom._Button btnPay;
        private Custom._TextBox txtTotal;
        private System.Windows.Forms.Label label7;
        private Custom._Button btnUpdateInvoice;
        private Custom._TextBox txtExcessCash;
        private System.Windows.Forms.Label label9;
        private Custom._TextBox txtPay;
        private System.Windows.Forms.Label label8;
        private Custom._TextBox txtEmployeeName;
        private System.Windows.Forms.Label label10;
        private Custom._Button btnSendChef;
    }
}