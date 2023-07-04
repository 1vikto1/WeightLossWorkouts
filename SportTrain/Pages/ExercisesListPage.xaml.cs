using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ExercisesListPage.xaml
    /// </summary>
    public partial class ExercisesListPage : Page
    {
        public ExercisesListPage()
        {
            InitializeComponent();
            CBoxSort.SelectedIndex = 0;
        }

        private void CBoxSort_Click(object sender, SelectionChangedEventArgs e)
        {
            UpdataTable();
        }

        private void TBoxSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdataTable();
        }

        private void BtnAddExercises_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddExercisesPage());
        }

        private void BtnDeleteExercises_Click(object sender, RoutedEventArgs e)
        {
            var UserDialog = MessageBox.Show("Вы уверены что хотите удалить запись ?", "Подтверждение", MessageBoxButton.YesNo);
            if (UserDialog == MessageBoxResult.No)
                return;
            var Zapis = LVievExercises.SelectedItem as Connect.ExercisesTable;
            App.DataBase.ExercisesTable.Remove(Zapis);
            File.Delete(Zapis.PathToVideo);
            App.DataBase.SaveChanges();
            UpdataTable();
        }

        private void UpdataTable()
        {
            var CopyTable = App.DataBase.ExercisesTable.ToList();


            if (CBoxSort.SelectedIndex == 0)
                CopyTable = CopyTable.OrderBy(ExercisesTable => ExercisesTable.TrainName).ToList();
            if (CBoxSort.SelectedIndex == 1)
                CopyTable = CopyTable.OrderByDescending(ExercisesTable => ExercisesTable.TrainName).ToList();

            CopyTable = CopyTable.Where(ExercisesTable => ExercisesTable.TrainName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LVievExercises.ItemsSource = CopyTable;
        }

        private void ExercisesListPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdataTable();
        }
    }
}
