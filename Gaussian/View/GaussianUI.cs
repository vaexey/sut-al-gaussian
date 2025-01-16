using Gaussian.Processing;

namespace Gaussian
{
    public partial class GaussianUI : Form
    {
        Process? current;

        public GaussianUI()
        {
            InitializeComponent();

            historyList.View = View.Details;
            historyList.Columns.Add("File", 100, HorizontalAlignment.Left);
            historyList.Columns.Add("Algorithm", 100, HorizontalAlignment.Center);
            historyList.Columns.Add("Time", -2, HorizontalAlignment.Left);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            //var proc = new Process("GaussianASM", 5, 1, "lang.jpg", "franzl.png");
            //var proc = new Process("GaussianHLL", 20, 1, "lang.jpg", "franzl.png");

            //proc.Load();
            //proc.Start();

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

            current = new(algo, 5, 1, src, dest);

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
                }
            }
        }
    }
}
