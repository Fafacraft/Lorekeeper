using DesktopDev_Arthur_Fabien;
using Lorekeeper_Fabien_ARTHUR.Objets;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorekeeper_Fabien_ARTHUR.Controllers
{
    internal sealed class PersonnageController
    {
        private static readonly PersonnageController _instance = new PersonnageController();
        private string connectionString = Globals.connectionString;

        public PersonnageController()
        {
        }
        public static PersonnageController Instance
        {
            get { return _instance; }
        }

        /*
         * Get a list of all Personnage linked to the passed worldId
        */
        public List<Personnage> getPersonnageByWorld(int worldIdToSearch)
        {
            List<Personnage> allPerso = new List<Personnage>();

            using (MySqlConnection connection = new MySqlConnection(
              connectionString))
            {
                connection.Open();
                // make the sql request
                using var command = new MySqlCommand("SELECT * FROM personnage WHERE worldId = @idWorld;", connection);
                command.Parameters.AddWithValue("@idWorld", worldIdToSearch);
                MySqlDataReader reader = command.ExecuteReader();
                System.Diagnostics.Debug.WriteLine("Found personnages : " + reader.HasRows);

                // for each line returned
                while (reader.Read())
                {
                    int personnageId = (int)reader["idpersonnage"];
                    string personnageName = (string)reader["name"];
                    int playerId = (int)reader["playerId"];
                    int worldId = (int)reader["worldId"];

                    string? title = reader["title"] == DBNull.Value ? null : (string?)reader["title"];
                    string? level = reader["level"] == DBNull.Value ? null : (string?)reader["level"];
                    string? race = reader["race"] == DBNull.Value ? null : (string?)reader["race"];

                    Personnage perso = new Personnage(personnageId, personnageName, playerId, worldId, title, level, race);

                    allPerso.Add(perso);
                }

                connection.Close();
            }

            return allPerso;
        }

        /*
         * Get a list of all Personnage linked to the passed playerId
        */
        public List<Personnage> getPersonnageByPlayer(int playerIdToSearch)
        {
            List<Personnage> allPerso = new List<Personnage>();

            using (MySqlConnection connection = new MySqlConnection(
              connectionString))
            {
                connection.Open();
                // make the sql request
                using var command = new MySqlCommand("SELECT * FROM personnage WHERE playerId = @idPlayer;", connection);
                command.Parameters.AddWithValue("@idPlayer", playerIdToSearch);
                MySqlDataReader reader = command.ExecuteReader();
                System.Diagnostics.Debug.WriteLine("Found personnages : " + reader.HasRows);

                // for each line returned
                while (reader.Read())
                {
                    int personnageId = (int)reader["idpersonnage"];
                    string personnageName = (string)reader["name"];
                    int playerId = (int)reader["playerId"];
                    int worldId = (int)reader["worldId"];

                    string? title = reader["title"] == DBNull.Value ? null : (string?)reader["title"];
                    string? level = reader["level"] == DBNull.Value ? null : (string?)reader["level"];
                    string? race = reader["race"] == DBNull.Value ? null : (string?)reader["race"];

                    Personnage perso = new Personnage(personnageId, personnageName, playerId, worldId, title, level, race);

                    allPerso.Add(perso);
                }
                connection.Close();
            }

            return allPerso;
        }
    }
}
}
