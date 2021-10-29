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
    public partial class _TableCard : UserControl
    {
        public _TableCard()
        {
            InitializeComponent();
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        #region Properties
        public string TableName
        {
            get => lblTableName.Text;
            set
            {
                lblTableName.Text = value;
            }
        }

        public Image TableImage
        {
            get => picTable.Image;
            set
            {
                picTable.Image = value;
            }
        }
        #endregion

        private void picTable_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
