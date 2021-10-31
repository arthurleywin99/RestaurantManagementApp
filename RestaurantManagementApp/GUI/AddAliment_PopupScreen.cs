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
using System.IO;

namespace RestaurantManagementApp.GUI
{
    public delegate void UpdateAliment();
    public partial class AddAliment_PopupScreen : Form
    {
        private string PATH;
        public event UpdateAliment UpdateAliment;
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
            Image = picAvatar_Popup.Image != null ? Utility.IMAGE_ALIMENT_PATH + txtName_Popup.Texts + Utility.IMAGE_EXTENSION : null,
            StillForSale = true
        };

        private void btnAdd_Popup_Click(object sender, EventArgs e)
        {
            #region Ràng Buộc Tên Món
            if (string.IsNullOrEmpty(txtName_Popup.Texts) || string.IsNullOrWhiteSpace(txtName_Popup.Texts))
            {
                MessageBox.Show("Tên món không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            #region Ràng Buộc Giá Tiền
            if (string.IsNullOrEmpty(txtPrice_Popup.Texts) || string.IsNullOrWhiteSpace(txtPrice_Popup.Texts))
            {
                MessageBox.Show("Giá tiền không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            bool check = int.TryParse(txtPrice_Popup.Texts, out _);
            if (!check)
            {
                MessageBox.Show("Giá tiền phải là số nguyên", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion

            if (AlimentBusinessTier.IsAlimentExist(GetAlimentFromForm))
            {
                MessageBox.Show("Hệ thống đã tồn tại thực đơn với dữ liệu này", "Existing Error", MessageBoxButtons.OK);
            }
            else
            {
                if (PATH != null)
                {
                    File.Copy(PATH, Path.Combine(Utility.IMAGE_ALIMENT_PATH, txtName_Popup.Texts + Utility.IMAGE_EXTENSION), true);
                }
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

        private void AddAliment_PopupScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAliment();
        }

        private void btnChooseImage_Popup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "JPG files|*.jpg|JPEG files|*.jpeg", Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PATH = openFile.FileName;
                    picAvatar_Popup.Image = Image.FromFile(openFile.FileName);
                }
            }
        }
    }
}
