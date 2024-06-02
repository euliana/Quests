using Quests.Helper;
using System;
using System.Linq;
using System.Windows;

namespace Quests.Windows
{
    public partial class AddQuestWindow : Window
    {
        string _phone;

        public AddQuestWindow()
        {
            InitializeComponent();
            _phone = "";
        }

        public AddQuestWindow(string phone)
        {
            InitializeComponent();
            _phone = phone;
        }

        private void AddQuestbutton_Click(object sender, RoutedEventArgs e)
        {
            if (NotIsEmpty())
            {
                var quest = new DB.Quest();
                quest.IdQuest = EFClass.context.Quest.ToList().Count + 1000;
                quest.Name = QuestName.Text;
                quest.Adress = QuestAdress.Text;
                quest.Cost = Convert.ToDecimal(QuestCost.Text);
                quest.MaxPlayer = Convert.ToInt32(QuestCountPeople.Text);
                EFClass.context.Quest.Add(quest);
                EFClass.context.SaveChanges();

                Back();
            }
        }

        private bool NotIsEmpty()
        {
            if (QuestName.Text.Length != 0 && QuestAdress.Text.Length != 0 && QuestCost.Text.Length != 0
                && QuestCountPeople.Text.Length != 0)
                return true;
            return false;
        }

        private void Back()
        {
            MainWindow mainWindow;

            if (_phone.Length != 0)
            {
                mainWindow = new MainWindow(_phone);
                mainWindow.Show();
            }
            else
            {
                mainWindow = new MainWindow();
                mainWindow.Show();
            }
            Close();
        }

        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
