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
using System.Windows.Shapes;

namespace ServiceBookingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для CommentsWindow.xaml
    /// </summary>
    public partial class CommentsWindow : Window
    {
        Services service;
        public ObservableCollection<CommentView> commentsList { get; set; }
        public CommentsWindow(Services service)
        {
            this.service = service;
            InitializeComponent();
            DataContext = this;
            commentsList = new ObservableCollection<CommentView>();
            InitComments();
        }
        void InitComments()
        {
            using(var db = new BookingDBEntities())
            {
                foreach(var x in db.Comments.Where(x=>x.ServiceID == service.ID)){
                    commentsList.Add(new CommentView(x));
                }
            }
        }
        //отправить коммент
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxToWrite.Text == null || TextBoxToWrite.Text == "") { return; }
            Comments comment = new Comments()
            {
                ServiceID = service.ID,
                PublicDate = DateTime.Now,
                Text = TextBoxToWrite.Text,
                UserID = StaticData.CurrentUser.ID,

            };
            using (var db = new BookingDBEntities())
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            TextBoxToWrite.Text = "";
            commentsList.Add(new CommentView(comment));
        }
    }
}
