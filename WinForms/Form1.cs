namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Hello World!";
            textBox2.Text = "Hello World! 2";
        }
    }
}
