using SixLabors.ImageSharp.Formats.Webp;
using WebpConverter.Data;

namespace WebpConverter
{
    public partial class Form1 : Form
    {
        private readonly Data.WebpConverter _converter = new();
        private readonly MyAppSettings _settings = new();
        private bool _isRunning;

        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 2;
            comboBox2.SelectedIndex = 0;

            Load += (sender, e) => LoadSettings();
            FormClosed += (sender, e) => SaveSettings();

            exitToolStripMenuItem.Click += (sender, e) => Application.Exit();
            encodeToolStripMenuItem.Click += (sender, e) => ChangeMode(0);
            decodeToolStripMenuItem.Click += (sender, e) => ChangeMode(1);
            optionToolStripMenuItem.Click += (sender, e) =>
            {
                using var form = new Form2(_settings);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    TopMost = _settings.IsTopMost;
                }
            };

            listView1.DragEnter += DragEnter;
            listView2.DragEnter += DragEnter;
            listView1.DragDrop += (sender, e) => DragDrop(sender, e, "png", "jpg", "jpeg", "gif", "bmp");
            listView2.DragDrop += (sender, e) => DragDrop(sender, e, "webp");
            comboBox2.SelectedIndexChanged += (sender, e) => numericUpDown2.Enabled = comboBox2.SelectedIndex == 1;
            button1.Click += (sender, e) => AddFile(listView1, openFileDialog1);
            button2.Click += (sender, e) => RemoveFile(listView1);
            button3.Click += (sender, e) => ClearFile(listView1);
            button4.Click += async (sender, e) =>
            {
                try
                {
                    var paths = listView1.Items.Cast<ListViewItem>().Select(x => x.Text).ToArray();
                    var method = Convert(comboBox1.SelectedIndex);
                    var quality = (int)numericUpDown1.Value;
                    var filterStrength = 60;
                    var skipMetadata = !checkBox1.Checked;
                    var useAlpha = checkBox2.Checked;
                    var useLossless = checkBox3.Checked;
                    var isDeleteFile = checkBox4.Checked;
                    var option = new { method, quality, filterStrength, skipMetadata, useAlpha, useLossless, isDeleteFile };

                    await Execute(new Func<Task>(async () => await EncodeAsync(paths, option)));
                    MessageBox.Show("処理が完了しました", "成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "エラー");
                }
            };
            button5.Click += (sender, e) => AddFile(listView2, openFileDialog2);
            button6.Click += (sender, e) => RemoveFile(listView2);
            button7.Click += (sender, e) => ClearFile(listView2);
            button8.Click += async (sender, e) =>
            {
                try
                {
                    var paths = listView2.Items.Cast<ListViewItem>().Select(x => x.Text).ToArray();
                    var type = (DecodingType)comboBox2.SelectedIndex;
                    var jpegQuality = (int)numericUpDown2.Value;
                    var skipMetadata = !checkBox5.Checked;
                    var isDeleteFile = checkBox6.Checked;
                    var option = new { type, jpegQuality, skipMetadata, isDeleteFile };

                    await Execute(new Func<Task>(async () => await DecodeAsync(paths, option)));
                    MessageBox.Show("処理が完了しました", "成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "エラー");
                }
            };

            async Task Execute(Func<Task> action)
            {
                if (_isRunning)
                {
                    return;
                }

                _isRunning = true;
                EnableControls(false);

                await Task.Run(action);

                EnableControls(true);
                _isRunning = false;
            }

            void DragEnter(object? sender, DragEventArgs e)
            {
                if (e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }

            void DragDrop(object? sender, DragEventArgs e, params string[] filterExtensions)
            {
                if (sender == null || e.Data == null)
                {
                    return;
                }

                var listView = (ListView)sender;
                var fileSystemEntries = (string[]?)e.Data.GetData(DataFormats.FileDrop, false);
                var files = fileSystemEntries?.SelectMany(x =>
                {
                    if (File.Exists(x))
                    {
                        return new[] { x };
                    }
                    else if (Directory.Exists(x))
                    {
                        var searchOption = _settings.IsIncludingSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

                        return Directory.GetFiles(x, "*", searchOption);
                    }
                    else
                    {
                        return Array.Empty<string>();
                    }
                }).Distinct().Where(x =>
                {
                    return filterExtensions.Contains(Path.GetExtension(x).TrimStart('.').ToLower());
                }).Except(listView.Items.Cast<ListViewItem>().Select(x => x.Text));
                if (files == null)
                {
                    return;
                }

                listView.Items.AddRange(files.Select(x => new ListViewItem(x)).ToArray());
            }

            static WebpEncodingMethod Convert(int index)
            {
                return index switch
                {
                    0 => WebpEncodingMethod.Fastest,
                    1 => WebpEncodingMethod.Level2,
                    2 => WebpEncodingMethod.Default,
                    3 => WebpEncodingMethod.Level5,
                    4 => WebpEncodingMethod.BestQuality,
                    _ => throw new NotSupportedException(),
                };
            }
        }

        private async Task EncodeAsync(string[] paths, dynamic option)
        {
            if (_settings.IsExecuteParallelly)
            {
                var i = 0;
                await Parallel.ForEachAsync(paths, async (x, token) =>
                {
                    var destinationDirectory = GetDestinationDirectory(x);

                    CreateDirectory(destinationDirectory);
                    await _converter.EncodeAsync(x, destinationDirectory, option.method, option.quality, option.filterStrength, option.skipMetadata, option.useAlpha, option.useLossless);
                    DeleteFile(x, option.isDeleteFile);
                    UpdateProgress(progressBar1, paths.Length, ++i);
                });
            }
            else
            {
                foreach (var (item, i) in paths.Select((x, i) => (x, i)))
                {
                    var destinationDirectory = GetDestinationDirectory(item);

                    CreateDirectory(destinationDirectory);
                    await _converter.EncodeAsync(item, destinationDirectory, option.method, option.quality, option.filterStrength, option.skipMetadata, option.useAlpha, option.useLossless);
                    DeleteFile(item, option.isDeleteFile);
                    UpdateProgress(progressBar1, paths.Length, i + 1);
                }
            }
        }

        private async Task DecodeAsync(string[] paths, dynamic option)
        {
            if (_settings.IsExecuteParallelly)
            {
                var i = 0;
                await Parallel.ForEachAsync(paths, async (x, token) =>
                {
                    var destinationDirectory = GetDestinationDirectory(x);

                    CreateDirectory(destinationDirectory);
                    await _converter.DecodeAsync(x, destinationDirectory, option.type, option.jpegQuality, option.skipMetadata);
                    DeleteFile(x, option.isDeleteFile);
                    UpdateProgress(progressBar2, paths.Length, ++i);
                });
            }
            else
            {
                foreach (var (item, i) in paths.Select((x, i) => (x, i)))
                {
                    var destinationDirectory = GetDestinationDirectory(item);

                    CreateDirectory(destinationDirectory);
                    await _converter.DecodeAsync(item, destinationDirectory, option.type, option.jpegQuality, option.skipMetadata);
                    DeleteFile(item, option.isDeleteFile);
                    UpdateProgress(progressBar2, paths.Length, i + 1);
                }
            }
        }

        private void ChangeMode(int index)
        {
            encodeToolStripMenuItem.Checked = index == 0;
            decodeToolStripMenuItem.Checked = index == 1;
            concealableTabControl1.SelectedIndex = index;
        }

        private void EnableControls(bool flag)
        {
            modeToolStripMenuItem.Enabled = flag;
            toolToolStripMenuItem.Enabled = flag;
            listView1.AllowDrop = flag;
            listView2.AllowDrop = flag;
            comboBox1.Enabled = flag;
            comboBox2.Enabled = flag;
            numericUpDown1.Enabled = flag;
            numericUpDown2.Enabled = flag;
            checkBox1.Enabled = flag;
            checkBox2.Enabled = flag;
            checkBox3.Enabled = flag;
            checkBox4.Enabled = flag;
            checkBox5.Enabled = flag;
            checkBox6.Enabled = flag;
            button1.Enabled = flag;
            button2.Enabled = flag;
            button3.Enabled = flag;
            button4.Enabled = flag;
            button5.Enabled = flag;
            button6.Enabled = flag;
            button7.Enabled = flag;
            button8.Enabled = flag;
        }

        private void AddFile(ListView listView, OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                listView.Items.Add(openFileDialog.FileName);
            }
        }

        private void RemoveFile(ListView listView)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                item.Remove();
            }
        }

        private void ClearFile(ListView listView)
        {
            listView.Items.Clear();
        }

        private static void UpdateProgress(ProgressBar progressBar, int totalCount, int i)
        {
            var percentage = (int)(i / (float)totalCount * 100);

            progressBar.Invoke(new Action(() =>
            {
                if (progressBar.Minimum <= percentage && percentage <= progressBar.Maximum)
                {
                    progressBar.Value = percentage;
                }
            }));
        }

        private string GetDestinationDirectory(string path)
        {
            if (_settings.SaveDirectoryType == SaveDirectoryType.Same)
            {
                return Path.GetDirectoryName(path) ?? string.Empty;
            }
            else if (_settings.SaveDirectoryType == SaveDirectoryType.Sub)
            {
                return Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + "out";
            }
            else
            {
                return _settings.SaveDirectory + Path.DirectorySeparatorChar + Path.GetFileName(Path.GetDirectoryName(path));
            }
        }

        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static void DeleteFile(string path, bool isDeleteFile)
        {
            if (isDeleteFile)
            {
                File.Delete(path);
            }
        }

        private void LoadSettings()
        {
            _settings.Load();

            TopMost = _settings.IsTopMost;

            if (_settings.IsFixedWindowsPosition)
            {
                Left = _settings.Left;
                Top = _settings.Top;
            }

            concealableTabControl1.SelectedIndex = _settings.IsDecodeMode ? 1 : 0;
            encodeToolStripMenuItem.Checked = !_settings.IsDecodeMode;
            decodeToolStripMenuItem.Checked = _settings.IsDecodeMode;

            comboBox1.SelectedIndex = (int)_settings.EncodingMethod;
            numericUpDown1.Value = _settings.EncodingQuality;
            checkBox1.Checked = _settings.EncodingSaveMetadata;
            checkBox2.Checked = _settings.EncodingSaveAlpha;
            checkBox3.Checked = _settings.EncodingLosslessMode;
            checkBox4.Checked = _settings.EncodingDeleteFile;

            comboBox2.SelectedIndex = (int)_settings.DecodingType;
            numericUpDown2.Value = _settings.DecodingJpegQuality;
            checkBox5.Checked = _settings.DecodingSaveMetadata;
            checkBox6.Checked = _settings.DecodingDeleteFile;
        }

        private void SaveSettings()
        {
            if (WindowState == FormWindowState.Normal)
            {
                _settings.Left = Left;
                _settings.Top = Top;
            }

            _settings.IsDecodeMode = concealableTabControl1.SelectedIndex == 1;

            _settings.EncodingMethod = (EncodingMethod)comboBox1.SelectedIndex;
            _settings.EncodingQuality = (int)numericUpDown1.Value;
            _settings.EncodingSaveMetadata = checkBox1.Checked;
            _settings.EncodingSaveAlpha = checkBox2.Checked;
            _settings.EncodingLosslessMode = checkBox3.Checked;
            _settings.EncodingDeleteFile = checkBox4.Checked;

            _settings.DecodingType = (DecodingType)comboBox2.SelectedIndex;
            _settings.DecodingJpegQuality = (int)numericUpDown2.Value;
            _settings.DecodingSaveMetadata = checkBox5.Checked;
            _settings.DecodingDeleteFile = checkBox6.Checked;

            _settings.Save();
        }
    }
}