using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.UtilityMethod;

namespace RestaurantManagementApp.GUI
{
    public partial class User_ChildScreen : Form, IRemoveFlicker
    {
        private string PATH;
        private bool isNewImage = false;

        public User_ChildScreen()
        {
            InitializeComponent(); 
        }

        private void Employee_ChildScreen_Load(object sender, EventArgs e)
        {
            RemoveFlicker();
            FillUserToComboBox();
            FilRoleToComboBox();
        }

        public void RemoveFlicker()
        {
            DoubleBuffered = true;
            Utility.EnableDoubleBuff(tableLayoutPanel1);
            Utility.EnableDoubleBuff(tableLayoutPanel2);
            Utility.EnableDoubleBuff(tableLayoutPanel3);
            Utility.EnableDoubleBuff(tableLayoutPanel4);
            Utility.EnableDoubleBuff(tableLayoutPanel5);
            Utility.EnableDoubleBuff(tableLayoutPanel6);
            Utility.EnableDoubleBuff(tableLayoutPanel7);
        }

        private void FillUserToComboBox()
        {
            cboUser_Child.Items.Clear();
            List<User> users = UserBusinessTier.GetUsers();
            foreach (var item in users)
            {
                cboUser_Child.Items.Add(item.Username);
            }
            if (users.Count > 0)
            {
                cboUser_Child.SelectedIndex = 0;
            }
            else
            {
                cboUser_Child.Texts = "";
            }
        }

        private void FilRoleToComboBox()
        {
            List<Role> roles = RoleBusinessTier.GetRoles();
            foreach (var item in roles)
            {
                cboType_Child.Items.Add(item.RoleName);
            }
            if (roles.Count > 0)
            {
                cboType_Child.SelectedIndex = 0;
            }
        }

        private void BindingUser(User user)
        {
            txtName_Child.Texts = user.FullName;
            dtpDate_Child.Value = user.DateOfBirth;
            if (user.Gender)
            {
                rdMale_Child.Checked = true;
            }
            else
            {
                rdFemale_Child.Checked = true;
            }
            txtAddress_Child.Texts = user.Address;
            txtCardID_Child.Texts = user.IDCard;
            picAvatar_Child.Image = user.Images != null ? Utility.LoadBitmapUnlocked(user.Images) : null;
            cboType_Child.Texts = RoleBusinessTier.GetRoleNameByRoleID(Convert.ToInt32(user.RoleID));
        }

        private void cboUser_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindingUser(UserBusinessTier.GetUserByUsername(cboUser_Child.SelectedItem.ToString()));
        }

        private void icoEye_Click(object sender, EventArgs e)
        {
            if (icoEye_Child.IconChar == FontAwesome.Sharp.IconChar.Eye)
            {
                icoEye_Child.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtPassword_Child.PasswordChar = true;
            }
            else
            {
                icoEye_Child.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtPassword_Child.PasswordChar = false;
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "JPG files|*.jpg|JPEG files|*.jpeg", Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PATH = openFile.FileName;
                    picAvatar_Child.Image = Image.FromFile(openFile.FileName);
                    isNewImage = true;
                }
            }
        }

        private void icoAdd_Click(object sender, EventArgs e)
        {
            new AddUser_PopupScreen().ShowDialog();
            FillUserToComboBox();
        }

        private void btnActiveDeactive_Click(object sender, EventArgs e)
        {
            string username = cboUser_Child.SelectedItem.ToString();
            if (UserBusinessTier.GetUserByUsername(username).IsActivated)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn hủy kích hoạt tài khoản này không?", "Deactive Command", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string Error = string.Empty;
                    if (UserBusinessTier.ActiveUser(username, false, Error))
                    {
                        MessageBox.Show("Tài khoản " + username + " được đã tạm khóa", "Success", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + Error, "Failure", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn kích hoạt lại tài khoản này không?", "Deactive Command", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string Error = string.Empty;
                    if (UserBusinessTier.ActiveUser(username, true, Error))
                    {
                        MessageBox.Show("Tài khoản " + username + " được đã được kích hoạt", "Success", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + Error, "Failure", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private User GetUserFromForm => new User()
        {
            FullName = txtName_Child.Texts,
            DateOfBirth = dtpDate_Child.Value.Date,
            Gender = rdMale_Child.Enabled ? true : false,
            Address = txtAddress_Child.Texts,
            IDCard = txtCardID_Child.Texts,
            Username = cboUser_Child.SelectedItem.ToString(),
            Password = txtPassword_Child.Texts.Length == 0 ? null : txtPassword_Child.Texts,
            RoleID = RoleBusinessTier.GetRoleIDByRoleName(cboType_Child.Texts),
            Images = picAvatar_Child.Image != null ? Utility.IMAGE_USER_PATH + cboUser_Child.SelectedItem.ToString() + Utility.IMAGE_EXTENSION : null
        };

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Ràng Buộc Họ Tên
            if (string.IsNullOrEmpty(txtName_Child.Texts) || string.IsNullOrWhiteSpace(txtName_Child.Texts))
            {
                MessageBox.Show("Họ tên không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!Regex.IsMatch(Utility.UnicodeToAscii(txtName_Child.Texts), @"^[A-Za-z ]+$"))
            {
                MessageBox.Show("Họ tên không chứa ký tự đặc biệt trừ Space", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            #region Ràng Buộc Ngày Tháng Năm Sinh
            if (DateTime.Compare(dtpDate_Child.Value, DateTime.Now) > 0)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            #region Ràng Buộc CMND
            if (string.IsNullOrEmpty(txtCardID_Child.Texts) || string.IsNullOrWhiteSpace(txtCardID_Child.Texts))
            {
                MessageBox.Show("CMND không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            if (txtCardID_Child.Texts.Any(ch => !char.IsDigit(ch)))
            {
                MessageBox.Show("CMND chỉ chứa các ký tự là số nguyên", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!(txtCardID_Child.Texts.Length == 9 || txtCardID_Child.Texts.Length == 12))
            {
                MessageBox.Show("CMND là một chuỗi có 9 hoặc 12 ký tự", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            string username = cboUser_Child.SelectedItem.ToString();
            string Error = string.Empty;
            
            if (isNewImage)
            {
                File.Copy(PATH, Path.Combine(Utility.IMAGE_USER_PATH, username + Utility.IMAGE_EXTENSION), true);
            }
            
            if (UserBusinessTier.UpdateUser(cboUser_Child.SelectedItem.ToString(), GetUserFromForm, out Error))
            {
                MessageBox.Show("Cập nhật người dùng thành công", "Success", MessageBoxButtons.OK);
                isNewImage = false;
            }
            else
            {
                MessageBox.Show("Cập nhật người dùng thất bại. Mã lỗi: " + Error, "Failure", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa người dùng " + cboUser_Child.SelectedItem.ToString() + " không?", "Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string Error = string.Empty;
                string ImagePath = UserBusinessTier.GetUserByUsername(cboUser_Child.SelectedItem.ToString()).Images;
                
                if (UserBusinessTier.DeleteUser(cboUser_Child.SelectedItem.ToString(), out Error))
                {
                    MessageBox.Show("Xóa người dùng thành công", "Success", MessageBoxButtons.OK);
                    FillUserToComboBox();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Mã lỗi: " + Error, "Failure", MessageBoxButtons.OK);
                }
            }
            else
            {
                return;
            }
        }

        private void ResetControl()
        {
            txtName_Child.Texts = "";
            dtpDate_Child.Value = DateTime.Now.Date;
            rdMale_Child.Enabled = true;
            txtAddress_Child.Texts = "";
            txtCardID_Child.Texts = "";
            txtPassword_Child.Texts = "";
            cboType_Child.SelectedIndex = 0;
            picAvatar_Child.Image = null;
        }
    }
}
