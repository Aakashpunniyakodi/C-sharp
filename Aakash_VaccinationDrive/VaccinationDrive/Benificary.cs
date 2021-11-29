using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    /// <summary>
    /// enum for genders
    /// </summary>
    public enum Genders
    {
        Male = 1,
        Female,
        Transgender,
        Others
    }
    /// <summary>
    /// class benificary to get details of people
    /// </summary>
    class Benificary
    {
        private static int _vaccinationRegisterNumber = 1001;

        public int RegisterNumber;
       
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public Genders Gender  { get; set; }
        public  List<VaccineDetails> VaccineDetails { get; set; }

        public Benificary(string name,long phone,string city,int age,Genders gender)
        {
            this.Name = name;
            this.PhoneNumber = phone;
            this.City = city;
            this.Age = age;
            this.Gender = gender;
            this.RegisterNumber = _vaccinationRegisterNumber++;
        }

    }
}
