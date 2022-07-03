using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Documents;

namespace MiniWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "(*.txt)|*.txt|(*.rtf)|*.rtf";
            saveFileDialog1.Filter = "(*.txt)|*.txt|(*.rtf)|*.rtf";
            ComboBoxShrift.Items.AddRange(FontFamily.Families.Select(a => a.Name).ToArray());
            for (int i = 8; i <= 72; i += 2)
            {
                Sizes.Items.Add(i);
            }
        }

        FontStyle style;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            tbMessage.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
         //   tbMessage.Text = File.ReadAllText(openFileDialog1.FileName);
            MessageBox.Show("File open!");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            tbMessage.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            //File.WriteAllText(saveFileDialog1.FileName, tbMessage.Text);
            MessageBox.Show("File save!");
        }
        private void Bold_Click(object sender, EventArgs e)
        {
            style = tbMessage.SelectionFont.Style;
            if (tbMessage.SelectionFont.Bold)
            {
                style = style & ~FontStyle.Bold;
                
            }
            else
            {
                style = style | FontStyle.Bold;
                
            }
            tbMessage.SelectionFont = new Font(tbMessage.SelectionFont, style);
        }

        private void Italics_Click(object sender, EventArgs e)
        {
            style = tbMessage.SelectionFont.Style;
            if (tbMessage.SelectionFont.Italic)
            {
                style = style & ~FontStyle.Italic;
            }
            else
            {
                style = style | FontStyle.Italic;
            }
            tbMessage.SelectionFont = new Font(tbMessage.SelectionFont, style);
        }

        private void Underline_Click(object sender, EventArgs e)
        {
            style = tbMessage.SelectionFont.Style;
            if (tbMessage.SelectionFont.Underline)
            {
                style = style & ~FontStyle.Underline;
            }
            else
            {
                style = style | FontStyle.Underline;
            }
            tbMessage.SelectionFont = new Font(tbMessage.SelectionFont, style);
        }
        private string str;

        private void ComboBoxShrift_SelectedIndexChanged(object sender, EventArgs e)
        {
            style = tbMessage.SelectionFont.Style;
            str = ComboBoxShrift.SelectedItem.ToString();
            tbMessage.SelectionFont = new Font(str, Font.Size, style);
        }

        private string sizess;

        private void Sizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            style = tbMessage.SelectionFont.Style;
            sizess = Sizes.SelectedItem.ToString();
            tbMessage.SelectionFont = new Font(str, float.Parse(sizess), style);
        }
    }
}
