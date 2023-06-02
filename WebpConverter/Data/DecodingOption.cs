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

        public bool DeleteFile { get; }

        public DecodingOption()
        {
            Type = DecodingType.Png;
            JpegQuality = 75;
            SkipMetadata = false;
            DeleteFile = false;
        }

        public DecodingOption(DecodingType type, int jpegQuality, bool skipMetadata, bool deleteFile)
        {
            Type = type;
            JpegQuality = jpegQuality;
            SkipMetadata = skipMetadata;
            DeleteFile = deleteFile;
        }
    }
}
