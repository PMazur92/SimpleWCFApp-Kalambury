using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Drawing;
using System.IO;

namespace KalamburyWcf
{

    public class Kalambury : IKalamburyService
    {
        static List<User> uzytkownicy = new List<User>();
        static bool czyRozpoczeta = false;
        static List<String> listaNazw = new List<String>() { "kot", "pies", "kwiatek", "laptop", "telewizor" };
        static String odgadywaneHaslo;
        static User graczRysujacy;
        static Random generator = new Random();
        static Image obraz = new Bitmap(465, 300);

        public User dolaczDoGry(string nick)
        {
            User uzytkownik = new User(nick, OperationContext.Current.GetCallbackChannel<IKalamburyCallback>());
            foreach (User u in uzytkownicy)
            {
                u.callback.dodajUzytkownika(uzytkownik);
            }
            rozpocznijGre();
            uzytkownicy.Add(uzytkownik);
            return uzytkownik;
        }

        public void wyslijPozycje(float x1, float y1, float x2, float y2)
        {
            Graphics.FromImage(obraz).DrawLine(new Pen(Color.White), x1, y1, x2, y2);
            foreach (User uzytkownik in uzytkownicy)
            {
                if (uzytkownik != graczRysujacy)
                    uzytkownik.callback.rysujPunkt(x1, y1, x2, y2);
            }
        }

        private void rozpocznijGre()
        {
            if (uzytkownicy.Count == 0)
            {
                Graphics.FromImage(obraz).FillRectangle(new SolidBrush(Color.White), 0, 0, obraz.Width, obraz.Height);
            }
            if (!czyRozpoczeta && uzytkownicy.Count > 0)
            {
                
                graczRysujacy = uzytkownicy[generator.Next(uzytkownicy.Count)];
                odgadywaneHaslo = listaNazw[generator.Next(listaNazw.Count)];
                graczRysujacy.callback.ustawHaslo(odgadywaneHaslo);
                czyRozpoczeta = true;
            }
        }

        public void wyjdzZGry(User uzytkownik)
        {
            uzytkownicy.Remove(uzytkownik);
            foreach (User u in uzytkownicy)
            {
                u.callback.usunUzytkownika(uzytkownik, uzytkownicy);
            }
            if (graczRysujacy != null && uzytkownik.id == graczRysujacy.id)
            {
                foreach (User u in uzytkownicy)
                {
                    u.callback.wyczyscObraz();
                }
                czyRozpoczeta = false;
                rozpocznijGre();
            }
        }

        public List<User> pobierzUzytkownikow()
        {
            return uzytkownicy;
        }

        public User pobierzRysujacego()
        {
            return graczRysujacy;
        }

        public void wyczysc()
        {
            obraz = new Bitmap(465, 300);
            Graphics.FromImage(obraz).FillRectangle(new SolidBrush(Color.White), 0, 0, obraz.Width, obraz.Height);
            foreach (User uzytkownik in uzytkownicy)
            {
                uzytkownik.callback.wyczyscObraz();
            }
        }

        public void wyslijWiadomosc(User uzytkownik, String wiadomosc)
        {
            if (wiadomosc.StartsWith("/") == true)
            {
                foreach (User u in uzytkownicy)
                {
                    char []t = { '/' };
                    u.callback.wiadomosc(uzytkownik.nick + " : " + wiadomosc.TrimStart(t));
                }
            }
            else
            {
                if (wiadomosc.ToLower() == odgadywaneHaslo)
                {
                    foreach (User u in uzytkownicy)
                    {
                        u.callback.wiadomosc(uzytkownik.nick + " podal poprawna odpowiedz( " + wiadomosc.ToLower() + " )");
                        u.callback.wyczyscObraz();
                    }
                    graczRysujacy.callback.poprawnaOdp();
                    czyRozpoczeta = false;
                    rozpocznijGre();
                }
                else 
                {
                    foreach (User u in uzytkownicy)
                    {
                        u.callback.wiadomosc(uzytkownik.nick + " podal bledna odpowiedz( " + wiadomosc + " )");
                    }
                }
            }
        }


        public byte[] pobierzGrafike()
        {
            MemoryStream obrazStream = new MemoryStream();
            obraz.Save(obrazStream, System.Drawing.Imaging.ImageFormat.Png);
            return obrazStream.GetBuffer();
        }
    }
}
