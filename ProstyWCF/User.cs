using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace KalamburyWcf
{
    [DataContract]
    public class User
    {
        private static int lastID = 0;
        private int nextID
        {
            get
            {
                lastID++;
                return lastID;
            }
        }
        [DataMember]
        public int id;
        [DataMember]
        public String nick;
        public IKalamburyCallback callback { get; set; }

        public User(string nick, IKalamburyCallback callBack)
        {
            this.nick = nick;
            this.id = nextID;
            this.callback = callBack;
        }

        public override bool Equals(Object uzytkownik)
        {
            return this.id == ((User)uzytkownik).id;
        }
    }
}