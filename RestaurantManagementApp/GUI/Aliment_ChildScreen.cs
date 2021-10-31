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
using RestaurantManagementApp.Properties;

namespace RestaurantManagementApp.GUI
{
    public partial class Aliment_ChildScreen : Form
    {
        private string PATH;
        private bool isNewImage = false;

        public Aliment_ChildScreen()
        {
            InitializeComponent();
        }

        private void Aliment_ChildScreen_Load(object sender, EventArgs e)
        {
            FillTypeToComboBox();
            FillAlimentToComboBox();
        }

        private void cboAliment_Child_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindingAliment(AlimentBusinessTier.GetAlimentByName(cboAliment_Child.SelectedItem.ToString()));
        }

        private void FillTypeToComboBox()
        {
            List<AlimentType> types = AlimentTypeBusinessTier.GetAlimentTypes();
            foreach (var item in types)
            {
                cboType_Child.Items.Add(item.TypeName);
            }
        }

        private void BindingAliment(Aliment aliment)
        {
            txtName_Child.Texts = aliment.AlimentName;
            cboType_Child.Texts = AlimentTypeBusinessTier.GetAlimentTypeNameByID(Convert.ToInt32(aliment.TypeID));
            txtPrice_Child.Texts = aliment.Price.ToString();
            picAvatar_Child.Image = aliment.Image != null ? Utility.LoadBitmapUnlocked(aliment.Image) : null;
        }

        private void FillAlimentToComboBox()
        {
            cboAliment_Child.Items.Clear();
            List<Aliment> aliments = AlimentBusinessTier.GetAliments();
            foreach (var item in aliments)
            {
                if (item.StillForSale == true)
                {
                    cboAliment_Child.Items.Add(item.AlimentName);
                }
            }
            if (aliments.Count > 0) 
            { 
                cboAliment_Child.SelectedIndex = 0; 
            }
            else
            {
                ResetControl();
            }
        }

        private void ResetControl()
        {
            cboAliment_Child.Texts = "";
            txtName_Child.Texts = "";
            txtPrice_Child.Texts = "";
        }

        private Aliment GetDataFromForm => new Aliment()
        {
            AlimentName = txtName_Child.Texts,
            TypeID = AlimentTypeBusinessTier.GetAlimentTypeIDByName(cboType_Child.Texts),
            Price = Convert.ToDecimal(txtPrice_Child.Texts),
            Image = picAvatar_Child.Image != null ? Utility.IMAGE_ALIMENT_PATH + txtName_Child.Texts + Utility.IMAGE_EXTENSION : null
        };

        private void btnChooseImage_Child_Click(object sender, EventArgs e)
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

        private void btnSave_Child_Click(object sender, EventArgs e)
        {
            #region Ràng Buộc Tên Món
            if (string.IsNullOrEmpty(txtName_Child.Texts) || string.IsNullOrWhiteSpace(txtName_Child.Texts))
            {
                MessageBox.Show("Tên món không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            #region Ràng Buộc Giá Tiền
            if (string.IsNullOrEmpty(txtPrice_Child.Texts) || string.IsNullOrWhiteSpace(txtPrice_Child.Texts))
            {
                MessageBox.Show("Giá tiền không được để trống", "Error", MessageBoxButtons.OK);
                return;
            }
            bool check = int.TryParse(txtPrice_Child.Texts, out _);
            if (!check)
            {
                MessageBox.Show("Giá tiền phải là số nguyên", "Error", MessageBoxButtons.OK);
                return;
            }
            #endregion
            if (isNewImage)
            {
                File.Copy(PATH, Path.Combine(Utility.IMAGE_ALIMENT_PATH, txtName_Child.Texts + Utility.IMAGE_EXTENSION), true);
            }
            string Error = string.Empty;
            if (AlimentBusinessTier.UpdateAliment(cboAliment_Child.Texts, GetDataFromForm, out Error))
            {
                MessageBox.Show("Cập nhật thực đơn thành công", "Success", MessageBoxButtons.OK);
                isNewImage = false;
                FillAlimentToComboBox();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Mã lỗi: " + Error, "Failure", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Child_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn ngừng bán món này không?", "Deleting Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string error = string.Empty;
                if (AlimentBusinessTier.StopAliment(txtName_Child.Texts, out error))
                {
                    MessageBox.Show("Vô hiệu hóa thành công", "Success", MessageBoxButtons.OK);
                    FillAlimentToComboBox();
                }
                else
                {
                    MessageBox.Show(error, "Failure", MessageBoxButtons.OK);
                }
            }
            else
            {
                return;
            }
        }

        private void icoAdd_Child_Click(object sender, EventArgs e)
        {
            AddAliment_PopupScreen add = new AddAliment_PopupScreen();
            add.UpdateAliment += () => FillAlimentToComboBox();
            add.ShowDialog();
        }
    }
}
