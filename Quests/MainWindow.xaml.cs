using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Quests.Control;
using Quests.DB;
using Quests.Helper;
using Quests.Windows;

namespace Quests
{
    public partial class MainWindow : Window
    {
        string _phone; 

        public MainWindow()
        {
            InitializeComponent();
            GetInfo();
            _phone = "";
        }

        private void GetInfo()
        {
            foreach (var quest in EFClass.context.Quest.ToList())
            {
                QuestCard questCard = new QuestCard(quest.Name, quest.Adress, Convert.ToInt32(quest.Cost), quest.MaxPlayer);
                questCard.Margin = new Thickness(0, 0, 50, 50);
                questCard.Width = 700;
                questCard.Height = 300;
                QuestsPanel.Children.Add(questCard);
            }
        }

        public MainWindow(string Phone)
        {
            var userAuth = EFClass.context.Client.ToList()
                .Where(i => i.Phone == Phone)
                .FirstOrDefault();

            InitializeComponent();
            _phone = Phone;
            AuthButton.Visibility = Visibility.Collapsed;
            RegButton.Visibility = Visibility.Collapsed;
            UserNameLabel.Content = userAuth.Name;
            GetInfo();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn authWindow = new SignIn();
            authWindow.Show();
            this.Close();
        }

        private void ExitLabelMenuItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ProfilePageLabelMenuItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (UserNameLabel.Content != "Гость")
            {
                var user = EFClass.context.Client.
                        FirstOrDefault(i => i.Name == UserNameLabel.Content);
                ProfileWindow profileWindow = new ProfileWindow(user.Name, user.Surname, user.Phone, user.Gender.Name);
                profileWindow.Show();
                Close();
            }
        }

        private void DeleteQuestLabelMenuItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DeleteQuestWindow deleteQuestWindow;

            if (_phone.Length > 0)
            {
                deleteQuestWindow = new DeleteQuestWindow(_phone);
                deleteQuestWindow.Show();
            }
            else
            {
                deleteQuestWindow = new DeleteQuestWindow(_phone);
                deleteQuestWindow.Show();
            }

            Close();
        }

        private void AddQuestLabelMenuItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AddQuestWindow addQuestWindow;

            if (_phone.Length > 0)
            {
                addQuestWindow = new AddQuestWindow(_phone);
                addQuestWindow.Show();
            }
            else
            {
                addQuestWindow = new AddQuestWindow(_phone);
                addQuestWindow.Show();
            }

            Close();
        }

        private void SortByCostUp_Click(object sender, RoutedEventArgs e)
        {
            QuestsPanel.Children.Clear();
            foreach (var quest in EFClass.context.Quest.OrderBy(q => q.Cost).ToList())
            {
                QuestCard questCard = new QuestCard(quest.Name, quest.Adress, Convert.ToInt32(quest.Cost), quest.MaxPlayer);
                questCard.Margin = new Thickness(0, 0, 50, 50);
                questCard.Width = 700;
                questCard.Height = 300;
                QuestsPanel.Children.Add(questCard);
            }
        }

        private void SortByCostDown_Click(object sender, RoutedEventArgs e)
        {
            QuestsPanel.Children.Clear();
            foreach (var quest in EFClass.context.Quest.OrderByDescending(q => q.Cost).ToList())
            {
                QuestCard questCard = new QuestCard(quest.Name, quest.Adress, Convert.ToInt32(quest.Cost), quest.MaxPlayer);
                questCard.Margin = new Thickness(0, 0, 50, 50);
                questCard.Width = 700;
                questCard.Height = 300;
                QuestsPanel.Children.Add(questCard);
            }
        }

        private void SortByCountPeopleUp_Click(object sender, RoutedEventArgs e)
        {
            QuestsPanel.Children.Clear();
            foreach (var quest in EFClass.context.Quest.OrderBy(q => q.MaxPlayer).ToList())
            {
                QuestCard questCard = new QuestCard(quest.Name, quest.Adress, Convert.ToInt32(quest.Cost), quest.MaxPlayer);
                questCard.Margin = new Thickness(0, 0, 50, 50);
                questCard.Width = 700;
                questCard.Height = 300;
                QuestsPanel.Children.Add(questCard);
            }
        }

        private void SortByCountPeopleDown_Click(object sender, RoutedEventArgs e)
        {
            QuestsPanel.Children.Clear();
            foreach (var quest in EFClass.context.Quest.OrderByDescending(q => q.MaxPlayer).ToList())
            {
                QuestCard questCard = new QuestCard(quest.Name, quest.Adress, Convert.ToInt32(quest.Cost), quest.MaxPlayer);
                questCard.Margin = new Thickness(0, 0, 50, 50);
                questCard.Width = 700;
                questCard.Height = 300;
                QuestsPanel.Children.Add(questCard);
            }
        }
    }
}
