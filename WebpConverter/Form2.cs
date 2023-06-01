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
                checkBox4.Checked = settings.IsIncludingSubDirectories;
                radioButton1.Checked = settings.SaveDirectoryType == SaveDirectoryType.Same;
                radioButton2.Checked = settings.SaveDirectoryType == SaveDirectoryType.Sub;
                radioButton3.Checked = settings.SaveDirectoryType == SaveDirectoryType.Specified;
                textBox1.Text = settings.SaveDirectory;
            };
            button1.Click += (sender, e) =>
            {
                if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                }
            };
            button2.Click += (sender, e) =>
            {
                settings.IsTopMost = checkBox1.Checked;
                settings.IsFixedWindowsPosition = checkBox2.Checked;
                settings.IsExecuteParallelly = checkBox3.Checked;
                settings.IsIncludingSubDirectories = checkBox4.Checked;
                settings.SaveDirectoryType = radioButton1.Checked ? SaveDirectoryType.Same : radioButton2.Checked ? SaveDirectoryType.Sub : SaveDirectoryType.Specified;
                settings.SaveDirectory = textBox1.Text;
            };
        }
    }
}
