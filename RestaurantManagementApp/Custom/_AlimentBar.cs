using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.UtilityMethod;

namespace RestaurantManagementApp.Custom
{
    public delegate void UpdateTotal();
    public partial class _AlimentBar : UserControl
    {
        public event UpdateTotal UpdateTotal;
        public _AlimentBar()
        {
            InitializeComponent();
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            SetTextFont();
        }

        private void _AlimentBar_Load(object sender, EventArgs e)
        {
            List<AlimentSize> alimentSizes = AlimentSizeBusinessTier.GetAlimentSizes();
            foreach (var item in alimentSizes)
            {
                cboSize.Items.Add(item.SizeName);
            }
        }

        #region -> Properties
        [Category("GiangBui")]
        public string AlimentName
        {
            get => lblAlimentName.Text;
            set
            {
                lblAlimentName.Text = value;
            }
        }

        [Category("GiangBui")]
        public string Note
        {
            get => txtNote.Texts;
            set
            {
                txtNote.Texts = value;
            }
        }

        [Category("GiangBui")]
        public string Amount
        {
            get => txtAmount.Texts;
            set
            {
                txtAmount.Texts = value;
            }
        }

        [Category("GiangBui")]
        public string Price
        {
            get => txtPrice.Texts;
            set
            {
                txtPrice.Texts = value;
            }
        }

        [Category("GiangBui")]
        public string AlimentSize
        {
            get => cboSize.Texts;
            set
            {
                cboSize.Texts = value;
            }
        }

        [Category("GiangBui")]
        public string Total
        {
            get => txtTotal.Texts;
            set
            {
                txtTotal.Texts = value;
            }
        }
        #endregion

        #region Private Methods
        private void UpdateControlSize()
        {
            this.Height = pnlParent.Height + this.Padding.Top + this.Padding.Bottom;
            this.Width = pnlParent.Width + this.Padding.Left + this.Padding.Right;
        }

        private void SetTextFont()
        {
            lblAlimentName.Text = "";
            lblAlimentName.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            txtNote.Text = "";
            txtNote.Font = new Font("Times New Roman", 13, FontStyle.Italic);
        }
        #endregion

        #region Protected Methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlSize();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlSize();
        }
        #endregion

        private void btnMinus_Click(object sender, EventArgs e)
        {
            int temp = int.Parse(txtAmount.Texts);
            if (temp > 0)
            {
                txtAmount.Texts = (temp - 1).ToString();
            }
            txtTotal.Texts = (Convert.ToInt32(txtAmount.Texts) * Convert.ToInt32(txtPrice.Texts)).ToString();
            UpdateTotal();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtAmount.Texts = (int.Parse(txtAmount.Texts) + 1).ToString();
            txtTotal.Texts = (Convert.ToInt32(txtAmount.Texts) * Convert.ToInt32(txtPrice.Texts)).ToString();
            UpdateTotal();
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int percent = AlimentSizeBusinessTier.GetPercentIncrease(cboSize.Texts);
            txtTotal.Texts = (((int.Parse(txtPrice.Texts.ToString()) * percent * 1.0f) / 100) * int.Parse(txtAmount.Texts.ToString())).ToString();
            UpdateTotal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
    }
}
