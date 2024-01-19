using Firebase.Auth.UI;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirebaseCloudManager
{
    /// <summary>
    /// Lógica de interacción para GestioCaracters.xaml
    /// </summary>
    public partial class GestioCaracters : Page
    {
        new CharacterService characterService = new CharacterService();
        public GestioCaracters()
        {
            InitializeComponent();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            var page = new MainPage();
            this.NavigationService.Navigate(page);
        }

        private void UploadFileButton_Click(object sender, RoutedEventArgs e)
        {
            /*Character character = new Character(
                CharacterNameTextBox.Text, 
                CharacterTVShowTextBox.Text, 
                CharacterDescriptionTextBox.Text, 
                FileUploadDatePicker.Text, 
                FileUploadTextBox.Text);*/

            characterService.AddCharacter(new Character(
                CharacterNameTextBox.Text,
                CharacterTVShowTextBox.Text,
                CharacterDescriptionTextBox.Text,
                FileUploadDatePicker.Text,
                FileUploadTextBox.Text)
            );

            DataGrid.ItemsSource = characterService.GetAllCharacters();
        }
    }
}
