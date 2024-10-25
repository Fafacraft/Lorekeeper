using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lorekeeper_Fabien_ARTHUR.Objets
{
    public class Player
    {
        public int idplayer { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public Player(int idplayer, string username, string password, string email) {
            this.idplayer = idplayer;
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
}
