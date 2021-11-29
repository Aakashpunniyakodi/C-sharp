using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{/// <summary>
/// enum for vacciene type
/// </summary>
    public enum VaccineType
    {
        CovinShield = 1,
        Covaxin,
        SputniK
    }
    /// <summary>
    ///vaccination details of people
    /// </summary>
    class VaccineDetails
    {

        
        public DateTime VaccinatedDate { get; set; }
        public VaccineType VaccineType { get; set; }
        /// <summary>
        /// type and date of vaccine
        /// </summary>
        /// <param name="vaccineType"></param>
        /// <param name="vaccinatedDate"></param>
        public VaccineDetails(VaccineType vaccineType,DateTime vaccinatedDate)
        {
            this.VaccinatedDate = vaccinatedDate;
            this.VaccineType = vaccineType;
        }
    }
}
