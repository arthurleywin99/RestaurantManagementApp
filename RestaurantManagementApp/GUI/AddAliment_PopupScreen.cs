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

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public AddAliment_PopupScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        #region 2 NÚT TRÊN CONTROLBAR
        /// <summary>
        /// NÚT THU NHỎ CỬA SỔ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Minimized_Popup_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// NÚT THOÁT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Popup_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// SỰ KIỆN KÉO THẢ FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }
        #endregion

        #region SỰ KIỆN KHI LOAD VÀ CLOSE FORM
        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMenu_PopupScreen_Load(object sender, EventArgs e)
        {
            FillAlimentTypeCombobox();
        }
        /// <summary>
        /// SỰ KIỆN ĐÓNG FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAliment_PopupScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAliment();
        }
        #endregion

        /// <summary>
        /// ĐỔ DANH SÁCH LOẠI MÓN ĂN VÀO COMBOBOX
        /// </summary>
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

        /// <summary>
        /// LẤY DỮ LIỆU MÓN ĂN TỪ FORM
        /// </summary>
        private Aliment GetAlimentFromForm => new Aliment()
        {
            AlimentName = txtName_Popup.Texts,
            TypeID = AlimentTypeBusinessTier.GetAlimentTypeIDByName(cboType_Popup.Texts),
            Price = Convert.ToDecimal(txtPrice_Popup.Texts),
            Image = picAvatar_Popup.Image != null ? Utility.IMAGE_ALIMENT_PATH + txtName_Popup.Texts + Utility.IMAGE_EXTENSION : null,
            StillForSale = true
        };

        /// <summary>
        /// NÚT THÊM MÓN ĂN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// NÚT CHỌN ẢNH TỪ THƯ VIỆN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseImage_Popup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "JPG files|*.jpg|JPEG files|*.jpeg", Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PATH = openFile.FileName;
                    picAvatar_Popup.Image = Utility.LoadBitmapUnlocked(openFile.FileName);
                }
            }
        }

        /// <summary>
        /// NÚT HỦY BỎ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Popup_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ĐẶT TRẠNG THÁI CỦA CÁC CONTROL VỀ BAN ĐẦU
        /// </summary>
        private void ResetControl()
        {
            txtName_Popup.Texts = "";
            cboType_Popup.SelectedIndex = 0;
            txtPrice_Popup.Texts = "";
        }
    }
}
