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
using System.Windows.Shapes;

namespace ServiceBookingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для MoreInfWindow.xaml
    /// </summary>
    public partial class MoreInfWindow : Window
    {
        Services service;
        public MoreInfWindow(Services service)
        {
            using (var db = new BookingDBEntities()) {
                this.service = service;
                InitializeComponent();
                LabelName.Content = service.Name;
                LabelCapacity.Content = service.Capacity;
                LabelBeginTime.Content = service.StartDate;
                LabelFreePlaces.Content = service.Capacity - db.BookedServices.Count(x => x.ServiceID == service.ID);
                LabelPrice.Content = service.Price;
                IMG.Source = PictureLogic.LoadImage(service.IMG);
                TextBoxDescription.Text = service.Description;
                LabelType.Content = service.Type; 
            } 
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Комментарии
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommentsWindow commentsWindow = new CommentsWindow(service);
            commentsWindow.ShowDialog();
        }
        //забронировать
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectBookingCountWindow selectBookingCountWindow = new SelectBookingCountWindow(service);
            selectBookingCountWindow.ShowDialog();
        }
    }
}
