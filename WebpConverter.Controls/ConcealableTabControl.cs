using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class ConcealableTabControl : TabControl
    {
        [Browsable(true)]
        [Category("表示")]
        [DefaultValue(true)]
        [Description("タブを非表示にするかどうか")]
        public bool ConcealedTab { get; set; } = true;

        public ConcealableTabControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode && ConcealedTab)
            {
                m.Result = 1;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
