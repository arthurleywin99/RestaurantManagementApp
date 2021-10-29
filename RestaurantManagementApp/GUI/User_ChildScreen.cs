using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagementApp.BusinessTier;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.UtilityMethod;

namespace RestaurantManagementApp.GUI
{
    public partial class User_ChildScreen : Form, IRemoveFlicker
    {
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
            if (user.Images != null)
            {
                picAvatar_Child.Image = Utility.Base64ToImage(user.Images);
            }
            else
            {
                picAvatar_Child.Image = null;
            }
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
                    picAvatar_Child.Image = Image.FromFile(openFile.FileName);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            User newUser = new User()
            {
                FullName = txtName_Child.Texts,
                DateOfBirth = dtpDate_Child.Value.Date,
                Gender = rdMale_Child.Enabled ? true : false,
                Address = txtAddress_Child.Texts,
                IDCard = txtCardID_Child.Texts,
                Username = cboUser_Child.SelectedItem.ToString(),
                Password = txtPassword_Child.Texts,
                RoleID = RoleBusinessTier.GetRoleIDByRoleName(cboType_Child.Texts),
                Images = Utility.ImageToBase64(picAvatar_Child.Image, ImageFormat.Jpeg)
            };
            string username = cboUser_Child.SelectedItem.ToString();
            string Error = string.Empty;
            if (UserBusinessTier.UpdateUser(cboUser_Child.SelectedItem.ToString(), newUser, out Error))
            {
                MessageBox.Show("Cập nhật người dùng thành công", "Success", MessageBoxButtons.OK);
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
