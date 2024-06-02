using System.Windows;

namespace Quests.Windows
{
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
        }

        public ProfileWindow(string name, string family, string phone, string sex)
        {
            InitializeComponent();
            UserName.Content = name;
            UserFamily.Content = family;
            UserPhone.Content = phone;
            UserSex.Content = sex;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(UserPhone.Content.ToString());
            mainWindow.Show();
            Close();
        }
    }
}
