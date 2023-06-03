using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebpConverter.Data
{
    public class ImageFile : IEquatable<ImageFile>
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Path { get; set; }

        public string DestinationPath { get; set; }

        public string BaseDirectory { get; set; }

        public string SubDirectory => System.IO.Path.GetDirectoryName(Path.Replace(BaseDirectory + System.IO.Path.DirectorySeparatorChar, string.Empty)) ?? string.Empty;

        public string BranchDirectory => SubDirectory == string.Empty ? System.IO.Path.GetFileName(BaseDirectory) : System.IO.Path.GetFileName(BaseDirectory) + System.IO.Path.DirectorySeparatorChar + SubDirectory;

        public long OriginalSize { get; set; }

        public long? ConvertedSize { get; set; }

        public float? ConversionRatio => OriginalSize == 0 ? null : ConvertedSize / (float)OriginalSize * 100;

        public ImageFile(string path) : this(path, System.IO.Path.GetDirectoryName(path) ?? string.Empty) { }

        public ImageFile(string path, string baseDirectory)
        {
            var info = new FileInfo(path);

            Name = info.Name;
            Type = info.Extension.TrimStart('.').ToUpper();
            Path = path;
            DestinationPath = string.Empty;
            BaseDirectory = baseDirectory;
            OriginalSize = info.Length;
        }

        public bool Equals(ImageFile? other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Path == other.Path;
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ImageFile);
        }

        public override int GetHashCode()
        {
            return new { Path }.GetHashCode();
        }
    }
}
