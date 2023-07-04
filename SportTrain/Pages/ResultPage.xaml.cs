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
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        private void BtnSaveResult_Click(object sender, RoutedEventArgs e)
        {

            var NewResult = App.DataBase.HumanTable.FirstOrDefault(p => p.id == App.User.id);

            NewResult.UserResult = TBoxResult.Text;

            App.DataBase.SaveChanges();
            MessageBox.Show("Результат успешно обновлен", "Информация", MessageBoxButton.OK);
            NavigationService.GoBack();
        }
    }
}
