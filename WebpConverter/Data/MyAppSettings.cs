using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebpConverter.Data
{
    public class MyAppSettings
    {
        public static string[] EncodingExtensions { get; } = new[] { "png", "jpg", "jpeg", "gif", "bmp" };
        public static string[] DecodingExtensions { get; } = new[] { "webp" };
        public static string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;
        public static string ConfigPath { get; } = BaseDirectory + "config.dat";
        public static MyAppSettings Default { get; } = new MyAppSettings();

        public int Left { get; set; }
        public int Top { get; set; }
        public bool IsTopMost { get; set; } = false;
        public bool IsFixedWindowsPosition { get; set; } = false;

        public bool IsExecuteParallelly { get; set; } = false;
        public bool IsIncludingSubDirectories { get; set; } = false;
        public SaveDirectoryType SaveDirectoryType { get; set; } = SaveDirectoryType.Specified;
        public string SaveDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public bool IsDecodeMode { get; set; } = false;

        public EncodingMethod EncodingMethod { get; set; } = EncodingMethod.Normal;
        public int EncodingQuality { get; set; } = 75;
        public bool EncodingSaveMetadata { get; set; } = true;
        public bool EncodingSaveAlpha { get; set; } = true;
        public bool EncodingLosslessMode { get; set; } = false;
        public bool EncodingDeleteFile { get; set; } = false;

        public DecodingType DecodingType { get; set; } = DecodingType.Png;
        public int DecodingJpegQuality { get; set; } = 75;
        public bool DecodingSaveMetadata { get; set; } = true;
        public bool DecodingDeleteFile { get; set; } = false;

        public void Load()
        {
            var settings = StaticLoad();
            if (settings != null)
            {
                Left = settings.Left;
                Top = settings.Top;
                IsTopMost = settings.IsTopMost;
                IsFixedWindowsPosition = settings.IsFixedWindowsPosition;

                IsExecuteParallelly = settings.IsExecuteParallelly;
                IsIncludingSubDirectories = settings.IsIncludingSubDirectories;
                SaveDirectoryType = settings.SaveDirectoryType;
                SaveDirectory = settings.SaveDirectory;
                IsDecodeMode = settings.IsDecodeMode;

                EncodingMethod = settings.EncodingMethod;
                EncodingQuality = settings.EncodingQuality;
                EncodingSaveMetadata = settings.EncodingSaveMetadata;
                EncodingSaveAlpha = settings.EncodingSaveAlpha;
                EncodingLosslessMode = settings.EncodingLosslessMode;
                EncodingDeleteFile = settings.EncodingDeleteFile;

                DecodingType = settings.DecodingType;
                DecodingJpegQuality = settings.DecodingJpegQuality;
                DecodingSaveMetadata = settings.DecodingSaveMetadata;
                DecodingDeleteFile = settings.DecodingDeleteFile;
            }
        }

        public void Save()
        {
            StaticSave(this);
        }

        public static MyAppSettings? StaticLoad()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    var data = File.ReadAllText(ConfigPath);

                    return JsonSerializer.Deserialize<MyAppSettings>(data);
                }

                return Default;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                return Default;
            }
        }

        public static void StaticSave(MyAppSettings settings)
        {
            try
            {
                var data = JsonSerializer.Serialize(settings);

                File.WriteAllText(ConfigPath, data);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
