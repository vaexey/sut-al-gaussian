using Gaussian.Processing;

namespace Gaussian
{
    public partial class GaussianUI : Form
    {
        public GaussianUI()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            var proc = new Process("GaussianASM", 50, 4, "lang.jpg", "franzl.png");

            proc.Load();
            proc.Start();
        }
    }
}
