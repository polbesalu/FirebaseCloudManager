using Firebase.Auth.UI.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirebaseCloudManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FirebaseUI.Instance.Client.AuthStateChanged += this.AuthStateChanged;
        }

        public void AuthStateChanged(object sender, UserEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (e.User == null)
                {
                    //await FirebaseUI.Instance.Client.SignInAnonymouslyAsync();
                    this.Frame.Navigate(new LoginPage());
                }
                else if (e.User.IsAnonymous)
                {
                    this.Frame.Navigate(new LoginPage());
                }
                else if ((this.Frame.Content == null || this.Frame.Content.GetType() != typeof(MainPage)))
                {
                    this.Frame.Navigate(new GestioCaracters());
                }
            });
        }
    }
}
