using Lorekeeper_Fabien_ARTHUR.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lorekeeper_Fabien_ARTHUR.Objets
{
    public class Personnage
    {
        public int idPersonnage { get; set; }
        public string name { get; set; }
        public int playerId { get; set; }
        public int worldId { get; set; }
        public string? title { get; set; }
        public string? level { get; set; }
        public string? race { get; set; }
        
        public Player? author { get; set; }
        public World? world { get; set; }


        public Personnage(int idPersonnage, string name, int playerId, int worldId, string? title = null, string? level = null, string? race = null) {
            this.name = name;
            this.idPersonnage = idPersonnage;
            this.playerId = playerId;
            this.worldId = worldId;
            this.title = title;
            this.level = level;
            this.race = race;
            Calculate();
        }

        /*
         * Generate everything needed, make world and player corresponding to the character.
         */
        private void Calculate()
        {
            WorldController worldController = WorldController.Instance;
            this.world = worldController.getWorldById(worldId);
            PlayerController playerController = PlayerController.Instance;
            this.author = playerController.getPlayerById(playerId);
        }



    }
}
