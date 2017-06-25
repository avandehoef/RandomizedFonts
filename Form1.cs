using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

//Opdracht 6: Lettertype Chaos
//Maak een programma dat in staat is om:
// -    in een relatief kleine tekst(hooguit 1 A4 tje) die geschreven is met een bepaald lettertype te veranderen 
//      in een tekst waar per letterteken een willekeurig verschillend lettertype gebruikt wordt
//      (een beetje het effect van 'losgeldbrieven').
//      Arrays zijn daarbij onvermijdbaar.

namespace Chaos
{
    public partial class FormFonts : Form
    {
        public FormFonts()
        {
            InitializeComponent();
        }

        string defaultFont = "Calibri";
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
            textBoxError.Text = "";
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            textBoxInput.Font = new Font(defaultFont, defaultFontSize);
        }

        private void textBoxError_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            randomFontNumber = random.Next(1, 297);
            textBoxError.Text = "";

            try
            {
                letterTypen = File.ReadAllLines(@"lettertypen.txt").ToList();

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
            catch
            {
                textBoxError.Text = "fout: het bestand lettertypen.txt is niet gevonden";
            }            
        }
    }
}