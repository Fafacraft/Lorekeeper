using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lorekeeper_Fabien_ARTHUR.Objets
{
    internal class Personnage
    {
        private int idPersonnage;
        private string name;
        private int playerId;
        private int worldId;
        private string? title;
        private string? level;
        private string? race;

        public Personnage(int idPersonnage, string name, int playerId, int worldId, string? title = null, string? level = null, string? race = null) {
            this.name = name;
            this.idPersonnage = idPersonnage;
            this.playerId = playerId;
            this.worldId = worldId;
        }



        public int getIdPersonnage()
        {
            return idPersonnage;
        }
        public string getName()
        {
            return name;
        }
        public int getPlayerId()
        {
            return playerId;
        }
        public int getWorldId()
        {
            return worldId;
        }
        public string? getTitle()
        {
            return title;
        }
        public string? getLevel()
        {
            return level;
        }
        public string? getRace()
        {
            return race;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public void setTitle(string? title)
        {
            this.title = title;
        }
        public void setLevel(string? level)
        {
            this.level = level;
        }
        public void setRace(string? race)
        {
            this.race = race;
        }
    }
}
