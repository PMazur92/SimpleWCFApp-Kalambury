using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ServiceModel;

namespace KalamburyWcf
{
    [ServiceContract]
    public interface IKalamburyCallback
    {
        [OperationContract(IsOneWay = true)]
        void rysujPunkt(float x1, float y1, float x2, float y2);
        [OperationContract(IsOneWay = true)]
        void dodajUzytkownika(User user);
        [OperationContract(IsOneWay = true)]
        void usunUzytkownika(User user, List<User> uzytkownicy);
        [OperationContract(IsOneWay = true)]
        void ustawHaslo(String name);
        [OperationContract(IsOneWay = true)]
        void wyczyscObraz();
        [OperationContract(IsOneWay = true)]
        void wiadomosc(String wiadomosc);
        [OperationContract(IsOneWay = true)]
        void poprawnaOdp();

    }
}
