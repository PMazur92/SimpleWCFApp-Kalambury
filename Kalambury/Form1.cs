using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalambury.KalamburyReference;
using System.ServiceModel;
using System.IO;

namespace Kalambury
{
    public partial class Form1 : Form, IKalamburyServiceCallback
    {
        private KalamburyServiceClient klient;
        private User ja = null;
        private Graphics grafika;
        private Point miejsceKlikniecia = Point.Empty;
        private Pen pioro;

        public Form1()
        {
            InitializeComponent();
            nickTextBox.Select();
            klient = new KalamburyServiceClient(new InstanceContext(this));
            klient.Open();
            rysujBox.Image = new Bitmap(rysujBox.Width, rysujBox.Height);
            rysujBox.BackColor = Color.White;
            grafika = Graphics.FromImage(rysujBox.Image);
            pioro = new Pen(Color.Black);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                grafika.DrawLine(pioro, miejsceKlikniecia, e.Location);
                klient.wyslijPozycje(miejsceKlikniecia.X, miejsceKlikniecia.Y, e.Location.X, e.Location.Y);
                miejsceKlikniecia = e.Location;
                rysujBox.Refresh();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            miejsceKlikniecia = e.Location;
        }

        public void dodajUzytkownika(User user)
        {
            uzytkownicyListBox.Items.Add(String.Format("[{0}] {1}", user.id, user.nick));
            wiadomosciTextBox.Text += String.Format("Uzytkownik {0} dolaczyl do gry", user.nick) + Environment.NewLine;
        }

        public void usunUzytkownika(User user, List<User> uzytkownicy)
        {
            wiadomosciTextBox.Text += String.Format("Uzytkownik {0} wyszedl z gry", user.nick) + Environment.NewLine;
            uzytkownicyListBox.Items.Clear();
            foreach (User uzytkownik in uzytkownicy)
            {
                    uzytkownicyListBox.Items.Add(String.Format("[{0}] {1}", uzytkownik.id, uzytkownik.nick));
            }
        }

        private void dolaczButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nickTextBox.Text))
            {
                wyslijOdpowiedzButton.Enabled = true;
                odpowiedzTextBox.Enabled = true;
                ja = klient.dolaczDoGry(nickTextBox.Text);
                List<User> tempUsers = klient.pobierzUzytkownikow();
                foreach (User u in tempUsers)
                {
                    uzytkownicyListBox.Items.Add(String.Format("[{0}] {1}", u.id, u.nick));
                }
                MemoryStream obraz = new MemoryStream(klient.pobierzGrafike());
                rysujBox.Image = new Bitmap(obraz);
                grafika = Graphics.FromImage(rysujBox.Image);
                rysujBox.Refresh();
                dolaczButton.Enabled = false;
                odpowiedzTextBox.Select();
            }
        }

        public void ustawHaslo(String name)
        {
            wyslijOdpowiedzButton.Enabled = false;
            odpowiedzTextBox.Enabled = false;
            rysujBox.Enabled = true;
            wyczyscButton.Enabled = true;
            hasloTextBox.Text += name;
        }

        private void wyczyscButton_Click(object sender, EventArgs e)
        {
            rysujBox.Image = new Bitmap(rysujBox.Width, rysujBox.Height);
            rysujBox.BackColor = Color.White;
            grafika = Graphics.FromImage(rysujBox.Image);
            klient.wyczysc();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ja != null)
                klient.wyjdzZGry(ja);
        }

        public void rysujPunkt(float x1, float y1, float x2, float y2)
        {
            grafika.DrawLine(pioro, x1, y1, x2, y2);
            rysujBox.Refresh();
        }

        public void wyczyscObraz()
        {
            rysujBox.Image = new Bitmap(rysujBox.Width, rysujBox.Height);
            rysujBox.BackColor = Color.White;
            grafika = Graphics.FromImage(rysujBox.Image);
        }

        private void odpowiedzButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                wyslijOdpowiedzButton.PerformClick();
            }
        }

        public void wiadomosc(string wiadomosc)
        {
            wiadomosciTextBox.Text += wiadomosc + Environment.NewLine;
        }

        private void wyslijOdpowiedzButton_Click(object sender, EventArgs e)
        {
            klient.wyslijWiadomosc(ja, odpowiedzTextBox.Text);
            odpowiedzTextBox.Clear();
        }

        public void poprawnaOdp()
        {
            rysujBox.Enabled = false;
            hasloTextBox.Enabled = false;
            hasloTextBox.Text = "";
            wyczyscButton.Enabled = false;
            odpowiedzTextBox.Enabled = true;
            wyslijOdpowiedzButton.Enabled = true;
        }
        /*
        public Image pobierzObraz()
        {
            return rysujBox.Image;
        }*/
    }
}
