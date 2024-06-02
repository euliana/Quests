using System.Linq;
using System.Windows;
using Quests.Helper;

namespace Quests.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            var userAuth = EFClass.context.Client.ToList()
                .Where(i => i.Phone == txtLogin.Text && i.Passwords == txtPassword.Password)
                .FirstOrDefault();

            if (userAuth != null)
            {
                DataUser.AuthEmployee = userAuth;

                MainWindow mainWindow = new MainWindow(userAuth.Phone);
                mainWindow.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Пользователь не найден!");
            }

        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn window = new SignIn();
            window.Show();
            this.Close();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }
    }
}
