using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CVEngine;

namespace PicIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += new EventHandler(OnClick);
        }

        void OnClick(object sender, EventArgs e)
        {
            CVEngine.CVEngine cvEngine = new CVEngine.CVEngine();

            string filePath;
            unsafe
            {
                filePath = new string(cvEngine.infrastructureTest(textBox1.Text));
            }

            cvEngine.showImage(filePath);
        }
    }
}
