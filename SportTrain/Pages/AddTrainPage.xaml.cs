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
using System.IO;
using Microsoft.Win32;

namespace SportTrain.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTrainPage.xaml
    /// </summary>
    public partial class AddTrainPage : Page
    {
        string flag;
        private byte[] ImageData;
        public AddTrainPage()
        {
            InitializeComponent();
        }

        public AddTrainPage(Connect.TrainingTable Zapis)
        {
            InitializeComponent();
            TBoxNameTrain.Text = Zapis.TrainName;
            TBoxDescription.Text = Zapis.TrainDescription;
            flag = Zapis.TrainName;
            MessageBox.Show("Нельзя изменить название, если эта тренировка активна у пользователей", "Внимание!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtnSaveTrain_Click(object sender, RoutedEventArgs e)
        {
            var NewTraining = new Connect.TrainingTable
            {
                TrainName = TBoxNameTrain.Text,
                TrainDescription = TBoxDescription.Text,
                TrainImage = ImageData
            };

            if (flag != null)
            {
                App.DataBase.TrainingTable.FirstOrDefault(p => p.TrainName == flag).TrainName = NewTraining.TrainName;
                App.DataBase.TrainingTable.FirstOrDefault(p => p.TrainName == flag).TrainDescription = NewTraining.TrainDescription;
                App.DataBase.TrainingTable.FirstOrDefault(p => p.TrainName == flag).TrainImage = NewTraining.TrainImage;
            }
            else
                App.DataBase.TrainingTable.Add(NewTraining);
            try
            {
                App.DataBase.SaveChanges();
                MessageBox.Show("Тренировка успешно добавлена в базу данных", "Успешно", MessageBoxButton.OK);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Не удалось добавить тренировку", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Картинка | *.jpg; *.png; *.jpeg"
            };
            if (ofd.ShowDialog() == true)
            {
                ImageData = File.ReadAllBytes(ofd.FileName);
                ImageService.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(ImageData);
            }
        }
    }
}
