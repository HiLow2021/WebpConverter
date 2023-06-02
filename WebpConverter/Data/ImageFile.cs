using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebpConverter.Data
{
    public class ImageFile : IEquatable<ImageFile>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string FullPath { get; set; }

        public string BaseDirectory { get; set; }

        public string SubDirectory => Path.GetDirectoryName(FullPath.Replace(BaseDirectory + Path.DirectorySeparatorChar, string.Empty)) ?? string.Empty;

        public string BranchDirectory => SubDirectory == string.Empty ? Path.GetFileName(BaseDirectory) : Path.GetFileName(BaseDirectory) + Path.DirectorySeparatorChar + SubDirectory;

        public long OriginalSize { get; set; }

        public long ConvertedSize { get; set; }

        public int ConversionRatio => ConvertedSize == 0 ? 0 : (int)(OriginalSize / (float)ConvertedSize * 100);

        public ImageFile(string path) : this(path, Path.GetDirectoryName(path) ?? string.Empty) { }

        public ImageFile(string path, string baseDirectory)
        {
            var info = new FileInfo(path);

            Name = info.Name;
            Type = info.Extension.TrimStart('.').ToUpper();
            FullPath = path;
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
                return FullPath == other.FullPath;
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ImageFile);
        }

        public override int GetHashCode()
        {
            return new { FullPath }.GetHashCode();
        }
    }
}
