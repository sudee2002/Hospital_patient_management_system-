using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PatientManagementSystem
{
    class AppointmentNode
    {
         
        public DateTime AppointmentDate;
        public AppointmentNode? Left, Right;

        public AppointmentNode(DateTime date)
        {
            AppointmentDate = date;
            Left = Right = null;
        }
    }


}
