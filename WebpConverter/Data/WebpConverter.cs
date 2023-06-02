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
        public async Task EncodeAsync(string path, string destinationDirectory, EncodingOption option)
        {
            if (!File.Exists(path) || !Directory.Exists(destinationDirectory))
            {
                return;
            }

            var destinationPath = destinationDirectory + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(path) + ".webp";
            if (File.Exists(destinationPath))
            {
                return;
            }

            using var image = await Image.LoadAsync(path);
            var encoder = new WebpEncoder()
            {
                Method = option.Method,
                Quality = option.Quality,
                FilterStrength = option.FilterStrength,
                SkipMetadata = option.SkipMetadata,
                UseAlphaCompression = option.UseAlphaCompression,
                NearLossless = option.NearLossless
            };

            await image.SaveAsWebpAsync(destinationPath, encoder);
        }

        public async Task DecodeAsync(string path, string destinationDirectory, DecodingOption option)
        {
            if (!File.Exists(path) || !Directory.Exists(destinationDirectory))
            {
                return;
            }

            var destinationPath = destinationDirectory + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(path) + GetExtension(option);
            if (File.Exists(destinationPath))
            {
                return;
            }

            using var image = await Image.LoadAsync(path);
            var encoder = GetEncoder(option);

            await image.SaveAsync(destinationPath, encoder);
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

        private static string GetExtension(DecodingOption option)
        {
            return option.Type switch
            {
                DecodingType.Png => ".png",
                DecodingType.Jpg => ".jpg",
                DecodingType.Gif => ".gif",
                DecodingType.Bmp => ".bmp",
                _ => throw new NotSupportedException(),
            };
        }
    }
}
