using Microsoft.Win32;
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
    /// Логика взаимодействия для AddExercisesPage.xaml
    /// </summary>
    public partial class AddExercisesPage : Page
    {
        string AllPath = Directory.GetCurrentDirectory();

        public AddExercisesPage()
        {
            InitializeComponent();
        }

        private void BtnSelectVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Видео | *.mp4"
            };

            if (ofd.ShowDialog() == true)
            {
                string ofdPath = ofd.FileName;
                try
                {
                    if(TBoxNameTrain.Text == "")
                        MessageBox.Show("Напишите название тренировки", "Внимание!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else if(Calendar.SelectedDate.Value.Date.ToShortDateString() == null)
                        MessageBox.Show("Выберите дату", "Внимание!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        File.Move(ofdPath, AllPath + $@"\\{TBoxNameTrain.Text}_{Calendar.SelectedDate.Value.Date.ToShortDateString()}.mp4");
                        MessageBox.Show("Видео добавлено", "Успех!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    var Dialog = MessageBox.Show("Возможно видео уже есть у этой тренировки на выбранную дату. Удалить его ?", "Ошибка!!!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (Dialog == MessageBoxResult.Yes)
                        File.Delete(AllPath + $@"\\{TBoxNameTrain.Text}_{Calendar.SelectedDate.Value.Date.ToShortDateString()}.mp4");
                }
            }
        }

        private void BtnSaveExercises_Click(object sender, RoutedEventArgs e)
        {
            var NewExercises = new Connect.ExercisesTable
            {
                TrainName = TBoxNameTrain.Text,
                Date = Calendar.SelectedDate.Value.Date,
                Exercises = TBoxExercises.Text,
                PathToVideo = AllPath + $@"\\{TBoxNameTrain.Text}_{Calendar.SelectedDate.Value.Date.ToShortDateString()}.mp4"
            };
            App.DataBase.ExercisesTable.Add(NewExercises);
            App.DataBase.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
