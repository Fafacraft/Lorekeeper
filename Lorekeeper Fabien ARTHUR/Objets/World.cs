using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lorekeeper_Fabien_ARTHUR.Objets
{
    public class World
    {
        public int idworld { get; set; }
        public string name { get; set; }

        public World(int idworld, string name) {
            this.idworld = idworld;
            this.name = name;
        }
    }
}
