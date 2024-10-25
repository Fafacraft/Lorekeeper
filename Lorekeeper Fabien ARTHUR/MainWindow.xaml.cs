using DesktopDev_Arthur_Fabien;
using Lorekeeper_Fabien_ARTHUR.Controllers;
using Lorekeeper_Fabien_ARTHUR.Objets;
using MySqlConnector;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lorekeeper_Fabien_ARTHUR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // get the world name to display it
            string connectionString = Globals.connectionString;

            using (MySqlConnection connection = new MySqlConnection(
              connectionString))
            {
                connection.Open();

                using var command = new MySqlCommand("SELECT name FROM world WHERE idworld = 1;", connection);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine(reader[0]);
                    WorldName.Text = (string)reader[0];
                }

                connection.Close();
            }

            // show all characters names
            PersonnageController persoControllerInstance = PersonnageController.Instance;
            List<Personnage> allPersos = persoControllerInstance.getPersonnageByWorld(1);
            List<string> allNames = new List<string>();
            foreach (Personnage perso in allPersos)
            {
                allNames.Add(perso.getName());
            }
            TestListBox.ItemsSource = allNames;
        }
    }
}