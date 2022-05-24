using ServiceBookingCourseProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBookingCourseProject.Logic
{
    public class ServiceViewLogic
    {
        public Services service { get; set; }
        public ServiceViewLogic(Services service)
        {
            this.service = service;
        }
    }
}
