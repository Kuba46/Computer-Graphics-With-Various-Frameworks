namespace MainWindow
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenCube_Click(object sender, EventArgs e)
        {
            RotatingCube rotatingCube = new RotatingCube();
            rotatingCube.Show();
        }
    }
}
