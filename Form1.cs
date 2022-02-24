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

namespace Notepad
{
    public partial class Form1 : Form
    {
        public string filename;
        public bool isFileChanged;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            filename = "";
            isFileChanged = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;
                }
                catch
                {
                    MessageBox.Show("Не удалось открыть файл");
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.Write(richTextBox1.Text);
                    filename = saveFileDialog1.FileName;
                    isFileChanged = false;
                }
                catch
                {
                    MessageBox.Show("Не удалось");
                }
            }
        }

        private void новыйДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }


        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void курсивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font font = richTextBox1.SelectionFont;
                FontStyle fontStyle;
                if (!(richTextBox1.SelectionFont.Italic))
                {
                    fontStyle = FontStyle.Italic;
                }
                else
                {
                    fontStyle = FontStyle.Regular;
                }
                richTextBox1.SelectionFont = new Font(font.FontFamily, font.Size, font.Style);
            }
        }

        private void жирныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font font = richTextBox1.SelectionFont;
                FontStyle fontStyle;
                if (!(richTextBox1.SelectionFont.Bold))
                {
                    fontStyle = FontStyle.Bold;
                }
                else
                {
                    fontStyle = FontStyle.Regular;
                }
                richTextBox1.SelectionFont = new Font(font.FontFamily, font.Size, font.Style);
            }

        }

        private void размерToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextSettings settings = new TextSettings();
            settings.Show(); 
        }
    }
}
