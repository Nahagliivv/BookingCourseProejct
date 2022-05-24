using ServiceBookingCourseProject.DB;
using ServiceBookingCourseProject.Logic;
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
    /// Логика взаимодействия для ServiceView.xaml
    /// </summary>
    public partial class ServiceView : UserControl
    {
        public ServiceView()
        {
            InitializeComponent();
        }
        public Services service { get; set; }
        public ServiceView(Services service)
        {
            //InitializeComponent();
            this.service = service;
            IMG = PictureLogic.LoadImage(service.IMG);
            BeginTime = service.StartDate;
            NameService = service.Name;
        }
        public BitmapImage IMG { get; set; }
        public DateTime BeginTime { get; set; }
        public string NameService { get; set; }
        public void MoreButton_()
        {
            MoreInfWindow miwnd = new MoreInfWindow(service);

            System.Windows.Media.Effects.BlurEffect objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 4;
            App.Current.MainWindow.Effect = objBlur;
            miwnd.ShowDialog();
            App.Current.MainWindow.Effect = null;
        }

        public ICommand MoreButton
        {
            get
            {
                return new DelegateCommand(() => { MoreButton_(); });
            }
        }

    }
}
