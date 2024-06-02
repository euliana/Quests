using Quests.Helper;
using System.Linq;
using System.Windows;

namespace Quests.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
            StartWindow();
        }

        private void StartWindow()
        {
            //CmbGender.ItemsSource = Helper.AppData.Context.Gender.ToList();
            //CmbGender.DisplayMemberPath = "Name";
            //CmbGender.SelectedIndex = 0;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            DB.Client user = new DB.Client();

            user.Surname = txtSurname.Text;
            user.Name = txtName.Text;
            user.Phone = txtPhone.Text;
            user.Passwords = txtPassword.Password;
            user.Birthday = dpBirthday.SelectedDate.Value;
            user.idGender = CmbGender.SelectedIndex + 1;
            Helper.AppData.Context.Client.Add(user);
            Helper.AppData.Context.SaveChanges();

            var userAuth = EFClass.context.Client.ToList()
                .Where(i => i.Phone == txtPhone.Text && i.Passwords == txtPassword.Password)
                .FirstOrDefault();

            MainWindow mainWindow = new MainWindow(userAuth.Phone);
            mainWindow.Show();
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

   