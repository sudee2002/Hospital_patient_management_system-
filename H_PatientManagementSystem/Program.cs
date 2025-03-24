using System;
using System.Diagnostics;

namespace H_PatientManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient_Llist patientList = new Patient_Llist();


            //**************************************************************************************************************************
            
            string filePath = "patients.txt"; 
            Random random = new Random();

            
            string[] firstNames = {
                "John", "Jane", "Alice", "Bob", "Charlie", "Diana", "Eve", "Frank", "Grace", "Henry",
                "Liam", "Olivia", "Noah", "Emma", "Oliver", "Ava", "Elijah", "Sophia", "William", "Isabella",
                "James", "Mia", "Benjamin", "Amelia", "Lucas", "Harper", "Mason", "Evelyn", "Ethan", "Abigail",
                "Alexander", "Emily", "Michael", "Elizabeth", "Daniel", "Ella", "Matthew", "Scarlett", "Jackson", "Avery",
                "Sebastian", "Sofia", "Aiden", "Chloe", "David", "Victoria", "Joseph", "Grace", "Samuel", "Lily"
            };
            string[] lastNames = {
                "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
                "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
                "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
                "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts"
            };
            string[] diseases = {
                "Flu", "Cold", "Fever", "Headache", "Stomachache", "Back Pain", "Allergy", "Asthma", "Diabetes", "Hypertension",
                "Migraine", "Arthritis", "Bronchitis", "Pneumonia", "Sinusitis", "Gastritis", "Ulcer", "Anemia", "Osteoporosis", "Tuberculosis",
                "Malaria", "Dengue", "Cholera", "Hepatitis", "Kidney Stones", "Appendicitis", "Gallstones", "Thyroid Disorder", "Epilepsy", "Psoriasis",
                "Eczema", "Lupus", "Fibromyalgia",   "Crohn's Disease", "Diverticulitis", "Gout",  "Osteoarthritis",
                "Cataracts", "Glaucoma",  "Tinnitus", "Vertigo", "Insomnia", "Sleep Apnea", "Emphysema", "Lung Cancer"
            };

            
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                
                for (int i = 1; i <= 100; i++)
                {
                    
                    string firstName = firstNames[random.Next(firstNames.Length)];
                    string lastName = lastNames[random.Next(lastNames.Length)];
                    string name = $"{firstName} {lastName}";
                    int age = random.Next(18, 80); 
                    string disease = diseases[random.Next(diseases.Length)];
                    int severity = random.Next(1, 11); 

                    
                    string patientData = $"{i},{name},{age},{disease},{severity}";
                    writer.WriteLine(patientData);
                }
            }
            
            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("           ║         Random patient data file created successfully!        ║");
            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");

            //**************************************************************************************************************************

            
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        
                        string[] patientData = line.Split(',');

                       
                        int id = int.Parse(patientData[0]);
                        string name = patientData[1];
                        int age = int.Parse(patientData[2]);
                        string disease = patientData[3];
                        int severity = int.Parse(patientData[4]);


                        Patient newPatient = new Patient(id, name, age, disease, severity);
                        patientList.AddPatient(newPatient);
                    }
                }
                
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║              Patient data loaded successfully!                ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
            }
            else
            {
                
                Console.WriteLine("         ╔═══════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("         ║    Patient data file not found. Starting with an empty list.      ║");
                Console.WriteLine("         ╚═══════════════════════════════════════════════════════════════════╝");
            }
            
            //**************************************************************************************************************************

            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Cyan; // Set text color
                
                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("           ║               Hospital Patient Management System              ║");
                Console.WriteLine("           ╠═══════════════════════════════════════════════════════════════╣");
                Console.WriteLine("           ║                1. Add Patient                                 ║");
                Console.WriteLine("           ║                2. Display Patient Details                     ║");
                Console.WriteLine("           ║                3. Search Patient Details                      ║");
                Console.WriteLine("           ║                4. Delete Patient Details                      ║");
                Console.WriteLine("           ║                5. Sort Patient Details                        ║");
                Console.WriteLine("           ║                6. Scheduling an Appointment                   ║");
                Console.WriteLine("           ║                7. Display Appointmnets                        ║");
                Console.WriteLine("           ║                8. Treat Patients                              ║");
                Console.WriteLine("           ║                9. View Medical History                        ║");
                Console.WriteLine("           ║               10. Exit                                        ║");
                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                Console.ResetColor(); // Reset text color to default



                int choice;
                Console.Write("\t\t    ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Clear();
                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("           ║           Invalid input. Please enter a valid number.         ║");
                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        // Add Patient
                        Console.Clear();
                        Console.Write("\t\t    Enter Patient ID: ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                        {
                            
                            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("           ║           Invalid input. Please enter a valid number.         ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                            Console.Write("\t\t    Enter Patient ID: ");
                        }



                        Console.Write("\t\t    Enter Patient Name: ");
                        string name;
                        while (true)
                        {
                            name = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter)) { break; }

                            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("           ║           Invalid input. Please enter a valid name.           ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                            Console.Write("\t\t    Enter Patient Name: ");
                        }




                         Console.Write("\t\t    Enter Patient Age: ");
                        int age;
                        while (!int.TryParse(Console.ReadLine(), out age))
                        {
                            
                            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("           ║           Invalid input. Please enter a valid number.         ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                            Console.Write("\t\t    Enter Patient Age: ");
                        }




                        Console.Write("\t\t    Enter Patient Disease: ");
                        string disease;
                        while(true)
                        {
                            disease = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(disease) && disease.All(char.IsLetter)) { break; }

                            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("           ║           Invalid input. Please enter a valid disease.        ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                            Console.Write("\t\t    Enter Patient disease: ");
                        }



                        Console.Write("\t\t    Enter Patient Severity: ");
                        int severity;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out severity) && severity >= 0 && severity <= 10)
                            {
                                break; 
                            }
                            
                            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("           ║   Invalid input. Severity must be a number between 0 and 10.  ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                            Console.Write("\t\t    Enter Patient Severity: ");
                        }



                        Patient newPatient = new Patient(id, name, age, disease, severity);
                        patientList.AddPatient(newPatient);

                        
                        break;



                    case 2:
                        Console.Clear();
                        // Display Patients
                        //Console.WriteLine("\n\t\t    List of Patients:");
                        Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("           ║                       List of Patients:                       ║");
                        Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                        patientList.Display();
                        break;

                    case 3:
                        Console.Clear();
                        //Search patients
                        Console.Write("\n\t\t    Inset Patient Name or ID:");
                        string sname = Console.ReadLine();
                        Patient S = patientList.SearchPatientByIdOrName(sname);
                        if(S !=null)
                        {
                            Console.WriteLine("\t  ╔══════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("\t  ║ ID   ║ Name                ║ Age ║ Disease            ║ Severity         ║");
                            Console.WriteLine("\t  ╚══════════════════════════════════════════════════════════════════════════╝");
                            Console.WriteLine($"\t  ║ {S.ID,-4} ║ {S.Name,-19} ║ {S.Age,-3} ║ {S.Disease,-18} ║ {S.Sevearity,-16} ║");
                            break;
                        }
                        /* Console.Write("ID: " + S.ID + "   ");
                         Console.Write("Name: " + S.Name + "   ");
                         Console.Write("Age: " + S.Age + "   ");
                         Console.Write("Disease: " + S.Disease + "   ");
                         Console.Write("Sivearity: " + S.Sevearity + "   \n");*/
                        break;

                    case 4:
                        Console.Clear();
                        //Delete Patients
                        Console.Write("\n\t\t    Insert Patient ID: ");
                        int Did;
                        while (!int.TryParse(Console.ReadLine(), out Did))
                        {

                            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("           ║           Invalid input. Please enter a valid number.         ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                            Console.Write("\n\t\t    Insert Patient ID: ");
                        }

                        patientList.DeletePatientById(Did);
                        break;

                    case 5:
                        Console.Clear();
                        // Sort Patients 
                        while (true)
                        {
                            Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("           ║                       Sort Patients By:                       ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                            Console.WriteLine("           ║                       1. ID                                   ║");
                            Console.WriteLine("           ║                       2. Name                                 ║");
                            Console.WriteLine("           ║                       3. Sevearity                            ║");
                            Console.WriteLine("           ║                       4. Display Patients                     ║");
                            Console.WriteLine("           ║                       5. Back to Main Menu                    ║");
                            Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                          /*  Console.WriteLine("\n\t\t    Sort Patients By:");
                            Console.WriteLine("\t\t    1. ID");
                            Console.WriteLine("\t\t    2. Name");
                            Console.WriteLine("\t\t    3. Sevearity");
                            Console.WriteLine("\t\t    4. Back to Main Menu");*/
                            Console.Write("\t\t    Enter your choice: ");

                            int sortChoice;
                            if (!int.TryParse(Console.ReadLine(), out sortChoice))
                            {
                                Console.Clear();
                                Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("           ║           Invalid input. Please enter a valid number.         ║");
                                Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                continue;
                            }

                            switch (sortChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    // Bubble Sort
                                    Stopwatch S1 = new Stopwatch();
                                    S1.Start();
                                    patientList.SortByID();
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║           Patients sorted by ID using Bubble Sort.            ║");
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    S1.Stop();
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║                Elapsed Time in Miliseconds: " + S1.ElapsedMilliseconds);
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    break;

                                case 2:
                                    Console.Clear();
                                    // Selection Sort
                                    Stopwatch S2 = new Stopwatch();
                                    S2.Start();
                                    patientList.SortByName();
                                    
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║         Patients sorted by Name using Selection Sort.         ║");
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    S2.Stop();
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║                Elapsed Time in Miliseconds: " + S2.ElapsedMilliseconds);
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    //Console.WriteLine("Patients sorted by Name using Selection Sort.");
                                    break;

                                case 3:
                                    Console.Clear();
                                    // Insertion Sort
                                    Stopwatch S3 = new Stopwatch();
                                    S3.Start();

                                    patientList.SortBySevearity();
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║        Patients sorted by Sevearity using Insertion Sort.     ║");
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    //Console.WriteLine("Patients sorted by Sevearity using Insertion Sort.");
                                    S3.Stop();
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║                Elapsed Time in Miliseconds: " + S3.ElapsedMilliseconds);
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    //Console.WriteLine("Elapsed Time in Miliseconds: " + S3.ElapsedMilliseconds);
                                    break;



                                case 4:
                                    Console.Clear();
                                    // Display Sorted patients

                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║                       List of Patients:                       ║");
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    patientList.Display();

                                    break;

                                case 5:
                                    Console.Clear();
                                    // Back to Main Menu
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║                   Returning to the main menu...               ║");
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");

                                    break;

                                default:
                                    Console.Clear();
                                    //Console.WriteLine("Invalid choice. Please try again.");
                                    Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("           ║           Invalid input. Please enter a valid number.         ║");
                                    Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                                    break;
                            }

                            if (sortChoice == 5)
                            {
                                break; // Exit Sorting
                            }
                        }
                        break;

                    case 6:
                        //Scheduling Appointments
                        Console.Clear();
                        Console.Write("\t\t    Enter Patient ID: ");
                        if (int.TryParse(Console.ReadLine(), out int patientId))
                        {
                            Console.Write("\t\t    Enter Appointment Date (yyyy-MM-dd): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDate))
                            {
                                Console.Write("\t\t    Enter Appointment Time (HH:mm): ");
                                if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan appointmentTime))
                                {
                                    // Combine date and time
                                    DateTime fullAppointmentDateTime = appointmentDate.Date.Add(appointmentTime);

                                    // Schedule appointment
                                    patientList.ScheduleAppointment(patientId, fullAppointmentDateTime);
                                }
                                else
                                {
                                    Console.WriteLine("\t\t    Invalid time format. Please use HH:mm (24-hour format).");
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t\t    Invalid date format. Please use yyyy-MM-dd.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\t\t    Invalid Patient ID. Please enter a valid number.");
                        }
                        break;
                    case 7:
                        Console.Clear();
                        //Display Appoinments
                        //Console.Write("\t\t    Enter patient ID to display appointments: ");
                        //int Id = int.Parse(Console.ReadLine());

                        // Call the method to display appointments
                        //patientList.DisplayAppointments(Id);
                        patientList.DisplayAppointments();
                        break;

                    case 8:
                        //Treat Patients
                        Console.Clear();

                        patientList.TreatPatient();
                        break;

                    case 9:
                        Console.Clear();
                        //View Medical History


                        patientList.DisplayMedicalHistory();
                        break;

                    case 10:
                        Console.Clear();
                        // Exit
                        //Console.WriteLine("\t\t    Exiting the program...");

                        Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("           ║                  Exiting the program...                       ║");
                        Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("           ╔═══════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("           ║       Invalid input. Please enter a valid number.             ║");
                        Console.WriteLine("           ╚═══════════════════════════════════════════════════════════════╝");
                        //Console.WriteLine("Invalid choice. Please try again.");
                        //new comment
                        break;
                }
            }
        }
    }
}