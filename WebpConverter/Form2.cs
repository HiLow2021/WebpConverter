using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebpConverter
{
    public partial class Form2 : Form
    {
        public Form2(MyAppSettings settings)
        {
            InitializeComponent();

            Load += (sender, e) =>
            {
                checkBox1.Checked = settings.IsTopMost;
                checkBox2.Checked = settings.IsFixedWindowsPosition;
                checkBox3.Checked = settings.IsExecuteParallelly;
            };
            button1.Click += (sender, e) =>
            {
                settings.IsTopMost = checkBox1.Checked;
                settings.IsFixedWindowsPosition = checkBox2.Checked;
                settings.IsExecuteParallelly = checkBox3.Checked;
            };
        }
    }
}
