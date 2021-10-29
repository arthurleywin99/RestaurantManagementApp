
namespace RestaurantManagementApp.Custom
{
    partial class _AlimentBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlParent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboSize = new RestaurantManagementApp.Custom._Combobox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMinus = new FontAwesome.Sharp.IconButton();
            this.txtAmount = new RestaurantManagementApp.Custom._TextBox();
            this.btnPlus = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPrice = new RestaurantManagementApp.Custom._TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotal = new RestaurantManagementApp.Custom._TextBox();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.tpnlFirst = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlimentName = new System.Windows.Forms.Label();
            this.txtNote = new RestaurantManagementApp.Custom._TextBox();
            this.pnlParent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpnlFirst.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParent
            // 
            this.pnlParent.Controls.Add(this.panel1);
            this.pnlParent.Controls.Add(this.tableLayoutPanel4);
            this.pnlParent.Controls.Add(this.tableLayoutPanel3);
            this.pnlParent.Controls.Add(this.tableLayoutPanel2);
            this.pnlParent.Controls.Add(this.tpnlFirst);
            this.pnlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParent.Location = new System.Drawing.Point(0, 0);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Size = new System.Drawing.Size(790, 65);
            this.pnlParent.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboSize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(383, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 65);
            this.panel1.TabIndex = 9;
            // 
            // cboSize
            // 
            this.cboSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboSize.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cboSize.BorderSize = 1;
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboSize.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSize.ForeColor = System.Drawing.Color.DimGray;
            this.cboSize.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cboSize.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cboSize.ListTextColor = System.Drawing.Color.DimGray;
            this.cboSize.Location = new System.Drawing.Point(6, 15);
            this.cboSize.MinimumSize = new System.Drawing.Size(30, 30);
            this.cboSize.Name = "cboSize";
            this.cboSize.Padding = new System.Windows.Forms.Padding(1);
            this.cboSize.Size = new System.Drawing.Size(72, 34);
            this.cboSize.TabIndex = 0;
            this.cboSize.Texts = "";
            this.cboSize.OnSelectedIndexChanged += new System.EventHandler(this.cboSize_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.btnMinus, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtAmount, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnPlus, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(261, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(122, 65);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinus.FlatAppearance.BorderSize = 0;
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.ForeColor = System.Drawing.Color.White;
            this.btnMinus.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinus.IconColor = System.Drawing.Color.Blue;
            this.btnMinus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinus.IconSize = 25;
            this.btnMinus.Location = new System.Drawing.Point(3, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(30, 59);
            this.btnMinus.TabIndex = 11;
            this.btnMinus.Tag = "";
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmount.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtAmount.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtAmount.BorderRadius = 0;
            this.txtAmount.BorderSize = 2;
            this.txtAmount.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtAmount.Location = new System.Drawing.Point(40, 13);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Multiline = false;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAmount.PasswordChar = false;
            this.txtAmount.PlaceholderColor = System.Drawing.Color.DarkOrange;
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.Size = new System.Drawing.Size(40, 39);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Texts = "";
            this.txtAmount.UnderlinedStyle = false;
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.FlatAppearance.BorderSize = 0;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.Color.White;
            this.btnPlus.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnPlus.IconColor = System.Drawing.Color.Blue;
            this.btnPlus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlus.IconSize = 25;
            this.btnPlus.Location = new System.Drawing.Point(87, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(32, 59);
            this.btnPlus.TabIndex = 10;
            this.btnPlus.Tag = "";
            this.btnPlus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Controls.Add(this.txtPrice, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(464, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(138, 65);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrice.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtPrice.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPrice.BorderRadius = 0;
            this.txtPrice.BorderSize = 2;
            this.txtPrice.Enabled = false;
            this.txtPrice.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.Color.DarkOrchid;
            this.txtPrice.Location = new System.Drawing.Point(31, 14);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPrice.PasswordChar = false;
            this.txtPrice.PlaceholderColor = System.Drawing.Color.DarkOrchid;
            this.txtPrice.PlaceholderText = "";
            this.txtPrice.Size = new System.Drawing.Size(103, 37);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Texts = "0";
            this.txtPrice.UnderlinedStyle = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.txtTotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(602, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(188, 65);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotal.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtTotal.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTotal.BorderRadius = 0;
            this.txtTotal.BorderSize = 2;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Red;
            this.txtTotal.Location = new System.Drawing.Point(22, 13);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Multiline = false;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTotal.PasswordChar = false;
            this.txtTotal.PlaceholderColor = System.Drawing.Color.Red;
            this.txtTotal.PlaceholderText = "";
            this.txtTotal.Size = new System.Drawing.Size(123, 39);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.Texts = "0";
            this.txtTotal.UnderlinedStyle = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnDelete.IconColor = System.Drawing.Color.Blue;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 25;
            this.btnDelete.Location = new System.Drawing.Point(152, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(33, 59);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Tag = "";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tpnlFirst
            // 
            this.tpnlFirst.ColumnCount = 1;
            this.tpnlFirst.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlFirst.Controls.Add(this.lblAlimentName, 0, 0);
            this.tpnlFirst.Controls.Add(this.txtNote, 0, 1);
            this.tpnlFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.tpnlFirst.Location = new System.Drawing.Point(0, 0);
            this.tpnlFirst.Name = "tpnlFirst";
            this.tpnlFirst.RowCount = 2;
            this.tpnlFirst.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tpnlFirst.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tpnlFirst.Size = new System.Drawing.Size(261, 65);
            this.tpnlFirst.TabIndex = 5;
            // 
            // lblAlimentName
            // 
            this.lblAlimentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAlimentName.AutoSize = true;
            this.lblAlimentName.Location = new System.Drawing.Point(3, 0);
            this.lblAlimentName.Name = "lblAlimentName";
            this.lblAlimentName.Size = new System.Drawing.Size(35, 26);
            this.lblAlimentName.TabIndex = 0;
            this.lblAlimentName.Text = "label1";
            this.lblAlimentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.BackColor = System.Drawing.SystemColors.Window;
            this.txtNote.BorderColor = System.Drawing.Color.Black;
            this.txtNote.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNote.BorderRadius = 0;
            this.txtNote.BorderSize = 2;
            this.txtNote.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNote.Location = new System.Drawing.Point(4, 32);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Multiline = false;
            this.txtNote.Name = "txtNote";
            this.txtNote.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNote.PasswordChar = false;
            this.txtNote.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNote.PlaceholderText = "";
            this.txtNote.Size = new System.Drawing.Size(253, 27);
            this.txtNote.TabIndex = 2;
            this.txtNote.Texts = "";
            this.txtNote.UnderlinedStyle = false;
            // 
            // _AlimentBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.pnlParent);
            this.Name = "_AlimentBar";
            this.Size = new System.Drawing.Size(790, 65);
            this.Load += new System.EventHandler(this._AlimentBar_Load);
            this.pnlParent.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tpnlFirst.ResumeLayout(false);
            this.tpnlFirst.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private _TextBox txtAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private _TextBox txtPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private _TextBox txtTotal;
        private System.Windows.Forms.TableLayoutPanel tpnlFirst;
        private System.Windows.Forms.Label lblAlimentName;
        private _TextBox txtNote;
        private FontAwesome.Sharp.IconButton btnPlus;
        private FontAwesome.Sharp.IconButton btnMinus;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.Panel panel1;
        private _Combobox cboSize;
    }
}
