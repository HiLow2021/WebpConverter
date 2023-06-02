using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebpConverter.Data.EventArgs
{
    public class WebpProgressedEventArgs : WebpEventArgs
    {
        public int Progress { get; }

        public int ProgressPercentage { get; }

        public int Total { get; }

        public WebpProgressedEventArgs(int progress, int total)
        {
            Progress = progress;
            ProgressPercentage = total == 0 ? 100 : (int)(progress / (float)total * 100);
            Total = total;
        }
    }
}
