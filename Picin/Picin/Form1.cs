using System;
using System.Windows.Forms;
using CVEngine;

namespace PicIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += OnClick_Show;
            button2.Click += OnClick_Print;
            button3.Click += OnClick_Process;
        }

        void OnClick_Show(object sender, EventArgs e)
        {
            CVTools cvTools = new CVTools();

            cvTools.showImage(textBox1.Text);
        }

        private void OnClick_Print(object sender, EventArgs e)
        {
            CVTools cvTools = new CVTools();

            cvTools.printMat(textBox1.Text);
        }

        void OnClick_Process(object sender, EventArgs e)
        {
            CVEngine.CVEngine cvEngine = new CVEngine.CVEngine();

            cvEngine.process(textBox1.Text);
        }
    }
}
