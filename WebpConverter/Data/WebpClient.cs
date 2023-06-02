using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public bool IsExecuteParallelly { get; set; }

        public SaveDirectoryType SaveDirectoryType { get; set; }

        public string SaveDirectory { get; set; } = string.Empty;

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

            if (IsExecuteParallelly)
            {
                var i = 0;
                await Parallel.ForEachAsync(imageFiles, async (x, token) =>
                {
                    await EncodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(++i, imageFiles.Length));
                });
            }
            else
            {
                foreach (var (x, i) in imageFiles.Select((x, i) => (x, i)))
                {
                    await EncodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(i + 1, imageFiles.Length));
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

            if (IsExecuteParallelly)
            {
                var i = 0;
                await Parallel.ForEachAsync(imageFiles, async (x, token) =>
                {
                    await DecodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(++i, imageFiles.Length));
                });
            }
            else
            {
                foreach (var (x, i) in imageFiles.Select((x, i) => (x, i)))
                {
                    await DecodeAsync(x, option);
                    Progressed?.Invoke(this, new WebpProgressedEventArgs(i + 1, imageFiles.Length));
                }
            }

            Completed?.Invoke(this, new WebpEventArgs());
            IsRunning = false;
        }

        public void SetProperties(bool isExecuteParallelly, SaveDirectoryType saveDirectoryType, string saveDirectory)
        {
            if (IsRunning)
            {
                return;
            }

            IsExecuteParallelly = isExecuteParallelly;
            SaveDirectoryType = saveDirectoryType;
            SaveDirectory = saveDirectory;
        }

        private async Task EncodeAsync(ImageFile imageFile, EncodingOption option)
        {
            var destinationDirectory = GetDestinationDirectory(imageFile.FullPath, imageFile.BranchDirectory);

            CreateDirectory(destinationDirectory);
            await _converter.EncodeAsync(imageFile.FullPath, destinationDirectory, option);
            DeleteFile(imageFile.FullPath, option.DeleteFile);
        }

        private async Task DecodeAsync(ImageFile imageFile, DecodingOption option)
        {
            var destinationDirectory = GetDestinationDirectory(imageFile.FullPath, imageFile.BranchDirectory);

            CreateDirectory(destinationDirectory);
            await _converter.DecodeAsync(imageFile.FullPath, destinationDirectory, option);
            DeleteFile(imageFile.FullPath, option.DeleteFile);
        }

        private string GetDestinationDirectory(string path, string branchDirectory)
        {
            if (SaveDirectoryType == SaveDirectoryType.Same)
            {
                return Path.GetDirectoryName(path) ?? string.Empty;
            }
            else if (SaveDirectoryType == SaveDirectoryType.Sub)
            {
                return Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + "out";
            }
            else
            {
                return SaveDirectory + Path.DirectorySeparatorChar + branchDirectory;
            }
        }

        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
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
