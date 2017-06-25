using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Chaos
{
    public partial class FormFonts : Form
    {
        public FormFonts()
        {
            InitializeComponent();
        }

        string defaultFont = "Times New Roman";
        string newFont;
        int defaultFontSize = 12;
        Random random = new Random();
        int randomFontNumber, positie;
        List<string> letterTypen = new List<string>();

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = "";
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            textBoxInput.Font = new Font(defaultFont, defaultFontSize);
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            randomFontNumber = random.Next(1, 297);

            try
            {
                letterTypen = File.ReadAllLines(@"lettertypen.txt").ToList();
            }
            catch
            {
                textBoxInput.Text = "fout";
            }

            for (positie = 0; positie < textBoxInput.TextLength; positie = positie + 1)
            {
                var newFontTemp = letterTypen.ElementAt(randomFontNumber);
                newFont = Convert.ToString(newFontTemp);
                textBoxInput.SelectionStart = positie;
                textBoxInput.SelectionLength = 1;
                textBoxInput.SelectionFont = new Font(newFont, defaultFontSize);
                randomFontNumber = random.Next(1, 297);
            }
        }
    }
}