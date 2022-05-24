using ServiceBookingCourseProject.DB;
using ServiceBookingCourseProject.Logic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServiceBookingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        EnterWindow entwnd;
        public LoginPage(EnterWindow entwnd)
        {
            this.entwnd = entwnd;   
            InitializeComponent();
            entwnd.ExitButton.Visibility = Visibility.Hidden;

        }
        //Переход на страницу регистрации
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            entwnd.Mainframe.Content = new RegistrationPage(entwnd);
        }
        //Вход
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new BookingDBEntities())
            {
                int linq = db.Users.Count(q => q.Email == TextBoxEmail.Text);
                if (linq == 0)
                {
                    ErrorMessage.Content = "Зарегистрированного пользователя с такой почтой \nнет";
                    return;
                }
                var user = db.Users.FirstOrDefault(q => q.Email == TextBoxEmail.Text);
                if (HashPassword.VerifyHashedPassword(user.HashPassword, PasswordBox.Password))
                {

                    StaticData.CurrentUser = user;
                    if (StaticData.CurrentUser.IsAdministrator == true)
                    {
                        entwnd.Mainframe.Content = new AdminPage(entwnd);
                        entwnd.ExitButton.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        App.Current.MainWindow.Hide();
                        App.Current.MainWindow = new MainWindow();
                        App.Current.MainWindow.Show();
                    }
                }
                else
                {
                    ErrorMessage.Content = "Неверный пароль";
                    return;
                }
            }
        }
    }
}
