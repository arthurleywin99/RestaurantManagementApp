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
    public partial class Aliment_ChildScreen : Form
    {
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
            if (aliment.Image != null)
            {
                picAvatar_Child.Image = Image.FromFile(aliment.Image);
            }
            else
            {
                picAvatar_Child.Image = null;
            }
        }

        private void FillAlimentToComboBox()
        {
            cboAliment_Child.Items.Clear();
            List<Aliment> aliments = AlimentBusinessTier.GetAliments();
            foreach (var item in aliments)
            {
                cboAliment_Child.Items.Add(item.AlimentName);
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
            Image = Utility.IMAGE_ALIMENT_PATH + AlimentBusinessTier.GetAlimentByName(txtName_Child.Texts).AlimentID.ToString() + Utility.IMAGE_EXTENSION
        };

        private void btnChooseImage_Child_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "JPG files|*.jpg|JPEG files|*.jpeg", Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    picAvatar_Child.Image = Image.FromFile(openFile.FileName);
                }
                File.Copy(openFile.FileName, Path.Combine(Utility.IMAGE_ALIMENT_PATH, Path.GetFileName(AlimentBusinessTier.GetAlimentByName(txtName_Child.Texts).AlimentID.ToString() + Utility.IMAGE_EXTENSION)), true);
            }
        }

        private void btnSave_Child_Click(object sender, EventArgs e)
        {
            string Error = string.Empty;
            if (AlimentBusinessTier.UpdateAliment(cboAliment_Child.Texts, GetDataFromForm, out Error))
            {
                MessageBox.Show("Cập nhật thực đơn thành công", "Success", MessageBoxButtons.OK);
                FillAlimentToComboBox();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Mã lỗi: " + Error, "Failure", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Child_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa món này khỏi hệ thống không?", "Deleting Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string error = string.Empty;
                if (AlimentBusinessTier.DeleteAliment(txtName_Child.Texts, out error))
                {
                    MessageBox.Show("Xóa thành công", "Success", MessageBoxButtons.OK);
                    File.Delete(AlimentBusinessTier.GetAlimentByName(txtName_Child.Texts).Image);
                    FillAlimentToComboBox();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Failure", MessageBoxButtons.OK);
                }
            }
            else
            {
                return;
            }
        }

        private void icoAdd_Child_Click(object sender, EventArgs e)
        {
            new AddAliment_PopupScreen().ShowDialog();
            FillAlimentToComboBox();
        }
    }
}
