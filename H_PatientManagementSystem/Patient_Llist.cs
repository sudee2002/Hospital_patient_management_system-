using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace H_PatientManagementSystem
{

    class PatientNode
    {
        public Patient? Data;
        public PatientNode? Next;


        public PatientNode(Patient data)
        {
            Data = data;
            Next = null;


        }

    }
    class Patient_Llist
    {
        public PatientNode? Head;
        public PatientNode? Tail;
        public Medical_History? History;
        public AppointmentTree Appointments;

        public Patient_Llist()
        {
            Head = null;
            Tail = null;
            History = new Medical_History();
            Appointments = new AppointmentTree();
        }


        //...........................................ADD PATIENT.............................................
        public void AddPatient(Patient patient)
        {
            
            PatientNode? current = Head;
            while (current != null)
            {
                if (current.Data.ID == patient.ID)
                {
                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("           ║         Patient with the same ID was already admitted.        ║");
                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                    //Console.WriteLine("Patient with the same ID was already admitted.");
                    return; 
                }
                current = current.Next;
            }

            
            PatientNode temp = new PatientNode(patient);

            if (Head == null)
            {
                Head = temp;
                Tail = temp;

            }
            else
            {
                Tail.Next = temp;
                Tail = temp;
            }
            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("           ║                  Patient Added Successfully                   ║");
            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
        }
        //.............................................Search Patients.........................................................

        public Patient? SearchPatientByIdOrName(string searchTerm)
        {
            PatientNode? current = Head;
            int patientId;
            bool isNumeric = int.TryParse(searchTerm, out patientId);

            while (current != null)
            {
                
                if (isNumeric && current.Data.ID == patientId)
                {
                    return current.Data;
                }

                
                if (current.Data.Name != null && current.Data.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    return current.Data;
                }

                current = current.Next;
            }

            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("           ║                       No Patient Found .                      ║");
            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
            return null; 
        }


        public Patient? SearchPatientById(int id)
        {
            PatientNode? current = Head;

            while (current != null)
            {
                if (current.Data.ID == id) 
                {
                    return current.Data; 
                }
                current = current.Next; 
            }

            return null; 
        }

        //.............................................Delete Patients....................................................
        public bool DeletePatientById(int patientId)

        {
            if (Head == null)
            {
                //Console.WriteLine("No Patients Currently Admitted");
                Console.Clear();
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                No Patients Currently Admitted                 ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                return false;
            }


            if (Head.Data.ID == patientId)
            {

                //Console.WriteLine("\t\t    Patient " + Head.Data.Name + "was removed from the patient database");
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"           ║  Patient " + Head.Data.Name + "was removed from the patient database");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }

                return true;
            }


            PatientNode current = Head;
            while (current.Next != null && current.Next.Data.ID != patientId)
            {
                current = current.Next;
            }


            if (current.Next != null)
            {
                
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"           ║  Patient " + current.Next.Data.Name + " was removed from the patient database");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");

                current.Next = current.Next.Next;
                if (current.Next == null)
                {
                    Tail = current;
                }
                return true;
            }
            Console.Clear();
            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("           ║                           Invalid ID                          ║");
            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");

            return false;

        }


        //.............................................Display patients........................................................


        public void Display()
        {
            if (Head == null)
            {
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                     No Patients Admitted                      ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                //Console.WriteLine("No Patients Admitted");
                return;
            }

            
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("\t  ╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t  ║ ID   ║ Name                ║ Age ║ Disease            ║ Severity         ║");
            Console.WriteLine("\t  ╚══════════════════════════════════════════════════════════════════════════╝");
            /*Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("| ID   | Name                | Age | Disease            | Severity         |");
            Console.WriteLine("-----------------------------------------------------------------------------");*/

            PatientNode? current = Head;
            while (current != null)
            {
                // Use string interpolation to format the output
                Console.WriteLine($"\t  ║ {current.Data.ID,-4} ║ {current.Data.Name,-19} ║ {current.Data.Age,-3} ║ {current.Data.Disease,-18} ║ {current.Data.Sevearity,-16} ║");
                //Console.WriteLine($"| {current.Data.ID,-4} | {current.Data.Name,-19} | {current.Data.Age,-3} | {current.Data.Disease,-18} | {current.Data.Sevearity,-16} |");
                current = current.Next;
            }

            Console.WriteLine("\t  ╚══════════════════════════════════════════════════════════════════════════╚");
            Console.ResetColor(); 
        }


        //................................................Sort ID by BubbleSort..............................................

        public void SortByID()
        {


            if (Head == null)
            { return; }
            else
            {
                PatientNode? current = Head;
                bool swapped = true;
                while (swapped == true)
                {
                    swapped = false;
                    current = Head;
                    while (current.Next != null)
                    {
                        if (current.Data.ID > current.Next.Data.ID)
                        {
                            swap(current, current.Next);
                            swapped = true;
                        }


                        current = current.Next;
                    }


                }



            }

        }

        //....................................................Sort name by SelectionSOrt....................................................

        //......................................................................................................................................
        public void SortByName()
        {

            PatientNode current = Head;

            while (current != null)
            {
                PatientNode min = current;
                PatientNode temp = current.Next;

                while (temp != null)
                {

                    if (IsFirstStringSmall(temp.Data.Name, min.Data.Name))
                    {
                        min = temp;
                    }

                    temp = temp.Next;
                }
                Patient tempData = current.Data;
                current.Data = min.Data;
                min.Data = tempData;

                current = current.Next;

            }

        }

        private bool IsFirstStringSmall(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            int minLen = (len1 < len2) ? len1 : len2;

            for (int i = 0; i < minLen; i++)
            {
                char c1 = ToLower(str1[i]);
                char c2 = ToLower(str2[i]);

                if (c1 < c2) return true;
                if (c1 > c2) return false;
            }


            return len1 < len2;
        }

        private char ToLower(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return (char)(c + 32); 
            return c;
        }
        //....................................................Sort Sevearity by InsertionSort.......................................
        public void SortBySevearity()
        {

            if (Head == null || Head.Next == null)
                return;

            PatientNode? sorted = null;
            PatientNode? current = Head;

            while (current != null)
            {
                PatientNode next = current.Next;
                sorted = SortedDescending(sorted, current);
                current = next;
            }

            Head = sorted;

        }

        private PatientNode? SortedDescending(PatientNode? sorted, PatientNode newNode)
        {
            if (sorted == null || sorted.Data.Sevearity <= newNode.Data.Sevearity)
            {
                newNode.Next = sorted;
                return newNode;
            }

            PatientNode current = sorted;
            while (current.Next != null && current.Next.Data.Sevearity >= newNode.Data.Sevearity)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            return sorted;
        }
        //........................................................................................................................................

        //......................................................Swap data of two nodes......................................................

        public void swap(PatientNode x, PatientNode y)
        {
            Patient? temp = x.Data;
            x.Data = y.Data;
            y.Data = temp;

        }

        //....................................................Treat patient....................................................
        public void TreatPatient()
        {
            if (Head == null)
            {
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                      No Patients to treat                     ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                return;
            }

            Console.Write("\t\t    Enter Patient ID to treat: ");
            string input = Console.ReadLine();

           
            if (int.TryParse(input, out int id))
            {
                Patient temp = SearchPatientById(id);
                if (temp != null)
                {
                    History.AddToHistory(temp);
                    DeletePatientById(id);
                    //Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                    //Console.WriteLine($"           ║        Patient {temp.Name} (ID: {temp.ID}) treated successfully.       ║");
                    //Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                    return; 
                }
                else
                {
                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("           ║                No patient found with the given ID.            ║");
                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                }
            }
            else
            {
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║        Invalid input. Please enter a valid ID to treat.       ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
            }
        }



        //....................................................Display Medical history..........................................
        public void DisplayMedicalHistory()
        {
            History.DisplayHistory();
        }

        //....................................................scheduling an appointment ..........................................


        public void ScheduleAppointment(int patientId, DateTime appointmentDate)
        {
            Patient? patient = SearchPatientByIdOrName(patientId.ToString());
            if (patient != null)
            {
                patient.Appointments.AddAppointment(appointmentDate);
                //Console.WriteLine($"Appointment scheduled for {patient.ID} on {appointmentDate}");
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"           ║      Appointment scheduled for {patient.ID} on {appointmentDate}");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
            }
            else
            {
                //Console.WriteLine("Patient not found!");
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                       Patient not found!                      ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
            }
        }

        //....................................................Display Appointments ..........................................
        public void DisplayAppointments()
        {
            if (Head == null)
            {
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                     No Patients Admitted                      ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                return;
            }

            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("           ║                     Patients with Appointments                ║");
            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");

            bool hasAppointments = false; 
            PatientNode? current = Head;

            while (current != null)
            {
                if (current.Data.Appointments.Root != null)
                {
                    hasAppointments = true; 

                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                    Console.WriteLine($"           ║ Appointments for patient {current.Data.Name} (ID: {current.Data.ID}):");
                    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("           ║ Date                ║ Time                ║");
                    Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");

                    
                    InOrderTraversal(current.Data.Appointments.Root);

                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                    Console.WriteLine();
                }

                current = current.Next;
            }

            
            if (!hasAppointments)
            {
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║                   No patients have appointments.              ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
            }
        }
        //...................................................................................................................
        

        private void InOrderTraversal(AppointmentNode? root)
        {
            if (root == null)
                return;

            // Traverse the left subtree
            InOrderTraversal(root.Left);

            // Display the current appointment in a formatted table row
            Console.WriteLine($"           ║ {root.AppointmentDate.ToShortDateString(),-19} ║ {root.AppointmentDate.ToShortTimeString(),-19} ║");

            // Traverse the right subtree
            InOrderTraversal(root.Right);
        }





    }

}

