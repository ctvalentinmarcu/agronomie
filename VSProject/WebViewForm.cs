using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarcuLicenta
{
    public partial class WebViewForm : Form
    {
        //public string URLString;

        public WebViewForm()
        {
            InitializeComponent();
            
        }

        public void loadURL(string URLString)
        {
            webBrowser1.Navigate(URLString);
        }
    }
}
