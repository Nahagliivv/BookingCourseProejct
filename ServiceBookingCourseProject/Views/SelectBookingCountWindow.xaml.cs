using ServiceBookingCourseProject.DB;
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
    /// Логика взаимодействия для SelectBookingCountWindow.xaml
    /// </summary>
    public partial class SelectBookingCountWindow : Window
    {
        Services service;
        public SelectBookingCountWindow(Services service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            try { count = Convert.ToInt32(TextBоxAmount.Text); }
            catch
            {
                MessageBox.Show("Строка не является целым числом"); return;
            }
            using(var db = new BookingDBEntities())
            {
                if ((service.Capacity - count - db.BookedServices.Count(x => x.ServiceID == service.ID)) < 0)
                {
                    MessageBox.Show("На событие нет столько свободных мест"); return;
                }
                if (service.Price * count > StaticData.CurrentUser.balance)
                {
                    MessageBox.Show("На балансе не хватает средств"); return;
                }
                StaticData.CurrentUser.balance -= service.Price * count;
                db.Users.FirstOrDefault(x => x.ID == StaticData.CurrentUser.ID).balance = StaticData.CurrentUser.balance;
                for(int i = 0; i < count; i++)
                {
                    db.BookingRequests.Add(new BookingRequests() { ServiceID = service.ID, UserID = StaticData.CurrentUser.ID});
                }
                db.SaveChanges();
                MessageBox.Show("Запрос на бронирование успешно отправлен");
            }
            
        }
    }
}
