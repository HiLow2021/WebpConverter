using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using WebpConverter.Data.Types;
using Image = SixLabors.ImageSharp.Image;

namespace WebpConverter.Data
{
    public class WebpConverter
    {
        public async Task EncodeAsync(string source, string destination, EncodingOption option)
        {
            if (!File.Exists(source))
            {
                return;
            }

            using var image = await Image.LoadAsync(source);
            using var stream = new FileStream(destination, FileMode.OpenOrCreate);
            var encoder = new WebpEncoder()
            {
                Method = option.Method,
                Quality = option.Quality,
                FilterStrength = option.FilterStrength,
                SkipMetadata = option.SkipMetadata,
                UseAlphaCompression = option.UseAlphaCompression,
                NearLossless = option.NearLossless
            };

            await image.SaveAsync(stream, encoder);
        }

        public async Task DecodeAsync(string source, string destination, DecodingOption option)
        {
            if (!File.Exists(source))
            {
                return;
            }

            using var image = await Image.LoadAsync(source);
            using var stream = new FileStream(destination, FileMode.OpenOrCreate);
            var encoder = GetEncoder(option);

            await image.SaveAsync(stream, encoder);
        }

        private static ImageEncoder GetEncoder(DecodingOption option)
        {
            return option.Type switch
            {
                DecodingType.Png => new PngEncoder() { SkipMetadata = option.SkipMetadata, },
                DecodingType.Jpg => new JpegEncoder() { Quality = option.JpegQuality, SkipMetadata = option.SkipMetadata, },
                DecodingType.Gif => new GifEncoder() { SkipMetadata = option.SkipMetadata, },
                DecodingType.Bmp => new BmpEncoder() { SkipMetadata = option.SkipMetadata, },
                _ => throw new NotSupportedException(),
            };
        }
    }
}
