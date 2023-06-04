using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebpConverter.Data.Types;

namespace WebpConverter.Data
{
    public class DecodingOption
    {
        public DecodingType Type { get; }

        public int JpegQuality { get; }

        public bool SkipMetadata { get; }

        public DecodingOption()
        {
            Type = DecodingType.Png;
            JpegQuality = 75;
            SkipMetadata = false;
        }

        public DecodingOption(DecodingType type, int jpegQuality, bool skipMetadata)
        {
            Type = type;
            JpegQuality = jpegQuality;
            SkipMetadata = skipMetadata;
        }
    }
}
