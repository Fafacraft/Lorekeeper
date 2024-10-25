using Lorekeeper_Fabien_ARTHUR.Controllers;
using Lorekeeper_Fabien_ARTHUR.Objets;
using Lorekeeper_Fabien_ARTHUR.Utils;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Lorekeeper_Fabien_ARTHUR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Personnage> PersonnageList { get; set; }

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
            List<Personnage> personnages = persoControllerInstance.getPersonnageByWorld(1);
            PersonnageList = new ObservableCollection<Personnage>(personnages);
            DataContext = this;
        }

        private void TestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}