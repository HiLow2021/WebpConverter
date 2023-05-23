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
using Image = SixLabors.ImageSharp.Image;

namespace WebpConverter
{
    public static class WebpConverter
    {
        public static async Task EncodeAsync(string path, string destinationDirectory)
        {
            await EncodeAsync(path, destinationDirectory, WebpEncodingMethod.Default, 75, 60, false, true);
        }

        public static async Task EncodeAsync(string path, string destinationDirectory, WebpEncodingMethod method, int quality, int filterStrength, bool skipMetadata, bool useAlphaCompression)
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
                Method = method,
                Quality = quality,
                FilterStrength = filterStrength,
                SkipMetadata = skipMetadata,
                UseAlphaCompression = useAlphaCompression
            };

            await image.SaveAsWebpAsync(destinationPath, encoder);
        }

        public static async Task DecodeAsync(string path, string destinationDirectory)
        {
            await DecodeAsync(path, destinationDirectory, DecodingType.Png, 75, false);
        }

        public static async Task DecodeAsync(string path, string destinationDirectory, DecodingType type, int jpegQuality, bool skipMetadata)
        {
            if (!File.Exists(path) || !Directory.Exists(destinationDirectory))
            {
                return;
            }

            var destinationPath = destinationDirectory + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(path) + GetExtension(type);
            if (File.Exists(destinationPath))
            {
                return;
            }

            using var image = await Image.LoadAsync(path);
            var encoder = GetEncoder(type, jpegQuality, skipMetadata);

            await image.SaveAsync(destinationPath, encoder);
        }

        private static ImageEncoder GetEncoder(DecodingType type, int jpegQuality, bool skipMetadata)
        {
            return type switch
            {
                DecodingType.Png => new PngEncoder() { SkipMetadata = skipMetadata, },
                DecodingType.Jpg => new JpegEncoder() { Quality = jpegQuality, SkipMetadata = skipMetadata, },
                DecodingType.Gif => new GifEncoder() { SkipMetadata = skipMetadata, },
                DecodingType.Bmp => new BmpEncoder() { SkipMetadata = skipMetadata, },
                _ => throw new NotSupportedException(),
            };
        }

        private static string GetExtension(DecodingType type)
        {
            return type switch
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
