using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PatientManagementSystem
{
    class AppointmentTree
    {
        public AppointmentNode? Root;

        public AppointmentTree()
        {
            Root = null;
        }

        public void AddAppointment(DateTime date)
        {
            Root = Insert(Root, date);
        }

        private AppointmentNode Insert(AppointmentNode? root, DateTime date)
        {
            if (root == null)
                return new AppointmentNode(date);

            if (date < root.AppointmentDate)
                root.Left = Insert(root.Left, date);
            else if (date > root.AppointmentDate)
                root.Right = Insert(root.Right, date);

            return root;
        }

        public bool SearchAppointment(DateTime date)
        {
            return Search(Root, date);
        }

        private bool Search(AppointmentNode? root, DateTime date)
        {
            if (root == null)
                return false;
            if (root.AppointmentDate == date)
                return true;
            if (date < root.AppointmentDate)
                return Search(root.Left, date);
            else
                return Search(root.Right, date);
        }
    }
}
