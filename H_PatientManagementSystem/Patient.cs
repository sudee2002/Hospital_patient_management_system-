using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PatientManagementSystem
{
    class Patient
    {
        public int ID;
        public string ?Name;
        public int Age;
        public string ?Disease;
        public int Sevearity;
        public AppointmentTree Appointments;




        public Patient()
        {
            ID = 0;
            Name = null;
            Age = 0;
            Disease = null;
            Sevearity = 0;
            Appointments = null;
            
        }

        public Patient(int id, string name,int age,string disease,int sevearity)
        {
            ID = id;
            Name = name;
            Age = age;
            Disease = disease;
            Sevearity = sevearity;
            Appointments = new AppointmentTree();
        }


    }


}
