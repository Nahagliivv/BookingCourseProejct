using ServiceBookingCourseProject.DB;
using ServiceBookingCourseProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : Page
    {
        MainWindow mwnd;
        public ObservableCollection<Services> ListServices { get; set; }
        public MyProfilePage(MainWindow mwnd)
        {
            InitializeComponent();
            this.mwnd = mwnd;
            InitText();
            DataContext = this;
            ListServices = new ObservableCollection<Services>();
            InitList();
        }

        void InitText()
        {
            LabelEmail.Content = StaticData.CurrentUser.Email;
            LabelFullName.Content = StaticData.CurrentUser.FullName;
            LabelBalance.Content = StaticData.CurrentUser.balance;
        }
        void InitList()
        {
            using(var db = new BookingDBEntities())
            {
                foreach(var x in db.BookedServices.Where(x=>x.UserID == StaticData.CurrentUser.ID)){
                    ListServices.Add(db.Services.FirstOrDefault(z => z.ID == x.ServiceID));
                }
            }
        }
    }
}
