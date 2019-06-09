using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PicIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnClick_Process(object sender, EventArgs e)
        {
            string data = Interface.processDirectory(inputFilePath.Text);
            File.WriteAllText(@"C:\Users\David\Documents\Code\picin\logs\data.txt", data);
        }
    }
}
