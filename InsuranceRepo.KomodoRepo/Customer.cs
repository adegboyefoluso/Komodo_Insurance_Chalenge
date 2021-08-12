using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceRepo.KomodoRepo
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public int age
        {
            get
            {
                return DateTime.Now.Year - DateofBith.Year;
            }
        }
        public DateTime DateofBith { get; set; }
        public DateTimeOffset EnrollmentDate { get; set; }
        public int NumberOfYears
        {
            get
            {
                return DateTime.Now.Year - EnrollmentDate.Year;
            }
        }
        
        public Customer() { }

        public Customer(int id, string lastName, DateTime dateOfBirth,DateTime dateofEnrollment)
        {
            CustomerId = id;
            DateofBith = dateOfBirth;
            EnrollmentDate = dateofEnrollment;
            LastName = lastName;
            
        }
    }
}
