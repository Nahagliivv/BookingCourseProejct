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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mainframe.Content = new ServicesPage(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        //Закрыть приложение
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        //Выход
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            StaticData.CurrentUser = null;
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new EnterWindow();
            App.Current.MainWindow.Show();
        }
        //Мой профиль
        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Content = new MyProfilePage(this);
        }
        //Услуги
        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Content = new ServicesPage(this);
        }
    }
}
