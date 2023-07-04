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

namespace SportTrain.Pages
{
    /// <summary>
    /// Логика взаимодействия для TrainListPage.xaml
    /// </summary>
    public partial class TrainListPage : Page
    {
        public TrainListPage()
        {
            InitializeComponent();
            LVievTrain.ItemsSource = App.DataBase.TrainingTable.ToList();
            if (App.DataRole == 3)
            {
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnEdit.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
                BtnResult.Visibility = Visibility.Visible;
                BtnMyTrain.Visibility = Visibility.Visible;
            }
            else
            {
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnEdit.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
                BtnResult.Visibility = Visibility.Collapsed;
                BtnMyTrain.Visibility = Visibility.Collapsed;
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTrainPage());
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var Zapis = LVievTrain.SelectedItem as Connect.TrainingTable;
            if (Zapis != null)
            {
                NavigationService.Navigate(new AddTrainPage(Zapis));
            }
            else
                MessageBox.Show("Выберите запись", "Ошибка", MessageBoxButton.OK);
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var UserDialog = MessageBox.Show("Вы уверены что хотите удалить запись ?", "Подтверждение", MessageBoxButton.YesNo);
            if (UserDialog == MessageBoxResult.No)
                return;
            var Zapis = LVievTrain.SelectedItem as Connect.TrainingTable;
            App.DataBase.TrainingTable.Remove(Zapis);
            App.DataBase.SaveChanges();
            UpdataTable();
        }
        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResultPage());
        }
        private void BtnMyTrain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyTrainPage());
        }
        private void UpdataTable()
        {
            var CopyTable = App.DataBase.TrainingTable.ToList();

            LVievTrain.ItemsSource = CopyTable;
        }

        private void TrainListPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdataTable();
        }


    }
}
