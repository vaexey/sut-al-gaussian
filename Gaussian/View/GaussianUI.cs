using Gaussian.Processing;

namespace Gaussian
{
    public partial class GaussianUI : Form
    {
        public GaussianUI()
        {
            InitializeComponent();

            startBtn_Click(null, null);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            var proc = new Process("GaussianASM", 5, 1, "lang.jpg", "franzl.png");
            //var proc = new Process("GaussianHLL", 20, 1, "lang.jpg", "franzl.png");

            proc.Load();
            proc.Start();
        }
    }
}
