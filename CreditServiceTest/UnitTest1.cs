using System;
using CreditServiceTest.CreditService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new CreditService.CreditWebService();
            BankAccountDetails user = service.CreateEmptyBankAccount("AMIT NAVE", 1383955);
            service.AddNewMastercardCard(user);
            service.AddNewVisaCard(user);

            BankAccountDetails updatedUser = service.GetBankAccount(user.identificationNumber);
            Assert.Equals(updatedUser.CreditCards.Length, 2);


        }
    }
}
