using ServiceBookingCourseProject.DB;
using ServiceBookingCourseProject.Logic;
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
using System.Windows.Shapes;

namespace ServiceBookingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ObservableCollection<ServiceView> ServicesViewsList { get; set; }
        MainWindow mwnd;
        public ServicesPage( MainWindow mwdn)
        {
            InitializeComponent();
            DataContext = this;
            this.mwnd = mwdn;
            ServicesViewsList = new ObservableCollection<ServiceView>();
            InitServices();
        }
        void InitServices()
        {
            using(var db = new BookingDBEntities())
            {
                foreach(var x in db.Services)
                {
                    ServicesViewsList.Add(new ServiceView(x));
                }
            }
        }
        //Поиск
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reg = new Regex(TextBоxServicesSearch.Text);
                ServicesViewsList.Clear();
                using(var db = new BookingDBEntities())
                {
                    foreach(var x in db.Services)
                    {
                        if (reg.IsMatch(ToStringDBEntities.ServicesToString(x))){
                            ServicesViewsList.Add(new ServiceView(x));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неверный формат строки для поиска"); return;
            }
            
        }
    }
}
