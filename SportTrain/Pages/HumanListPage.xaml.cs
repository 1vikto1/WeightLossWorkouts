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
    /// Логика взаимодействия для HumanListPage.xaml
    /// </summary>
    public partial class HumanListPage : Page
    {
        public HumanListPage()
        {
            InitializeComponent();
            CBoxSort.SelectedIndex = 0;
            if (App.DataRole == 2)
                LVievHuman.ItemsSource = App.DataBase.HumanTable.Where(HumanTable => HumanTable.Role == 3).ToList();
            else
                LVievHuman.ItemsSource = App.DataBase.HumanTable.ToList();
        }

        private void BtnEditHuman_Click(object sender, RoutedEventArgs e)
        {
            var Zapis = LVievHuman.SelectedItem as Connect.HumanTable;
            if (Zapis != null)
            {
                NavigationService.Navigate(new AddHumanPage(Zapis));
                App.DataBase.HumanTable.Remove(Zapis);
                App.DataBase.SaveChanges();
                UpdataTable();
            }
            else
                MessageBox.Show("Выберите запись", "Ошибка", MessageBoxButton.OK);
        }

        private void BtnAddHuman_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddHumanPage());
        }

        private void BtnDeleteHuman_Click(object sender, RoutedEventArgs e)
        {
            var UserDialog = MessageBox.Show("Вы уверены что хотите удалить запись ?", "Подтверждение", MessageBoxButton.YesNo);
            if (UserDialog == MessageBoxResult.No)
                return;
            var Zapis = LVievHuman.SelectedItem as Connect.HumanTable;
            App.DataBase.HumanTable.Remove(Zapis);
            App.DataBase.SaveChanges();
            UpdataTable();
        }

        private void TBoxSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdataTable();
        }

        private void CBoxSort_Click(object sender, SelectionChangedEventArgs e)
        {
            UpdataTable();
        }

        private void UpdataTable()
        {
            var CopyTable = App.DataBase.HumanTable.ToList();

            if (App.DataRole == 2)
                CopyTable = CopyTable.Where(HumanTable => HumanTable.Role == 3).ToList();

            if (CBoxSort.SelectedIndex == 0)
                CopyTable = CopyTable.OrderBy(HumanTable => HumanTable.LastName).ToList();
            if (CBoxSort.SelectedIndex == 1)
                CopyTable = CopyTable.OrderByDescending(HumanTable => HumanTable.LastName).ToList();

            CopyTable = CopyTable.Where(HumanTable => HumanTable.FIO.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            
            LVievHuman.ItemsSource = CopyTable;
        }

        private void HumanListPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdataTable();
        }
    }
}
