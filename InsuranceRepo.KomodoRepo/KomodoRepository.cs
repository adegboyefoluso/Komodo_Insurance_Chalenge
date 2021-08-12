using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceRepo.KomodoRepo
{
    public class KomodoRepository
    {
        private readonly List<Customer> _komodoRepo = new List<Customer>();
        public void AddCustomer(Customer model)
        {
            _komodoRepo.Add(model);
          

        }

        public List<Customer> GetAllCustomer()
        {
            return _komodoRepo;
        }
        
        public bool UpdateCustomer(int customerId, Customer model)
        {
            var customer = GetCustomerById(customerId);
            if (customer is null) return false;
            else
            {
                customer.DateofBith = model.DateofBith;
                customer.EnrollmentDate = model.EnrollmentDate;
                customer.LastName = model.LastName;
                customerId = model.CustomerId;
                return true;
            }
        }
        public Customer GetCustomerById(int customerId)
        {
            foreach (var item in _komodoRepo)
            {
                if (item.CustomerId == customerId)
                {
                    return item;
                }
            }
            return null;
        }
        public bool DeleteCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer is null) return false;
            else
            {
                _komodoRepo.Remove(customer);
                return true;
            }
        }

        public void SendMessage()
        {
            foreach (var item in _komodoRepo)
            {
                if(item.NumberOfYears>=1&& item.NumberOfYears <= 5)
                {
                    Console.WriteLine($"Mr/Mrs {item.LastName}, We are so happy for your Journey with us in the last {item.NumberOfYears} year");
                    Console.WriteLine(" ");
                }
                else if (item.NumberOfYears > 5)
                {
                    Console.WriteLine($"Mr/Mrs {item.LastName}, Thank you for being a Gold Member");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine($"{item.LastName}, You are less than a year.");
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
