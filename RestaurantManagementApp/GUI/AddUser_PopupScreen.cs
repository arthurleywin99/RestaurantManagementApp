using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.UtilityMethod;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.BusinessTier;
using System.Drawing.Imaging;
using System.IO;

namespace RestaurantManagementApp.GUI
{
    public partial class AddUser_PopupScreen : Form
    {
        private string PATH;

        public AddUser_PopupScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(Utility.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            FillRoleCombobox();
        }

        private void FillRoleCombobox()
        {
            List<Role> roles = RoleBusinessTier.GetRoles();
            foreach (var item in roles)
            {
                cboType_Popup.Items.Add(item.RoleName);
            }
            if (roles.Count > 0)
            {
                cboType_Popup.SelectedIndex = 0;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private User GetUserFromForm => new User()
        {
            FullName = txtFullName_Popup.Texts,
            DateOfBirth = dtpDate_Popup.Value.Date,
            Gender = rdMale_Popup.Enabled ? true : false,
            Address = txtAddress_Popup.Texts,
            IDCard = txtCardID_Popup.Texts,
            Username = txtUsername_Popup.Texts,
            Password = Utility.MD5Hash(txtPassword_Popup.Texts),
            Images = picAvatar_Popup.Image != null ? Utility.IMAGE_USER_PATH + txtUsername_Popup.Texts + Utility.IMAGE_EXTENSION : null,
            RoleID = RoleBusinessTier.GetRoleIDByRoleName(cboType_Popup.Texts),
            IsActivated = true
        };

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UserBusinessTier.IsUserExisted(txtUsername_Popup.Texts))
            {
                MessageBox.Show("Hệ thống đã tồn tại username này", "Existing Error", MessageBoxButtons.OK);
            }
            else
            {
                if (PATH != null)
                {
                    File.Copy(PATH, Path.Combine(Utility.IMAGE_USER_PATH, txtUsername_Popup.Texts + Utility.IMAGE_EXTENSION), true);
                }
                string Error = string.Empty;
                if (UserBusinessTier.AddUser(GetUserFromForm, out Error))
                {
                    MessageBox.Show("Thêm người dùng thành công", "Success", MessageBoxButtons.OK);
                    ResetControl();
                }
                else
                {
                    MessageBox.Show(Error, "Failure", MessageBoxButtons.OK);
                }
            }
        }

        private void icoEye_Click(object sender, EventArgs e)
        {
            if (icoEye_Popup.IconChar == FontAwesome.Sharp.IconChar.Eye)
            {
                icoEye_Popup.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtPassword_Popup.PasswordChar = true;
            }
            else
            {
                icoEye_Popup.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtPassword_Popup.PasswordChar = false;
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "JPG files|*.jpg|JPEG files|*.jpeg|PNG files|*.png|All files|*.*", Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PATH = openFile.FileName;
                    picAvatar_Popup.Image = Image.FromFile(openFile.FileName);
                }
            }
        }

        private void ResetControl()
        {
            txtUsername_Popup.Texts = "";
            txtPassword_Popup.Texts = "";
            txtCardID_Popup.Texts = "";
            txtFullName_Popup.Texts = "";
            dtpDate_Popup.Value = DateTime.Now.Date;
            rdMale_Popup.Enabled = true;
            cboType_Popup.SelectedIndex = 0;
            picAvatar_Popup.Image = null;
        }
    }
}
