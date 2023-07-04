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

namespace SportTrain
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameList.Navigate(new Pages.LoginPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameList.GoBack();
        }

        private void FrameListRendered(object sender, EventArgs e)
        {
            if (FrameList.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Collapsed;

            if (App.DataRole == 3)
            {
                BtnHumanList.Visibility = Visibility.Collapsed;
                BtnExecisesList.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnHumanList.Visibility = Visibility.Visible;
                BtnExecisesList.Visibility =Visibility.Visible;
            }
        }

        private void BtnHumanList_Click(object sender, RoutedEventArgs e)
        {
            FrameList.Navigate(new Pages.HumanListPage());
        }

        private void BtnExecisesList_Click(object sender, RoutedEventArgs e)
        {
            FrameList.Navigate(new Pages.ExercisesListPage());
        }
    }
}
