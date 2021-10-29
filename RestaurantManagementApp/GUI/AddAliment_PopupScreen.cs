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
using System.Drawing.Imaging;

namespace RestaurantManagementApp.GUI
{
    public partial class AddAliment_PopupScreen : Form
    {
        public AddAliment_PopupScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void AddMenu_PopupScreen_Load(object sender, EventArgs e)
        {
            FillAlimentTypeCombobox();
        }

        private void FillAlimentTypeCombobox()
        {
            List<AlimentType> alimentTypes = AlimentTypeBusinessTier.GetAlimentTypes();
            foreach (var item in alimentTypes)
            {
                cboType_Popup.Items.Add(item.TypeName);
            }
            if (alimentTypes.Count > 0)
            {
                cboType_Popup.SelectedIndex = 0;
            }
        }

        private void btnExit_Popup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Aliment GetAlimentFromForm => new Aliment()
        {
            AlimentName = txtName_Popup.Texts,
            TypeID = AlimentTypeBusinessTier.GetAlimentTypeIDByName(cboType_Popup.Texts),
            Price = Convert.ToDecimal(txtPrice_Popup.Texts),
            Image = picAvatar_Popup.Image != null ? Utility.ImageToBase64(picAvatar_Popup.Image, ImageFormat.Jpeg) : null
        };

        private void btnAdd_Popup_Click(object sender, EventArgs e)
        {
            if (AlimentBusinessTier.IsAlimentExist(GetAlimentFromForm))
            {
                MessageBox.Show("Hệ thống đã tồn tại thực đơn với dữ liệu này", "Existing Error", MessageBoxButtons.OK);
            }
            else
            {
                string Error = string.Empty;
                if (AlimentBusinessTier.AddAliment(GetAlimentFromForm, out Error))
                {
                    MessageBox.Show("Thêm thực đơn mới thành công", "Success", MessageBoxButtons.OK);
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Mã lỗi: " + Error, "Failure", MessageBoxButtons.OK);
                }
            }
        }

        private void btnCancel_Popup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetControl()
        {
            txtName_Popup.Texts = "";
            cboType_Popup.SelectedIndex = 0;
            txtPrice_Popup.Texts = "";
        }
    }
}
