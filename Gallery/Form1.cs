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

namespace Gallery
{
    public partial class Form1 : Form
    {
        int index = 0;
        string[] gallery;
        void swap(int index)
        {
            label1.Text = gallery[index];
            pictureBox1.ImageLocation = gallery[index];
            if (index == 0)
            {
                pictureBox2.ImageLocation = gallery[gallery.Length - 1];
                pictureBox3.ImageLocation = gallery[1];
            } else if (index == gallery.Length - 1)
            {
                pictureBox2.ImageLocation = gallery[index - 1];
                pictureBox3.ImageLocation = gallery[0];
            } else
            {
                pictureBox2.ImageLocation = gallery[index - 1];
                pictureBox3.ImageLocation = gallery[index + 1];
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fbd1.ShowDialog();
            label1.Text = fbd1.SelectedPath;
            gallery = Directory.GetFiles(fbd1.SelectedPath);
  
                label1.Text = gallery[0];
                pictureBox1.ImageLocation = gallery[0];
                pictureBox3.ImageLocation = gallery[1];
                prev.Show(); next.Show();
        }

        private void next_Click(object sender, EventArgs e)
        {
            ++index;
            if (index > gallery.Length - 1) { index = 0; }
            swap(index);
        }

        private void prev_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0) { index = gallery.Length - 1; }
            swap(index);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            prev.Hide();
            next.Hide();
        }
    }
}
