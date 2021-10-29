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

namespace RestaurantManagementApp.GUI
{
    public delegate void UpdateUserInfo();
    public partial class ChangeInfo_PopupScreen : Form
    {
        public event UpdateUserInfo UpdateUserInfo;

        private User _User;
        public ChangeInfo_PopupScreen(User user)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _User = user;
        }

        private void ChangeInfo_PopupScreen_Load(object sender, EventArgs e)
        {
            BindingUserInfo();
        }

        private void BindingUserInfo()
        {
            picAvatar.Image = _User.Images == null ? null : Utility.Base64ToImage(_User.Images);
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

        private void ChangeInfo_PopupScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateUserInfo();
        }

        private void btnChooseImage_Child_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "JPG files|*.jpg|JPEG files|*.jpeg", Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    picAvatar.Image = Image.FromFile(openFile.FileName);
                }
            }
        }

        #region 2 nút Control
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utility.ReleaseCapture();
                Utility.SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }
        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Texts) || string.IsNullOrWhiteSpace(txtFullName.Texts))
            {
                MessageBox.Show("Họ tên không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            if (DateTime.Compare(dtpDate.Value, DateTime.Now) > 1)
            {
                MessageBox.Show("Thời gian không được lớn hơn ngày hiện hành", "Error", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtIDCard.Texts) || string.IsNullOrWhiteSpace(txtIDCard.Texts))
            {
                MessageBox.Show("Số chứng minh thư không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            string Error = string.Empty;
            if (UserBusinessTier.UpdateUser(txtUsername.Texts, GetUserFromForm, out Error))
            {
                MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK);
            }
        }

        private User GetUserFromForm => new User()
        {
            FullName = txtFullName.Texts,
            DateOfBirth = dtpDate.Value,
            Gender = rdMale.Checked,
            Address = txtAddress.Texts,
            IDCard = txtIDCard.Texts,
            RoleID = _User.RoleID,
            Password = txtNewPassword.Texts.Length == 0 ? null : txtNewPassword.Texts,
            Images = picAvatar.Image == null ? null : Utility.ImageToBase64(picAvatar.Image, ImageFormat.Jpeg)
        };

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
