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
    /// Логика взаимодействия для AddHumanPage.xaml
    /// </summary>
    public partial class AddHumanPage : Page
    {
        public AddHumanPage()
        {
            InitializeComponent();
        }
        public AddHumanPage(Connect.HumanTable Zapis)
        {
            InitializeComponent();
            TBoxFirstName.Text = Zapis.FirstName;
            TBoxLastName.Text = Zapis.LastName;
            TBoxDate.Text = Convert.ToString(Zapis.BirthDate);
            CBoxGender.Text = Zapis.Gender;
            CBoxRole.Text = Zapis.DataRole;
            TBoxLogin.Text = Zapis.Login;
            PBoxPassword.Password = Zapis.Password;
            TBoxTrain.Text = Zapis.TrainName;
            TBoxResult.Text = Zapis.UserResult;
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (TBoxFirstName.Text == "")
                flag = true;
            if (TBoxLastName.Text == "")
                flag = true;
            if (TBoxDate.Text == "")
                flag = true;
            if (CBoxRole.Text == "")
                flag = true;
            if (TBoxLogin.Text == "")
                flag = true;
            if (PBoxPassword.Password == "")
                flag = true;

            if (flag)
            {
                MessageBox.Show("Ошибка ввода!!!", "Ошибка", MessageBoxButton.OK);
                return;
            }

            var NewZapis = new Connect.HumanTable
            {
                FirstName = TBoxFirstName.Text,
                LastName = TBoxLastName.Text,
                BirthDate = Convert.ToDateTime(TBoxDate.Text),
                Gender = CBoxGender.Text,
                Role = CBoxRole.SelectedIndex + 1,
                Login = TBoxLogin.Text,
                Password = PBoxPassword.Password,
                TrainName = TBoxTrain.Text,
                UserResult = TBoxResult.Text,
            };
            App.DataBase.HumanTable.Add(NewZapis);
            App.DataBase.SaveChanges();
            MessageBox.Show("Человек успешно добавлен!!!", "Информация", MessageBoxButton.OK);
            NavigationService.GoBack();
        }
    }
}
