using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SportTrain
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Connect.SportTrainDBEntities DataBase { get; set; } = new Connect.SportTrainDBEntities();
        public static int DataRole = 3;
        public static Connect.HumanTable User;
    }
}
