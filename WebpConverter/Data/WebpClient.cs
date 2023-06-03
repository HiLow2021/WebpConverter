using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using WebpConverter.Data.EventArgs;
using WebpConverter.Data.Types;

namespace WebpConverter.Data
{
    public class WebpClient
    {
        private readonly WebpConverter _converter = new();

        public bool IsParallel { get; set; }

        public bool IsRunning { get; private set; }

        public event EventHandler<WebpProgressedEventArgs>? Progressed;
        public event EventHandler<WebpEventArgs>? Completed;

        public async Task EncodeAsync(ImageFile[] imageFiles, EncodingOption option)
        {
            if (IsRunning)
            {
                return;
            }

            IsRunning = true;

            if (IsParallel)
            {
                var i = 0;
                await Parallel.ForEachAsync(imageFiles, async (x, token) =>
                {
                    await EncodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(++i, imageFiles.Length, x));
                });
            }
            else
            {
                foreach (var (x, i) in imageFiles.Select((x, i) => (x, i)))
                {
                    await EncodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(i + 1, imageFiles.Length, x));
                }
            }

            Completed?.Invoke(this, new WebpEventArgs());
            IsRunning = false;
        }

        public async Task DecodeAsync(ImageFile[] imageFiles, DecodingOption option)
        {
            if (IsRunning)
            {
                return;
            }

            IsRunning = true;

            if (IsParallel)
            {
                var i = 0;
                await Parallel.ForEachAsync(imageFiles, async (x, token) =>
                {
                    await DecodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(++i, imageFiles.Length, x));
                });
            }
            else
            {
                foreach (var (x, i) in imageFiles.Select((x, i) => (x, i)))
                {
                    await DecodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(i + 1, imageFiles.Length, x));
                }
            }

            Completed?.Invoke(this, new WebpEventArgs());
            IsRunning = false;
        }

        private async Task EncodeAsync(ImageFile imageFile, EncodingOption option)
        {
            CreateDirectory(imageFile.DestinationPath);
            await _converter.EncodeAsync(imageFile.Path, imageFile.DestinationPath, option);
            imageFile.ConvertedSize = new FileInfo(imageFile.DestinationPath).Length;
            DeleteFile(imageFile.Path, option.DeleteFile);
        }

        private async Task DecodeAsync(ImageFile imageFile, DecodingOption option)
        {
            CreateDirectory(imageFile.DestinationPath);
            await _converter.DecodeAsync(imageFile.Path, imageFile.DestinationPath, option);
            imageFile.ConvertedSize = new FileInfo(imageFile.DestinationPath).Length;
            DeleteFile(imageFile.Path, option.DeleteFile);
        }

        private static void CreateDirectory(string path)
        {
            var directory = Path.GetDirectoryName(path);

            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void DeleteFile(string path, bool deleteFile)
        {
            if (deleteFile)
            {
                File.Delete(path);
            }
        }
    }
}
