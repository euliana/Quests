using Quests.Helper;
using System;
using System.Linq;
using System.Windows;


namespace Quests.Windows
{
    public partial class QuestWindow : Window
    {
        public QuestWindow()
        {
            InitializeComponent();
        }

        public QuestWindow(string Phone, string questName)
        {
            InitializeComponent();
            cmbTime.Items.Add("12:00" );
            cmbTime.Items.Add("15:00" );
            cmbTime.Items.Add("18:00" );
            cmbTime.Items.Add("21:00" );
            tbNameAuth.Text = questName;
            tbPhone.Text = Phone;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = EFClass.context.Client.ToList()
                .Where(i => i.Phone == tbPhone.Text)
                .FirstOrDefault();

            MessageBox.Show(userAuth.Name + " " + cmbTime.SelectedValue + " ");
            MessageBox.Show(userAuth.Name + " " + dpBookingDate.SelectedDate + " ");

            DB.Order addOrder = new DB.Order();

            addOrder.IdOrder = EFClass.context.Order.ToList().Count + 1000;
            addOrder.IdQuestStuff = 1;
            addOrder.IdClient = userAuth.IdClient;
            addOrder.GameDateTime = (DateTime) dpBookingDate.SelectedDate;
            addOrder.NuberPlayers = Convert.ToInt32(txtCountPlayers.Text);
            addOrder.Cost = null;


            EFClass.context.Order.Add(addOrder);
            EFClass.context.SaveChanges();
            MessageBox.Show(userAuth.Name + ", Вы успешно записаны на квест!");

            MainWindow main = new MainWindow(tbPhone.Text);
            main.Show();
            this.Close();
        }
    }
}
