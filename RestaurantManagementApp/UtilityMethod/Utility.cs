using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace RestaurantManagementApp.UtilityMethod
{
    public class Utility
    {
        public readonly static string CONNECTION_STRING = "data source=ARTHURLEYWIN;initial catalog=RestaurantManagement;integrated security=True;";
        public readonly static string VERSION = "VERSION 1.0";
        public readonly static string IMAGE_ALIMENT_PATH = @"D:\IMAGESERVER\Aliment\";
        public readonly static string IMAGE_USER_PATH = @"D:\IMAGESERVER\User\";
        public readonly static string IMAGE_EXTENSION = ".jpeg";
        public readonly static string CHEF_SCREEEN = "chef";
        public readonly static string EMPLOYEE_SCREEEN = "employee";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     
            int nTopRect,      
            int nRightRect,    
            int nBottomRect,   
            int nWidthEllipse, 
            int nHeightEllipse 
        );

        [DllImport("User32.dll")]
        public static extern void ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public static void EnableDoubleBuff(Control cont)
        {
            PropertyInfo DemoProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            DemoProp.SetValue(cont, true, null);
        }

        public struct RGBColors
        {
            public static Color Color1 = Color.FromArgb(172, 126, 241);
            public static Color Color2 = Color.FromArgb(249, 118, 176);
            public static Color Color3 = Color.FromArgb(253, 138, 114);
            public static Color Color4 = Color.FromArgb(95, 77, 251);
        }

        public static Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        private static readonly string[] VietNameseChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string UnicodeToAscii(string str)
        {
            for (int i = 1; i < VietNameseChar.Length; i++)
            {
                for (int j = 0; j < VietNameseChar[i].Length; j++)
                    str = str.Replace(VietNameseChar[i][j], VietNameseChar[0][i - 1]);
            }
            return str;
        }
    }
}
