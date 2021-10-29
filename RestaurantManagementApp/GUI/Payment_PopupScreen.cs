using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementApp.GUI
{
    public partial class Payment_PopupScreen : Form
    {
        private int _TableID;
        private string _Username;
        public Payment_PopupScreen()
        {
            InitializeComponent();
        }

        public Payment_PopupScreen(int TableID, string Username)
        {
            InitializeComponent();
            _TableID = TableID;
            _Username = Username;
        }
    }
}
