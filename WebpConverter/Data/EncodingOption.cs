using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats.Webp;

namespace WebpConverter.Data
{
    public class EncodingOption
    {
        public WebpEncodingMethod Method { get; }

        public int Quality { get; }

        public int FilterStrength { get; }

        public bool SkipMetadata { get; }

        public bool UseAlphaCompression { get; }

        public bool NearLossless { get; }

        public bool DeleteFile { get; }

        public EncodingOption()
        {
            Method = WebpEncodingMethod.Default;
            Quality = 75;
            FilterStrength = 60;
            SkipMetadata = false;
            UseAlphaCompression = true;
            NearLossless = false;
            DeleteFile = false;
        }

        public EncodingOption(WebpEncodingMethod method, int quality, int filterStrength, bool skipMetadata, bool useAlphaCompression, bool nearLossless, bool deleteFile)
        {
            Method = method;
            Quality = quality;
            FilterStrength = filterStrength;
            SkipMetadata = skipMetadata;
            UseAlphaCompression = useAlphaCompression;
            NearLossless = nearLossless;
            DeleteFile = deleteFile;
        }
    }
}
