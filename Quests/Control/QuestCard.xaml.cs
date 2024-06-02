using Quests.DB;
using Quests.Helper;
using Quests.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Quests.Control
{
    public partial class QuestCard : UserControl
    {
        string _userName;

        public QuestCard()
        {
            InitializeComponent();
        }

        public QuestCard(string name, string adress, int cost, int countPeople)
        {
            InitializeComponent();
            _userName = "";
            QuestName.Text = name;
            QuestAdress.Text = adress;
            QuestCost.Text = cost.ToString() + "р.";
            QuestCountPeople.Text = countPeople.ToString();
        }

        public QuestCard(string userName, string questName, string adress, int cost, int countPeople)
        {
            InitializeComponent();
            _userName = userName;
            QuestName.Text = questName;
            QuestAdress.Text = adress;
            QuestCost.Text = cost.ToString() + "р.";
            QuestCountPeople.Text = countPeople.ToString();
        }

        public Label FindLabelByName(string nameWindow, string label)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Name == nameWindow)
                {
                    return (Label)window.FindName(label);
                }
            }
            return null;
        }

        private void ReserveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var lbl = FindLabelByName("MainQuestWindow", "UserNameLabel");
            if (lbl.Content.ToString() != "Гость")
            {
                var userAuth = EFClass.context.Client.ToList()
                .Where(i => i.Name == lbl.Content.ToString())
                .FirstOrDefault();

                QuestWindow questWindow = new QuestWindow(userAuth.Phone, QuestName.Text);
                questWindow.Show();
            }
            else
            {
                MessageBox.Show("Для бронирования квеста необходимо авторизоваться");
            }
        }
    }
}
