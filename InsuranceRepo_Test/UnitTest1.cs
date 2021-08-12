using InsuranceRepo.KomodoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InsuranceRepo_Test
{
    [TestClass]
    public class UnitTest1
    {
        private Customer _customer;
        private KomodoRepository _repo;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoRepository();
            _customer = new Customer
            {
                CustomerId = 1,
                DateofBith = new DateTime(1980,01,01),
                EnrollmentDate = new DateTime(2015,01,01),
                LastName = "Android"
            };
            _repo.AddCustomer(_customer);

        }
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var customer = new Customer();
            Assert.AreEqual("Android", _repo.GetCustomerById(1).LastName);
            var customer1 = new Customer(2, "Kelvin", new DateTime(1974,05,01), new DateTime(2021,05,01));
            _repo.AddCustomer(customer1);
            Assert.AreEqual(customer1, _repo.GetCustomerById(2));
            var customer2= new Customer(3, "Macathy", new DateTime(1950,06,01), new DateTime(2021,05,01));

            _repo.SendMessage();
        }
    }
}
