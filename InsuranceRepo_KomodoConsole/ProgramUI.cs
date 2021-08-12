using InsuranceRepo.KomodoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsuranceRepo_KomodoConsole
{
    public class ProgramUI
    {
        private readonly KomodoRepository _repo = new KomodoRepository();
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Seed()
        {
            Customer customer = new Customer(1, "Mike", new DateTime(1980, 05, 01), new DateTime(2019, 05, 03));
            Customer customer1 = new Customer(2, "Collins", new DateTime(1980, 05, 01), new DateTime(2004, 05, 03));
            Customer customer2 = new Customer(3, "Fredrick", new DateTime(1980, 05, 01), new DateTime(2021, 05, 03));

            _repo.AddCustomer(customer);
            _repo.AddCustomer(customer1);
            _repo.AddCustomer(customer2);
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Menu:\n" +
                    "1.Add Customer\n" +
                    "2.Get All Customer\n" +
                    "3.Update Customer's detail\n" +
                    "4.Delete Customer\n" +
                    "5.Send Message to Customer\n" +
                    "6.Get Customer By Id\n" +
                    "7.Exit");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        GetAllCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        SendMessage();
                        break;
                    case "6":
                        GetCustomerById();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid Menu number\n" +
                            "Press any key to continue........");
                        Console.ReadKey();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("GoodBye");
            Thread.Sleep(2500);
        }
        private void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Clear();
            bool isValidLastName = true;
            while (isValidLastName)
            {
                Console.Write("Enter  Customer's Last Name: ");
                
                string LastName = Console.ReadLine();
                Console.WriteLine(" ");


                if (string.IsNullOrWhiteSpace(LastName))
                {
                    Console.WriteLine("Please enter a valid LastName (press any key to continue)");
                    Console.WriteLine(" ");
                    Console.ReadKey();

                }
                else
                {
                    customer.LastName = LastName;
                    isValidLastName = false;
                }
            }

            
            Console.Write("Enter Customer Date of Birth in this format MM/DD/YYYY: ");
           
            DateTime dateofBirtth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            customer.DateofBith = dateofBirtth;
            Console.Write("Enter Customer's Entollment Date in this format MM/ DD/yyyy: ");
            
            DateTime EnrollmentYear = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            customer.EnrollmentDate = EnrollmentYear;
            Console.Write("Enter the Custome Id:");
            
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            customer.CustomerId = customerId;

            _repo.AddCustomer(customer);

            Console.WriteLine("Customer Added Succesfully!");
            Console.WriteLine(" ");
            Console.WriteLine("Press any Key to Continue.........");
            Console.ReadKey();





        }
        private void GetAllCustomer()
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine("\t\tList  Of  Customers");
            Console.WriteLine("...................................................");
            Console.WriteLine($"{"CustomerId",-10}| {"Last Name",-10} |{"Age",-10}|{"NUmber of Years",-15}");
            Console.WriteLine("...................................................");
            foreach (var item in _repo.GetAllCustomer())
            {
                Console.WriteLine($"{item.CustomerId,-11} {item.LastName,-11} {item.age,-11}{item.NumberOfYears,-17}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCustomer()
        {
            Console.Clear();
            GetAllCustomer();
            Console.WriteLine(" ");
            Console.Write("What customer do you want to update? Select the customer's Id from the list Above:  ");
            int customerId = int.Parse(Console.ReadLine());
           
            Customer customer = new Customer();
            Console.Clear();
            bool isValidLastName = false;
            while (!isValidLastName)
            {
                Console.Write("Enter  Customer's Last Name");
                string LastName = Console.ReadLine();


                if (string.IsNullOrWhiteSpace("LastName"))
                {
                    Console.WriteLine("Please enter a valid LastName (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    customer.LastName = LastName;
                    isValidLastName = true;
                }
            }


            Console.Write("Enter Customer Date of Birth in this format MM/DD/yyyy: ");
            DateTime dateofBirtth = DateTime.Parse(Console.ReadLine());
            customer.DateofBith = dateofBirtth;
            Console.Write("Enter Customer's Entollment year in this format MM / DD / yyyy: ");
            DateTime EnrollmentYear = DateTime.Parse(Console.ReadLine());
            customer.EnrollmentDate = EnrollmentYear;
            Console.Write("Enter the Custome Id:");
            int customersId = int.Parse(Console.ReadLine());
            customer.CustomerId = customersId;

            
            if(_repo.UpdateCustomer(customerId, customer))
            {
                Console.WriteLine("Customer Updated Succesfully");
                Console.WriteLine(" ");
                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Customer Not Found");
                Console.WriteLine(" ");
                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();

            }


        }
        private void DeleteCustomer()
        {
            GetAllCustomer();
            Console.Write("What customer do you want to Delete? Select the customer's Id:  ");
            int customerId = int.Parse(Console.ReadLine());
            var customr = _repo.GetCustomerById(customerId);
            if(customr is null)
            {
                Console.WriteLine("Customer not found :(");
            }
            else
            {
                Console.WriteLine($"Are you sure you want to remove {customr.LastName} form the Directory ? (y/n)");
                string response = Console.ReadLine();
                if (response.ToLower() == "y" || response.ToLower() == "yes")
                {
                    _repo.DeleteCustomer(customerId);
                    Console.WriteLine($"{customr.LastName}  is now removed form the Directory!");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("Nevermind then...");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();


        }

        private void SendMessage()
        {
            Console.Clear();
            _repo.SendMessage();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void GetCustomerById()
        {
            Console.Clear();
            Console.Write("Enter the Customer's Id:  ");
            
            int customerId = int.Parse(Console.ReadLine());
            var customer = _repo.GetCustomerById(customerId);
            if(customer is null)
            {
                Console.WriteLine(" ");
                Console.WriteLine("There is no cutomer with that Id!");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("CUSTOMER'S DETAILS");
                Console.WriteLine($"Last Name: {customer.LastName}\n" +
                    $"Age:{customer.age}\n" +
                    $"Enrollement year: {customer.EnrollmentDate.ToString("d")}\n" +
                    $"Date Of Birth: {customer.DateofBith.ToString("d")}");
                    
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}
