using Microsoft.Win32;
using ServiceBookingCourseProject.DB;
using ServiceBookingCourseProject.Logic;
using ServiceBookingCourseProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace ServiceBookingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        EnterWindow entwnd;
        Regex searchReg;
        public ObservableCollection<Users> ListUsers { get; set; }
        public ObservableCollection<ServicesTypes> ListServicesTypes { get; set; }
        public ObservableCollection<Services> ListServices { get; set; }
        public ObservableCollection<BookingRequests> ListBookingRequests { get; set; }
        public Users SelectedUser { get; set; }
        public ServicesTypes SelectedTypeService { get; set; }
        public Services SelectedService { get; set; }
        public BookingRequests SelectedBookingRequest { get; set; }
        string defaultIMG = "pack://application:,,,/Styles/DefaultImg.jpg";
        byte[] editImg;
        byte[] saveImg;
        StreamResourceInfo img;
        public AdminPage(EnterWindow entwnd)
        {
            InitializeComponent();
            this.entwnd = entwnd;
            ListUsers = new ObservableCollection<Users>();
            ListServicesTypes = new ObservableCollection<ServicesTypes>();
            ListServices = new ObservableCollection<Services>();
            ListBookingRequests = new ObservableCollection<BookingRequests>();
            DataContext = this;
            TimePickerStartDate.Text = DateTime.Today.ToString();
            InitLists();
            ImageInit();
        }
        void InitLists()
        {
            using(var db = new BookingDBEntities())
            {
                foreach(var x in db.Users)
                {
                    if(x.ID == StaticData.CurrentUser.ID)
                    {
                        continue;
                    }
                    ListUsers.Add(x);
                }
                foreach(var x in db.ServicesTypes)
                {
                    ListServicesTypes.Add(x);
                }
                foreach(var x in db.Services)
                {
                    ListServices.Add(x);
                }
                foreach(var x in db.BookingRequests)
                {
                    ListBookingRequests.Add(x);
                }
            }
        }
        //+баланс
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null) { MessageBox.Show("Пользователь не выбран");return; }
            decimal addedBalance = 0;
            try { addedBalance = Convert.ToDecimal(TextBоxBalanceEdit.Text); } catch { MessageBox.Show("Введена неверная строка для добавления баланса"); return; }
            using(var db = new BookingDBEntities())
            {
                db.Users.FirstOrDefault(x => x.ID == SelectedUser.ID).balance += addedBalance;
                db.SaveChanges();
            }
            MessageBox.Show("Баланс успешно изменен");
            entwnd.Mainframe.Content = new AdminPage(entwnd);
        }
        //-баланс
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null) { MessageBox.Show("Пользователь не выбран"); return; }
            decimal addedBalance = 0;
            try { addedBalance = Convert.ToDecimal(TextBоxBalanceEdit.Text); } catch { MessageBox.Show("Введена неверная строка для добавления баланса"); return; }
            if (SelectedUser.balance < addedBalance) { MessageBox.Show("Баланс не может быть отрицательным"); return;  }
            using (var db = new BookingDBEntities())
            {
                db.Users.FirstOrDefault(x => x.ID == SelectedUser.ID).balance -= addedBalance;
                db.SaveChanges();
            }
            MessageBox.Show("Баланс успешно изменен");
            entwnd.Mainframe.Content = new AdminPage(entwnd);
        }
        //поиск пользователей
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                ListUsers.Clear();
                searchReg = new Regex(TextBоxSearchUsers.Text);
                using (var db = new BookingDBEntities())
                {
                    foreach (var user in db.Users)
                    {
                        if (user.ID == StaticData.CurrentUser.ID) { continue; }
                        if (searchReg.IsMatch(ToStringDBEntities.UserToString(user)))
                        {
                            ListUsers.Add(user);
                        }
                    }
                }
            }
            catch { MessageBox.Show("Неверный формат строки"); }
        }
        //добавить вид услуги
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (TextBоxServiceType.Text == "") { MessageBox.Show("Нельзя создать тип сервисы с пустым названием"); return; }
            using (var db = new BookingDBEntities()) {
                if(db.ServicesTypes.Count(x => x.Text == TextBоxServiceType.Text) > 0) { MessageBox.Show("Такой тип сервиса уже существует в бд"); return; }
                db.ServicesTypes.Add(new ServicesTypes() { Text = TextBоxServiceType.Text });
                db.SaveChanges();
                MessageBox.Show("Вид услуги успешно добавлен");
                entwnd.Mainframe.Content = new AdminPage(entwnd);
            }
        }
        //Удаление вмда услуги
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (SelectedTypeService == null) { MessageBox.Show("Вид сервиса для удаления не выбран"); return; }
            using(var db = new BookingDBEntities())
            {
                if (db.Services.Count(x => x.Type == SelectedTypeService.ID) > 0) { MessageBox.Show("Нельзя удалить тип пока он используется в услуге"); return; }
                db.ServicesTypes.Attach(SelectedTypeService);
                db.ServicesTypes.Remove(SelectedTypeService);
                db.SaveChanges();
                MessageBox.Show("Вид услуги успешно удалён");
                entwnd.Mainframe.Content = new AdminPage(entwnd);
            }
        }
        //Поиск вида услуги
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                ListServicesTypes.Clear();
                searchReg = new Regex(TextBоxServiceTypeSearch.Text);
                using (var db = new BookingDBEntities())
                {
                    foreach (var type in db.ServicesTypes)
                    {
                        if (searchReg.IsMatch(ToStringDBEntities.ServicesTypesToString(type)))
                        {
                            ListServicesTypes.Add(type);
                        }
                    }
                }
            }
            catch { MessageBox.Show("Неверный формат строки"); }
        }
        //Добавление услуги
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (TextBоxName.Text == "") { MessageBox.Show("Название сервиса не может быть пустой строкой"); return; }
            if (TextBоxDescriptionService.Text == "") { MessageBox.Show("Описание сервиса не может быть пустой строкой"); return; }
            int typeServId = 0;
            int capacityHuman = 0;
            decimal price = 0;
            try
            {
                typeServId = Convert.ToInt32(TextBоxTypeId.Text);
            }
            catch { MessageBox.Show("Id вида сервиса не число"); return; }
            using (var db = new BookingDBEntities()) {
                ServicesTypes typeServ = db.ServicesTypes.FirstOrDefault(x=>x.ID == typeServId);
                if (typeServ == null) { MessageBox.Show("Вида сервиса с таким Id не существует"); return; }

                try
                {
                    capacityHuman = Convert.ToInt32(TextBоxCapacityHuman.Text);
                }
                catch { MessageBox.Show("Вместимость не число"); return; }

                if (DateTime.Parse(TimePickerStartDate.Text) < DateTime.Today)
                {
                    MessageBox.Show("Нельзя ставить событие на прошлое"); return;
                }
                try
                {
                    price = Convert.ToDecimal(TextBoxPrice.Text);
                }
                catch { MessageBox.Show("Цена не число"); return; }
                DateTime startTime;
                try
                {
                    startTime = DateTime.ParseExact(TimePickerStartDate.Text + " " + TextBoxTime.Text + ":00", "dd.MM.yyyy HH:mm:ss", null);
                }
                catch { MessageBox.Show("Неверный формат времени"); return; }
                Services newService = new Services() {Name = TextBоxName.Text, Capacity = capacityHuman,Price = price, Type = typeServId, Description = TextBоxDescriptionService.Text, StartDate = startTime, IMG = editImg};
                db.Services.Add(newService);
                db.SaveChanges();
                MessageBox.Show("Сервис успешно добавлен");
                entwnd.Mainframe.Content = new AdminPage(entwnd);
            } }
        //Удаление выбранной услуги
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (SelectedService == null) { MessageBox.Show("Услуга для удаления не выбрана"); return; }
            using(var db = new BookingDBEntities())
            {
                while (db.Comments.Count(x => x.ServiceID == SelectedService.ID) != 0)
                {
                    db.SaveChanges();
                    foreach (var x in db.Comments.Where(x => x.ServiceID == SelectedService.ID))
                    {
                        db.Comments.Remove(x);
                       
                        break;
                    }
                }
                while (db.BookedServices.Count(x => x.ServiceID == SelectedService.ID) != 0)
                {
                    db.SaveChanges();
                    foreach (var x in db.BookedServices.Where(x => x.ServiceID == SelectedService.ID))
                    {
                        db.BookedServices.Remove(x);
                   
                        break;
                    }
                }
                while (db.BookingRequests.Count(x => x.ServiceID == SelectedService.ID) != 0)
                {
                    db.SaveChanges();
                    foreach (var x in db.BookingRequests.Where(x => x.ServiceID == SelectedService.ID))
                    {
                        db.BookingRequests.Remove(x);
                       
                        break;
                    }
                }
                try {
                db.Services.Attach(SelectedService);
                    db.Services.Remove(SelectedService);
                    db.SaveChanges();
                    MessageBox.Show("Услуга успешно удалена");
                    entwnd.Mainframe.Content = new AdminPage(entwnd);
                } catch { MessageBox.Show("Ошибка при удалении услуги"); return; }
            }
        }
        //найти услугу
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try { 
            ListServices.Clear();
            searchReg = new Regex(TextBоxServicesSearch.Text);
            using (var db = new BookingDBEntities())
            {
                foreach (var service in db.Services)
                {
                    if (searchReg.IsMatch(ToStringDBEntities.ServicesToString(service)))
                    {
                        ListServices.Add(service);
                    }
                }
            } }
            catch { MessageBox.Show("Неверный формат строки"); }
        }
        //подтвердить запрос
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedBookingRequest == null) { MessageBox.Show("Запрос для подтверждения не выбран"); return; }
            using(var db = new BookingDBEntities())
            {
                db.BookedServices.Add(new BookedServices() { ServiceID = SelectedBookingRequest.ServiceID, UserID = SelectedBookingRequest.UserID});
                db.BookingRequests.Attach(SelectedBookingRequest);
                db.BookingRequests.Remove(SelectedBookingRequest);
                db.SaveChanges();
                MessageBox.Show("Запрос успешно подтверждён");
                entwnd.Mainframe.Content = new AdminPage(entwnd);
            }
            }
            catch { MessageBox.Show("Ошибка при подтверждении"); entwnd.Mainframe.Content = new AdminPage(entwnd); return; }
        }
        //отклонить запрос
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedBookingRequest == null) { MessageBox.Show("Запрос для отклонения не выбран"); return; }
                using (var db = new BookingDBEntities())
                {
                    db.BookingRequests.Attach(SelectedBookingRequest);
                    db.BookingRequests.Remove(SelectedBookingRequest);
                    var selServ = db.Services.FirstOrDefault(x => x.ID == SelectedBookingRequest.ServiceID);
                    db.Users.FirstOrDefault(x => x.ID == SelectedBookingRequest.UserID).balance += selServ.Price;
                    db.SaveChanges();
                    MessageBox.Show("Запрос успешно отклонён");
                    entwnd.Mainframe.Content = new AdminPage(entwnd);
                }
            }
            catch { MessageBox.Show("Ошибка при отклонении"); entwnd.Mainframe.Content = new AdminPage(entwnd); return; }
        }
        //поиск запроса на бронирование
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            try { 
            ListBookingRequests.Clear();
            searchReg = new Regex(TextBоxBookingServiceSearch.Text);
            using (var db = new BookingDBEntities())
            {
                foreach (var bReq in db.BookingRequests)
                {
                    if (searchReg.IsMatch(ToStringDBEntities.BookingRequestsToString(bReq)))
                    {
                        ListBookingRequests.Add(bReq);
                    }
                }
            } }
            catch { MessageBox.Show("Неверный формат строки"); }
        }
        //инициализация изображения
        void ImageInit()
        {
            try
            {
                ServiceImage.Source = new BitmapImage(new Uri(defaultIMG));
                img = System.Windows.Application.GetResourceStream(new Uri(defaultIMG));
                editImg = PictureLogic.ReadFully(img.Stream);
                saveImg = PictureLogic.ReadFully(img.Stream);
            }
            catch
            {
                MessageBox.Show("Ошибка инициализации изображения"); return;
            }
        }
        //выбор изображения
        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {   //открытие диалоговог окна
                OpenFileDialog openwnd = new OpenFileDialog
                {
                    Filter = "Image files(*.png)|*.png|Image files(*.jpg)|*.jpg"
                };
                openwnd.ShowDialog();
                editImg = PictureLogic.PictureToByte(openwnd.FileName);
                ServiceImage.Source = new BitmapImage(new Uri(openwnd.FileName));
            }
            catch
            {
                editImg = saveImg;
                return;
            }
        }
    }
}
