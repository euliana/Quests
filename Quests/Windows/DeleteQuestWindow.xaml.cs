using Quests.Helper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Quests.Windows
{
    public partial class DeleteQuestWindow : Window
    {
        private List<string> _names;
        string _phone;

        public DeleteQuestWindow()
        {
            InitializeComponent();
            _names = new List<string>();
            FillCmbBox();
        }

        public DeleteQuestWindow(string phone)
        {
            _phone = phone;
            InitializeComponent();
            _names = new List<string>();
            FillCmbBox();
        }

        private void FillCmbBox()
        {
            var names = EFClass.context.Quest.Select(q => q.Name).ToList();
            foreach (var name in names)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = name;
                _names.Add(name);
                comboBoxItem.Style = (Style)Resources["MaterialComboBoxItem"];
                ChoiceQuest.Items.Add(comboBoxItem);
            }
        }

        private void DeleteQuestButton_Click(object sender, RoutedEventArgs e)
        {
            int id = ChoiceQuest.SelectedIndex;
            if (id != -1)
            {
                string name = _names[id];
                var quest = EFClass.context.Quest.First(q => q.Name == name);
                EFClass.context.Quest.Remove(quest);
                EFClass.context.SaveChanges();

                Back();
            }
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

        private void BackQuestButton_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
