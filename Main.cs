using QQAI2D;
using System.Diagnostics;
using System.Reflection;

namespace QQAI2D_WinForms
{
    public partial class MainForm : Form
    {
        private record Photo(string Path, string Base64);

        private readonly string[] _extensions;

        private string[] _imagesPaths;
        private int _picturesLeft;
        private float _progressStep;

        public MainForm()
        {
            InitializeComponent();

            _extensions = new string[] { ".jpg", ".png", ".jpeg" };
            DragEnter += OnPanelDragEnter;
            DragDrop += OnPanelDragDrop;
            startButton.Click += OnStartClick;

            var tooltip = new ToolTip();
            tooltip.ToolTipIcon = ToolTipIcon.None;
            tooltip.IsBalloon = true;
            tooltip.ShowAlways = true;
            tooltip.UseAnimation = true;
            tooltip.UseFading = true;

            picturesCountLabel.MouseEnter += delegate { tooltip.SetToolTip(picturesCountLabel, _imagesPaths is null ? string.Empty : string.Join(Environment.NewLine, _imagesPaths)); };
            openDirectoryButton.Click += delegate
            {
                var directory = GetResultsPath();
                if (Directory.Exists(directory))
                {
                    Process.Start(new ProcessStartInfo { FileName = directory, UseShellExecute = true, Verb = "open" });
                }
            };
            MessageBox.Show($"Эта хуйня работает, как-то работает, и вас ебать не должно{Environment.NewLine}Приятного пользования :)");
        }

        private bool IsDragDropDataValid(IDataObject dataObject)
        {
            if (!dataObject.GetDataPresent(DataFormats.FileDrop))
                return false;

            string[] files = (string[])dataObject.GetData(DataFormats.FileDrop);
            if (files.Any(x => !_extensions.Contains(Path.GetExtension(x))))
                return false;

            return true;
        }

        private void OnPanelDragEnter(object s, DragEventArgs e)
        {
            e.Effect = IsDragDropDataValid(e.Data) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void OnPanelDragDrop(object s, DragEventArgs e)
        {
            _imagesPaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            picturesCountLabel.Text = $"Количество картинок: {_imagesPaths.Length}";
        }

        private async void OnStartClick(object s, EventArgs e)
        {
            if (!int.TryParse(textBox.Text, out int uploadsCount))
            {
                MessageBox.Show("Количество загрузок должно быть числом");
                return;
            }

            if (_imagesPaths is null)
            {
                MessageBox.Show("Сначала нужно выбрать фотографии");
                return;
            }

            var images = new List<Photo>(_imagesPaths.Length);
            foreach (var imagePath in _imagesPaths)
            {
                images.Add(new Photo(imagePath, await QQAI2D.ImageConverter.ToBase64(imagePath)));
            }

            progressBar.Value = 0;
            progressLabel.Text = "0%";
            startButton.Enabled = false;
            cropCheckBox.Enabled = false;
            saveCheckBox.Enabled = false;
            _picturesLeft = _imagesPaths.Length * uploadsCount;
            _progressStep = 100f / _picturesLeft;

            var tasks = images.Select(x => StartConverting(x, uploadsCount, cropCheckBox.Checked, saveCheckBox.Checked));
            await Task.WhenAll(tasks);

            startButton.Enabled = true;
            cropCheckBox.Enabled = true;
            saveCheckBox.Enabled = true;
        }

        private async Task StartConverting(Photo photo, int uploadsCount, bool cropImage, bool createFolderForEachPicture)
        {
            var name = Path.GetFileNameWithoutExtension(photo.Path);
            var results = GetResultsPath();

            if (!Directory.Exists(results))
                Directory.CreateDirectory(results);

            var directory = createFolderForEachPicture ? $@"{results}\{name}" : results;
            var uploader = new Uploader(photo.Base64, uploadsCount);
            var downloader = new Downloader();
            var photosSaver = new PhotosSaver(directory, name, cropImage);

            int number = 1;

            try
            {
                await foreach (var url in uploader.GetConvertedImagesURL())
                {
                    var bytes = await downloader.Save(url);
                    photosSaver.Save(bytes);
                    number++;
                    UpdateProgressBar();
                }
            }
            catch { }
        }

        private void UpdateProgressBar()
        {
            if (_picturesLeft == 0)
            {
                progressBar.Value = 100;
                progressLabel.Text = "готово, ебать";
            }
            else
            {
                progressBar.Value += (int)_progressStep;
                progressLabel.Text = $"{progressBar.Value}%";
            }
        }

        private string GetResultsPath()
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}\results";
        }
    }
}