using ServiceBookingCourseProject.DB;
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
    /// Логика взаимодействия для CommentView.xaml
    /// </summary>
    public partial class CommentView : UserControl
    {
        Comments comment;
        public CommentView()
        {
            InitializeComponent();
        }
        public CommentView(Comments comment)
        {
            this.comment = comment; 
            using(var db = new BookingDBEntities())
            {
                Text = comment.Text;
                PublicDate = comment.PublicDate.ToString();
                UserFullName = db.Users.FirstOrDefault(x=>x.ID == comment.UserID).FullName;
            }
            
        }
        public string Text { get; set; }
        public string UserFullName { get; set; }
        public string PublicDate { get; set; }
    }
}
