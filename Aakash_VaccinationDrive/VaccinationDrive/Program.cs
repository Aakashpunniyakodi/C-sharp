using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    //creating class for implementation
    class Program
    {
        /// <summary>
        /// create list for store benificary details
        /// </summary>
        private List<Benificary> benificaryList = new List<Benificary>();

        /// <summary>
        /// Main program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program userObject = new Program();//craeting object
            userObject.UserDetails();
            string userContinue;
            do
            {
                Console.WriteLine("#######  Vaccination System ########");
                Console.WriteLine("*****step towards healthy life******");
                Console.WriteLine("1. Benificary details");
                Console.WriteLine("2. Vaccination");
                Console.WriteLine("3. Exit");
                Console.WriteLine("4.Show all(Admin only)");
                Console.Write("Choose :>> ");
                int userOption = int.Parse(Console.ReadLine());

                switch (userOption)
                {
                    case 1:
                        userObject.BenificaryDetails();
                        break;
                    case 2:
                        userObject.Vaccination();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong! Option ");
                        break;
                }
                Console.Write("Do you want to continue ?(yes/no)");
                userContinue = Console.ReadLine().ToLower();
            }
            while (userContinue == "yes");


            Console.ReadKey();
        }
        /// <summary>
        /// Default data insert
        /// </summary>
        public void UserDetails()
        {
            var firstUser = new Benificary("Aaki", 970123608, "Ariyalur", 31, (Genders)1);
            var seconduser = new Benificary("Papu", 9000078654, "japan", 21, (Genders)2);
            var thirduser = new Benificary("Bhai", 9988007756, "tokyo", 23, (Genders)3);


            benificaryList.Add(firstUser);
            benificaryList.Add(seconduser);
            benificaryList.Add(thirduser);
        }
        /// <summary>
        /// Get Benificary Details and update
        /// </summary>
        public void BenificaryDetails()
        {
            string userOption;
            do
            {
                Console.Write("Benificary Name ");
                string name = Console.ReadLine();
                Console.Write("Benificary Phone Number ");
                long phoneNumber = Int64.Parse(Console.ReadLine());
                Console.Write("Benificary City ");
                string city = Console.ReadLine();
                Console.Write("Benificary Age ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("1.Male 2.Female 3.Transgender 4.Others");
                Console.Write("Benificary Gender ");
                Genders Gender = (Genders)int.Parse(Console.ReadLine());

                var Details = new Benificary(name, phoneNumber, city, age, Gender);
                benificaryList.Add(Details);

                Console.WriteLine("***Registration Success***");
                Console.WriteLine($"Your Register Number : {Details.RegisterNumber}");

                Console.Write("\nDo you want to continue?(yes/no)");
                userOption = Console.ReadLine().ToLower();
            }
            while (userOption == "yes");
        }

        /// <summary>
        /// vaccinating
        /// </summary>
        public void Vaccination()
        {
            string userOption;
            Console.WriteLine("vaccination details");
            Console.Write("Register Number  ");
            int registerNumber = int.Parse(Console.ReadLine());
            foreach (Benificary details in benificaryList)
            {
                if (details.RegisterNumber == registerNumber)
                {

                    Console.WriteLine($"hi : {details.Name}");
                    Console.WriteLine("-------------------------------");
                    do
                    {
                        Console.WriteLine("1. Take vaccination");
                        Console.WriteLine("2. Vaccination History");
                        Console.WriteLine("3. Next Due Date");
                        Console.WriteLine("4. Exit");
                        Console.Write("Choose : ");
                        int userChoose = int.Parse(Console.ReadLine());
                        switch (userChoose)
                        {
                            case 1:
                                Console.WriteLine("choose  vaccine");
                                Console.Write("1. CovinShield 2. Covaxin 3. Sputnik Choose :>> ");
                                VaccineType vaccineType = (VaccineType)int.Parse(Console.ReadLine());
                                if (details.RegisterNumber == registerNumber)
                                {
                                    VaccineDetails user = new VaccineDetails(vaccineType, DateTime.Now);

                                    if (details.VaccineDetails == null)
                                    {
                                        details.VaccineDetails = new List<VaccineDetails>();
                                    }
                                    details.VaccineDetails.Add(user);
                                }
                                Console.WriteLine("your vaccination is completed");
                                break;
                            case 2:
                                VaccinHistory(registerNumber);
                                break;
                            case 3:
                                DueDate(registerNumber);
                                break;
                            case 4:
                                
                            default:
                                Console.WriteLine("No option available");
                                break;

                        }
                        Console.Write("Do you want to continue?(yes/no):>> ");
                        userOption = Console.ReadLine().ToLower();
                    }
                    while (userOption == "yes");
                }
            }
        }
        /// <summary>
        /// Show vaccination history
        /// </summary>
        /// <param name="registernumber"></param>

        public void VaccinHistory(int registernumber)
        {
            foreach (Benificary detail in benificaryList)
            {
               
                if (detail.RegisterNumber == registernumber)
                {
                    if (detail.VaccineDetails != null)
                    {
                        Console.WriteLine($"Name : {detail.Name}"+ $"Age : {detail.Age}" +$"Gender : {detail.Gender}" +$"Mobile Number : {detail.PhoneNumber} " +$"City : {detail.City}" +$"Vaccination : {detail.VaccineDetails[0].VaccineType}");
                    }
                }
            }
        }
        /// <summary>
        /// giving due date to the user
        /// </summary>
        /// <param name="regno"></param>
        public void DueDate(int regno)
        {
            foreach (Benificary data in benificaryList)
            {
                if (data.RegisterNumber == regno)
                {
                    if (data.VaccineDetails != null)
                    {
                        if (data.VaccineDetails.Count == 1)
                        {
                            Console.WriteLine($"Next Vaccine Due :{data.VaccineDetails[0].VaccineType}");
                            Console.WriteLine($"Next Duedate :{data.VaccineDetails[0].VaccinatedDate.AddDays(30)}");
                        }

                        else if (data.VaccineDetails.Count == 2)
                        {
                            Console.WriteLine("You have completed the vaccination course.\nThanks for your participation in the vaccination drive.");
                        }
                    }
                }
            }
        }
    }
}

