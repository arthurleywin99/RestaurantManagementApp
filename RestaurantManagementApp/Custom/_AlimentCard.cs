using RestaurantManagementApp.UtilityMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementApp.Custom
{
    public partial class _AlimentCard : UserControl
    {
        public _AlimentCard()
        {
            InitializeComponent();
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            BackColor = Color.Wheat;
            SetTextFont();
        }

        #region Properties

        public string AlimentName
        {
            get => lblAlimentName.Text;
            set
            {
                lblAlimentName.Text = value;
            }
        }

        public string AlimentPrice
        {
            get => lblPrice.Text;
            set
            {
                lblPrice.Text = value;
            }
        }

        public Image AlimentPicture
        {
            get => picAliment.Image;
            set
            {
                picAliment.Image = value;
            }
        }
        #endregion

        private void SetTextFont()
        {
            lblAlimentName.Text = "";
            lblAlimentName.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            lblPrice.Text = "";
            lblPrice.Font = new Font("Times New Roman", 10, FontStyle.Bold);
        }

        private void picAliment_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
