using ServiceBookingCourseProject.Models;
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
using System.Windows.Shapes;

namespace ServiceBookingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        
        public EnterWindow()
        {
            InitializeComponent();
            Mainframe.Content = new LoginPage(this);
        }
        //Свернуть окно
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        //Закрыть приложение
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StaticData.CurrentUser = null;
            Mainframe.Content = new LoginPage(this);
            ExitButton.Visibility = Visibility.Hidden;
        }
    }
}
