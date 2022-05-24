using ServiceBookingCourseProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBookingCourseProject.Logic
{
    public static class ToStringDBEntities
    {
        public static string UserToString(Users u)
        {
            return u.ID + " " + u.FullName + " " + u.Email + " " + u.balance;
        }
        public static string ServicesTypesToString(ServicesTypes st)
        {
            return st.ID +" "+  st.Text;
        }
        public static string ServicesToString(Services s)
        {
            return s.ID + " " + s.Description + " " + s.Type + " " + s.Capacity + " " + s.StartDate.ToString() + s.Price.ToString();
        }
        public static string BookingRequestsToString(BookingRequests br)
        {
            return br.ID + " " + br.UserID + " " + br.ServiceID;
        }
    }
}
