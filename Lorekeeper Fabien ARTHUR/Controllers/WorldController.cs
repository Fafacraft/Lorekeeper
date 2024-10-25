using Lorekeeper_Fabien_ARTHUR.Objets;
using Lorekeeper_Fabien_ARTHUR.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorekeeper_Fabien_ARTHUR.Controllers
{
    internal sealed class WorldController
    {
        private static readonly WorldController _instance = new WorldController();
        private string connectionString = Globals.connectionString;

        public WorldController()
        {
        }
        public static WorldController Instance
        {
            get { return _instance; }
        }

        /*
         * Get a World which correspond to ID
        */
        public World? getWorldById(int id)
        {
            World? world = null;

            using (MySqlConnection connection = new MySqlConnection(
              connectionString))
            {
                connection.Open();
                // make the sql request
                using var command = new MySqlCommand("SELECT * FROM world WHERE idworld = @id;", connection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                System.Diagnostics.Debug.WriteLine("Found world : " + reader.HasRows);

                // for each line returned (should only be one)
                while (reader.Read())
                {
                    int idworld = (int)reader["idworld"];
                    string name = (string)reader["name"];

                    world = new World(idworld, name);
                }

                connection.Close();
            }

            return world;
        }
    }
}

