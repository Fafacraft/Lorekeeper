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
    internal sealed class PlayerController
    {
        private static readonly PlayerController _instance = new PlayerController();
        private string connectionString = Globals.connectionString;

        public PlayerController()
        {
        }
        public static PlayerController Instance
        {
            get { return _instance; }
        }

        /*
         * Get a Player which correspond to ID
        */
        public Player? getPlayerById(int id)
        {
            Player? player = null;

            using (MySqlConnection connection = new MySqlConnection(
              connectionString))
            {
                connection.Open();
                // make the sql request
                using var command = new MySqlCommand("SELECT * FROM player WHERE idplayer = @id;", connection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                System.Diagnostics.Debug.WriteLine("Found player : " + reader.HasRows);

                // for each line returned (should only be one)
                while (reader.Read())
                {
                    int idplayer = (int)reader["idplayer"];
                    string username = (string)reader["username"];
                    string password = (string)reader["password"];
                    string email = (string)reader["email"];

                    player = new Player(idplayer, username, password, email);
                }

                connection.Close();
            }

            return player;
        }
    }
}

