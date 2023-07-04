using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SportTrain.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyTrainPage.xaml
    /// </summary>
    public partial class MyTrainPage : Page
    {
        public MyTrainPage()
        {
            var Exercise = App.DataBase.ExercisesTable.FirstOrDefault(p => p.TrainName == App.User.TrainName && p.Date == DateTime.Today);
            InitializeComponent(); 

            if (Exercise != null)
            {
                TBlockNameTread.Text = Exercise.TrainName;
                    
                if(Exercise.PathToVideo != null)
                {
                    Uri uri = new Uri(Exercise.PathToVideo);
                    VideoBox.Source = uri;

                    VideoBox.Play();

                    ImagePause.Visibility = Visibility.Visible;
                    ImagePlay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    VideoBox.Visibility = Visibility.Collapsed;

                    ImageReturn.Visibility = Visibility.Collapsed;
                    ImagePause.Visibility = Visibility.Collapsed;
                    ImagePlay.Visibility = Visibility.Collapsed;
                    ImageMiss.Visibility = Visibility.Collapsed;
                }

                TBlockDeskTread.Text = Exercise.Exercises;
            }
            else
                TBlockNameTread.Text = "На сегодня упражнений нет";
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ImageMiss_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TimeSpan AddSecond = new TimeSpan(0, 0, 0, 15);
            VideoBox.Position = VideoBox.Position + AddSecond;
        }

        private void ImageReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TimeSpan TakeSecond = new TimeSpan(0, 0, 0, 15);
            VideoBox.Position = VideoBox.Position - TakeSecond;
        }

        private void ImagePause_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VideoBox.Pause();

            ImagePause.Visibility = Visibility.Collapsed;
            ImagePlay.Visibility = Visibility.Visible;
        }

        private void ImagePlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VideoBox.Play();

            ImagePause.Visibility = Visibility.Visible;
            ImagePlay.Visibility = Visibility.Collapsed;
        }
    }
}
