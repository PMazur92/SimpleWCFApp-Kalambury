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
    [ServiceContract(SessionMode=SessionMode.Required, CallbackContract = typeof(IKalamburyCallback))]
    public interface IKalamburyService
    {
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void wyslijPozycje(float x1, float y1, float x2, float y2);
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        User pobierzRysujacego();
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        User dolaczDoGry(string nick);
        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void wyjdzZGry(User uzytkownik);
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        List<User> pobierzUzytkownikow();
        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void wyczysc();
        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void wyslijWiadomosc(User uzytkownik, String wiadomosc);
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        byte[] pobierzGrafike();
    }
}
