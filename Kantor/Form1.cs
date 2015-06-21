using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kantor
{
    public partial class Kantor : Form
    {
        public Kantor()
        {
            InitializeComponent();
        }

        //okon pomocy
        private void pomoc_Click(object sender, EventArgs e)
        {
            Form okno_pomocy = new Form();
            okno_pomocy.Text = "Pomoc";
            okno_pomocy.Size = new Size(320, 250);
            okno_pomocy.MaximumSize = new Size(320, 250);
            okno_pomocy.MinimumSize = new Size(320, 250);
            okno_pomocy.MaximizeBox = false;
            okno_pomocy.MinimizeBox = false;

            //opis
            Label opis = new Label();
            opis.Location = new Point(70, 50);
            opis.Size = new Size(300, 80);
            opis.Text = "Aplikacja, której celem jest\nprzelicznie oraz sprawdzanie\naktualnego kursu walut.\nDane będą pobierane ze strony internetowej";
            okno_pomocy.Controls.Add(opis);

            //oprogramowanie przycisku
            Button zamknij = new Button();
            zamknij.Location = new Point(100, 150);
            zamknij.Size = new Size(100, 40);
            zamknij.Text = "OK";
            zamknij.DialogResult = System.Windows.Forms.DialogResult.OK;//zamykanie okna pomocy
            okno_pomocy.Controls.Add(zamknij);

            okno_pomocy.ShowDialog();
            
        }

        private void licz_Click(object sender, EventArgs e)
        {
            Form okno_liczenia = new Form();
            okno_liczenia.Size = new Size(350, 300);
            okno_liczenia.MaximumSize = new Size(350, 300);
            okno_liczenia.MinimumSize = new Size(350, 300);
            okno_liczenia.MaximizeBox = false;
            okno_liczenia.MinimizeBox = false;
            okno_liczenia.Text = "Przelicznik";

            //mijesce na dane do przeliczenia
            TextBox dane = new TextBox();
            dane.Location = new Point(340 / 2, 300 / 2);
            dane.Size = new Size(150, 100);
            okno_liczenia.Controls.Add(dane);

            //przycisk przeliczający
            Button liczenie = new Button();
            liczenie.Size = new Size(100, 50);
            liczenie.Location = new Point(350/2, 200);
            liczenie.Text = "przelicz";
            liczenie.DialogResult = System.Windows.Forms.DialogResult.OK;
            okno_liczenia.Controls.Add(liczenie);

            okno_liczenia.ShowDialog();
        }


     

        
    }
}
