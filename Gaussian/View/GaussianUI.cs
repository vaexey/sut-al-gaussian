using Gaussian.Processing;
using System.Resources;

namespace Gaussian
{
    public partial class GaussianUI : Form
    {
        Process? current;

        Histogram? hBefore;
        Histogram? hAfter;

        static string hourglassBase = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAA0GVYSWZJSSoACAAAAAoAAAEEAAEAAAAgAAAAAQEEAAEAAAAgAAAAAgEDAAMAAACGAAAAEgEDAAEAAAABAAAAGgEFAAEAAACMAAAAGwEFAAEAAACUAAAAKAEDAAEAAAADAAAAMQECAA0AAACcAAAAMgECABQAAACqAAAAaYcEAAEAAAC+AAAAAAAAAAgACAAIAPcFAAAZAAAA9wUAABkAAABHSU1QIDIuMTAuMzgAADIwMjU6MDE6MTggMTQ6NTQ6MDgAAQABoAMAAQAAAAEAAAAAAAAATwVztAAAAYRpQ0NQSUNDIHByb2ZpbGUAAHicfZE9SMNQFIVPW6UiLYJ2EHHIUJ3solUcaxWKUCHUCq06mLz0D5o0JCkujoJrwcGfxaqDi7OuDq6CIPgD4i44KbpIifclhRYxXni8j/PuObx3H+BvVplq9iQAVbOMTCop5PKrQvAVPgwijGnEJWbqc6KYhmd93VM31V2MZ3n3/VlhpWAywCcQJ5huWMQbxDObls55nzjCypJCfE48YdAFiR+5Lrv8xrnksJ9nRoxsZp44QiyUuljuYlY2VOI4cVRRNcr351xWOG9xVqt11r4nf2GooK0sc53WKFJYxBJECJBRRwVVWIjRrpFiIkPnSQ//iOMXySWTqwJGjgXUoEJy/OB/8Hu2ZnFq0k0KJYHeF9v+GAOCu0CrYdvfx7bdOgECz8CV1vHXmsDsJ+mNjhY9Aga2gYvrjibvAZc7wPCTLhmSIwVo+YtF4P2MvikPDN0C/Wvu3NrnOH0AsjSr9A1wcAiMlyh73ePdfd1z+7enPb8f9ily2/3CYrMAAA14aVRYdFhNTDpjb20uYWRvYmUueG1wAAAAAAA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/Pgo8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJYTVAgQ29yZSA0LjQuMC1FeGl2MiI+CiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPgogIDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiCiAgICB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIKICAgIHhtbG5zOnN0RXZ0PSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VFdmVudCMiCiAgICB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iCiAgICB4bWxuczpHSU1QPSJodHRwOi8vd3d3LmdpbXAub3JnL3htcC8iCiAgICB4bWxuczp0aWZmPSJodHRwOi8vbnMuYWRvYmUuY29tL3RpZmYvMS4wLyIKICAgIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIKICAgeG1wTU06RG9jdW1lbnRJRD0iZ2ltcDpkb2NpZDpnaW1wOjFkZjI1NjQzLTJhNWMtNDA5NS1iZTRkLWFmOWVjYzA5NGNhZSIKICAgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDpiYTdhZGEwYi00MDdmLTRhMDItYjY0NS03MTdjZmE1OTIzZTkiCiAgIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDpkODc5YzYyZC1kZjljLTQ4N2ItYTEzYi0wY2E5MTZhNTA5ZWMiCiAgIGRjOkZvcm1hdD0iaW1hZ2UvcG5nIgogICBHSU1QOkFQST0iMi4wIgogICBHSU1QOlBsYXRmb3JtPSJMaW51eCIKICAgR0lNUDpUaW1lU3RhbXA9IjE3MzcyMDg0NDgwODkzNjUiCiAgIEdJTVA6VmVyc2lvbj0iMi4xMC4zOCIKICAgdGlmZjpPcmllbnRhdGlvbj0iMSIKICAgeG1wOkNyZWF0b3JUb29sPSJHSU1QIDIuMTAiCiAgIHhtcDpNZXRhZGF0YURhdGU9IjIwMjU6MDE6MThUMTQ6NTQ6MDgrMDE6MDAiCiAgIHhtcDpNb2RpZnlEYXRlPSIyMDI1OjAxOjE4VDE0OjU0OjA4KzAxOjAwIj4KICAgPHhtcE1NOkhpc3Rvcnk+CiAgICA8cmRmOlNlcT4KICAgICA8cmRmOmxpCiAgICAgIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiCiAgICAgIHN0RXZ0OmNoYW5nZWQ9Ii8iCiAgICAgIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6NTg3YzQwNzUtZDllMS00YTAzLTgyYjUtNDc3NzYwNGI0NThiIgogICAgICBzdEV2dDpzb2Z0d2FyZUFnZW50PSJHaW1wIDIuMTAgKExpbnV4KSIKICAgICAgc3RFdnQ6d2hlbj0iMjAyNS0wMS0xOFQxNDo1NDowOCswMTowMCIvPgogICAgPC9yZGY6U2VxPgogICA8L3htcE1NOkhpc3Rvcnk+CiAgPC9yZGY6RGVzY3JpcHRpb24+CiA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgCjw/eHBhY2tldCBlbmQ9InciPz5g036DAAAC/VBMVEXUQPH///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACq3718AAAAAXRSTlMAQObYZgAAAAFiS0dEAIgFHUgAAAAJcEhZcwAAF9wAABfcARkEV1YAAAAHdElNRQfpARINNgi18NxaAAAAdUlEQVQ4y9WT2w6AMAhDG/7/ozUDHMtKZ+KTZDqhZwuXCNxmjSHtCAwGUP5fABPufmTX1zPkggzGi+gR9ofqLozV6HNoQE/QAt4DJlN8JFmEKrOERSMFEaF1owk2iU49vxhQ+kCBen0DiIb7pJlTJ02dz3/3BSbwAjEMUCY5AAAAAElFTkSuQmCC";
        Image hourglass = Image.FromStream(new MemoryStream(Convert.FromBase64String(hourglassBase)));

        public GaussianUI()
        {
            InitializeComponent();

            historyList.View = View.Details;
            historyList.FullRowSelect = true;
            historyList.Columns.Add("File", 100, HorizontalAlignment.Left);
            historyList.Columns.Add("Algorithm", 100, HorizontalAlignment.Center);
            historyList.Columns.Add("Time", -2, HorizontalAlignment.Left);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Enabled = false;

            var algo = algorithmCombo.SelectedItem.ToString();

            if (algo is null || (algo != "GaussianASM" && algo != "GaussianHLL"))
            {
                MessageBox.Show(this, "Select a valid algorithm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enabled = true;
                return;
            }

            var src = sourceBox.Text;

            if (!File.Exists(src))
            {
                MessageBox.Show(this, "Select a valid source image file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enabled = true;
                return;
            }

            var dest = Path.Join(
                    destBox.Text,
                    Path.GetFileName(src)
                );

            current = new(algo, 5, threadsTrack.Value, src, dest);

            try
            {
                current.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "An error happened while loading file.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enabled = true;
                return;
            }

            var tempImg = (Image?)current.GetSource()?.Clone();

            if (pictureBefore.Image is not null)
                pictureBefore.Image.Dispose();

            pictureBefore.Image = tempImg;

            try
            {
                current.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "An error happened while starting the algorithm.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enabled = true;
                return;
            }
        }

        private void GaussianUI_Load(object sender, EventArgs e)
        {
            algorithmCombo.SelectedIndex = 0;

            var cpus = Environment.ProcessorCount;

            logicalCpuLabel.Text = cpus.ToString();
            threadsTrack.Value = cpus;
        }

        private void threadsTrack_ValueChanged(object sender, EventArgs e)
        {
            threadsLabel.Text = threadsTrack.Value.ToString();
        }

        private void sourceBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Supported image files|*.png;*.jpg;*.jpeg;*.bmp|All files|*.*",
                FileName = sourceBox.Text,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceBox.Text = dialog.FileName;
            }
        }

        private void destBtn_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog()
            {
                SelectedPath = destBox.Text
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                destBox.Text = dialog.SelectedPath;
            }
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (current is not null)
            {
                var result = current.GetResult();

                if (result is not null)
                {
                    var tempImg = (Image)result.Clone();

                    if (pictureAfter.Image is not null)
                        pictureAfter.Image.Dispose();

                    pictureAfter.Image = tempImg;

                    var time = current.GetElapsed();

                    current.Dispose();
                    current = null;

                    var lvi = new ListViewItem(new[] {
                        Path.GetFileName(sourceBox.Text),
                        algorithmCombo.SelectedItem + "",
                        time.ToString() + " ms"
                    });

                    historyList.Items.Add(lvi);

                    Enabled = true;

                    hBefore = new((Bitmap)pictureBefore.Image);
                    hBefore.Generate();
                    hAfter = new((Bitmap)pictureAfter.Image);
                    hAfter.Generate();
                }
            }

            Image? haTarget = null;

            if (hAfter is not null)
            {
                if(hAfter.Result is not null)
                {
                    haTarget = hAfter.Result;
                } 
                else
                {
                    haTarget = hourglass;
                }
            }

            if(histAfter.Image != haTarget)
            {
                histAfter.Image = haTarget;
                histAfter.SizeMode = (haTarget == hourglass) ? PictureBoxSizeMode.CenterImage : PictureBoxSizeMode.StretchImage;
            }


            Image? hbTarget = null;

            if (hBefore is not null)
            {
                if (hBefore.Result is not null)
                {
                    hbTarget = hBefore.Result;
                }
                else
                {
                    hbTarget = hourglass;
                }
            }

            if (histBefore.Image != hbTarget)
            {
                histBefore.Image = hbTarget;
                histBefore.SizeMode = (hbTarget == hourglass) ? PictureBoxSizeMode.CenterImage : PictureBoxSizeMode.StretchImage;
            }
        }
    }
}