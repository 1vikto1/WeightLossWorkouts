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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var flag = App.DataBase.HumanTable.FirstOrDefault(p => p.Login == TBoxLogin.Text && p.Password == PBoxPassword.Password);

            if (flag != null)
            {
                App.DataRole = (int)flag.Role;
                App.User = flag;
                MessageBox.Show($"Доброго времени суток, {flag.FirstName}", "Вход произведен", MessageBoxButton.OK);
                NavigationService.Navigate(new TrainListPage());
            }
            else
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK);
        }

        private void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.DataRole = 3;
        }
    }
}
