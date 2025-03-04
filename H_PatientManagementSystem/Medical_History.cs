using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PatientManagementSystem
{
    class Medical_History
    {
        private TreatedPatientsDarray TreatedPatients;

        public Medical_History()
        {
            TreatedPatients = new TreatedPatientsDarray();
        }

        public void AddToHistory(Patient p)
        {
            TreatedPatients.Add(p);
            //Console.WriteLine("\t\t    Patient " + p.Name +" was treated and added to history successfully");
            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"           ║  Patient " + p.Name + " was treated and added to history successfully");
            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");

        }

        public void DisplayHistory()
        {
            TreatedPatients.Display_M();

        }




    }
    
}
