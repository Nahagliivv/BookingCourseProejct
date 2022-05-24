using ServiceBookingCourseProject.DB;
using ServiceBookingCourseProject.Logic;
using ServiceBookingCourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        EnterWindow entwnd;
        Regex regEmail;
        Regex regName;
        Regex regPassword;
        public RegistrationPage(EnterWindow entwnd)
        {
            InitializeComponent();
            this.entwnd = entwnd;
            regEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            regName = new Regex(@"([А-ЯЁ][а-яё]+[\-\s]?){3,}");
            regPassword = new Regex(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");
        }
        //назад
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            entwnd.Mainframe.Content = new LoginPage(entwnd);
        }
        //Регистрация
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!regName.IsMatch(TextBоxName.Text)) { ErrorMessage.Content = "ФИО должно быть Имя Фамилия Отчество"; return; }
            if (!regEmail.IsMatch(TextBoxEmail.Text)) { ErrorMessage.Content = "Неверный формат почты"; return; }
            using(var db = new BookingDBEntities())
            {
                if(db.Users.Count(x=>x.Email == TextBoxEmail.Text) > 0)
                {
                    ErrorMessage.Content = "Пользователь с такой почтой зарегистрирован"; return;
                }
            }
            if (!regPassword.IsMatch(PasswordBox.Password))
            {
                ErrorMessage.Content = "В пароле должны быть: цифра, буквы нижнего и \nверхнего регистра, длина от 8 до 16 символов ";
                return;
            }
            if (PasswordBox.Password != PasswordBoxRepeat.Password)
            {
                ErrorMessage.Content = "Пароли не совпадают";
                return;
            }
            Users newUser = new Users() { FullName = TextBоxName.Text , Email = TextBoxEmail.Text, balance = 0, IsAdministrator = false, HashPassword = HashPassword.Hash(PasswordBox.Password) };
            using(var db = new BookingDBEntities())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            StaticData.CurrentUser = newUser;
            entwnd.Mainframe.Content = new LoginPage(entwnd);
            MessageBox.Show("Регистрация успешно завершена");
        }
    }
}
