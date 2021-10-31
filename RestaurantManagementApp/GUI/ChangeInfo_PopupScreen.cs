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
using RestaurantManagementApp.Model;
using System.Drawing.Imaging;
using RestaurantManagementApp.BusinessTier;
using System.IO;
using System.Text.RegularExpressions;

namespace RestaurantManagementApp.GUI
{
    public delegate void UpdateUserInfo();
    public partial class ChangeInfo_PopupScreen : Form
    {
        public event UpdateUserInfo UpdateUserInfo;
        private string PATH;
        private bool isNewImage = false;
        private User _User;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="user"></param>
        public ChangeInfo_PopupScreen(User user)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _User = user;
        }

        #region SỰ KIỆN LOAD VÀ CLOSE FORM
        /// <summary>
        /// SỰ KIỆN LOAD FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeInfo_PopupScreen_Load(object sender, EventArgs e)
        {
            BindingUserInfo();
        }
        /// <summary>
        /// SỰ KIỆN ĐÓNG FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeInfo_PopupScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateUserInfo();
        }
        #endregion

        /// <summary>
        /// ĐỔ DỮ LIỆU VÀO CÁC CONTROL
        /// </summary>
        private void BindingUserInfo()
        {
            picAvatar.Image = _User.Images == null ? null : Utility.LoadBitmapUnlocked(_User.Images);
            txtUsername.Texts = _User.Username;
            txtFullName.Texts = _User.FullName;
            dtpDate.Value = _User.DateOfBirth;
            if (_User.Gender)
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
            txtAddress.Texts = _User.Address;
            txtIDCard.Texts = _User.IDCard;
        }
        
        /// <summary>
        /// CHỌN ẢNH TỪ THƯ VIỆN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseImage_Child_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "JPG files|*.jpg|JPEG files|*.jpeg", Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PATH = openFile.FileName;
                    picAvatar.Image = Image.FromFile(openFile.FileName);
                    isNewImage = true;
                }
            }
        }

        #region 2 NÚT CONTROL
        /// <summary>
        /// NÚT ĐÓNG FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// NÚT THU NHỎ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// KÉO THẢ FORM
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

        /// <summary>
        /// NÚT CẬP NHẬT THÔNG TIN NHÂN VIÊN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region Ràng Buộc Họ Tên
            if (string.IsNullOrEmpty(txtFullName.Texts) || string.IsNullOrWhiteSpace(txtFullName.Texts))
            {
                MessageBox.Show("Họ tên không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!Regex.IsMatch(Utility.UnicodeToAscii(txtFullName.Texts), @"^[A-Za-z ]+$"))
            {
                MessageBox.Show("Họ tên không chứa ký tự đặc biệt trừ Space", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            #region Ràng Buộc Ngày Tháng Năm Sinh
            if (DateTime.Compare(dtpDate.Value, DateTime.Now) > 0)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            #region Ràng Buộc CMND
            if (string.IsNullOrEmpty(txtIDCard.Texts) || string.IsNullOrWhiteSpace(txtIDCard.Texts))
            {
                MessageBox.Show("CMND không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            if (txtIDCard.Texts.Any(ch => !char.IsDigit(ch)))
            {
                MessageBox.Show("CMND chỉ chứa các ký tự là số nguyên", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!(txtIDCard.Texts.Length == 9 || txtIDCard.Texts.Length == 12))
            {
                MessageBox.Show("CMND là một chuỗi có 9 hoặc 12 ký tự", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion

            if (isNewImage)
            {
                File.Copy(PATH, Path.Combine(Utility.IMAGE_USER_PATH, txtUsername.Texts + Utility.IMAGE_EXTENSION), true);
            }
            string Error = string.Empty;
            if (UserBusinessTier.UpdateUser(txtUsername.Texts, GetUserFromForm, out Error))
            {
                MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButtons.OK);
                isNewImage = false;
                Close();
            }
            else
            {
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// LẤY DỮ LIỆU NHÂN VIÊN TỪ FORM
        /// </summary>
        private User GetUserFromForm => new User()
        {
            FullName = txtFullName.Texts,
            DateOfBirth = dtpDate.Value,
            Gender = rdMale.Checked,
            Address = txtAddress.Texts,
            IDCard = txtIDCard.Texts,
            RoleID = _User.RoleID,
            Password = txtNewPassword.Texts.Length == 0 ? null : txtNewPassword.Texts,
            Images = picAvatar.Image == null ? null : Utility.IMAGE_USER_PATH + txtUsername.Texts + Utility.IMAGE_EXTENSION
        };

        /// <summary>
        /// NÚT HỦY BỎ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// NÚT ĐÓNG/MỞ XEM MẬT KHẨU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void icoEye_Popup_Click(object sender, EventArgs e)
        {
            if (icoEye_Popup.IconChar == FontAwesome.Sharp.IconChar.Eye)
            {
                icoEye_Popup.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtNewPassword.PasswordChar = true;
            }
            else
            {
                icoEye_Popup.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtNewPassword.PasswordChar = false;
            }
        }
    }
}
