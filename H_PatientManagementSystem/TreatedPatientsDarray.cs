using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PatientManagementSystem
{
    class TreatedPatientsDarray
    {
        private Patient[] Treated_Patients;
        private int capacity;
        private int count;

        public TreatedPatientsDarray(int cap= 1)
        {
            capacity = cap;
            count = 0;
            Treated_Patients = new Patient[capacity];
        }

        public void Add(Patient p)
        {
            if(count == capacity)
            {
                Resize();
            }
            
            Treated_Patients[count] = p;
            count++;
            
        }

        private void Resize()
        {
            Patient[] temp2 = new Patient[capacity * 2];
            for(int i = 0;i<count;i++)
            {
                temp2[i] = Treated_Patients[i];

            }
            Treated_Patients = temp2;
            capacity = capacity * 2;
        }
        public void Display_M()
        {
            if(count==0)
            {
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                      No Treated Patients                      ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
            }
            else
            {
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║              Medical History of Treated Patients:             ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                //Console.WriteLine("\nMedical History of Treated Patients:");
                Console.WriteLine();
                Console.WriteLine("\t  ╔══════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t  ║ ID   ║ Name                ║ Age ║ Disease            ║ Severity         ║");
                Console.WriteLine("\t  ╚══════════════════════════════════════════════════════════════════════════╝");
                for (int i = 0; i < count; i++)
                {


                    Console.WriteLine($"\t  ║ {Treated_Patients[i].ID,-4} ║ {Treated_Patients[i].Name,-19} ║ {Treated_Patients[i].Age,-3} ║ {Treated_Patients[i].Disease,-18} ║ {Treated_Patients[i].Sevearity,-16} ║");
                  /*  Console.Write("ID: " + Treated_Patients[i].ID + "   ");
                    Console.Write("Name: " + Treated_Patients[i].Name + "   ");
                    Console.Write("Age: " + Treated_Patients[i].Age + "   ");
                    Console.Write("Disease: " + Treated_Patients[i].Disease + "   ");
                    Console.Write("Sivearity: " + Treated_Patients[i].Sevearity + "   ");
                    Console.WriteLine();*/
                }
                

            }
        }




    }


}
