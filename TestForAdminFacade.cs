using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyCenterProject;
using System.Collections.Generic;
using System.IO;
using System;

namespace FlyCenterTest
{
    [TestClass]
    public class TestForAdminFacade
    {
        Country newCountry1 = null;
        Country newCountry2 = null;
        AirlineCompany newAirlineCompany = null;
        Customer newCustomer = null;
      
          [TestMethod]
          public ILoggedInAdministratorFacade GetAdministratorFacade(out LoginToken<Administrator>t)
          {
                FlyingCenterSystem flying = FlyingCenterSystem.GetInstance();
                ILoginToken loginToken = flying.Login(TestResource.Administrator_USER_NAME, TestResource.Administrator_PASSWORD);
                t = loginToken as LoginToken<Administrator>;
                ILoggedInAdministratorFacade administratorFacade = flying.GetFacede(loginToken) as ILoggedInAdministratorFacade;
                return administratorFacade;

          }
        public Customer AddNewCustomer()
        {
            Customer newCustomer = new Customer
            {
                FirstName = TestResource.AdministratorFacade_AddCustomer_FIRST_NAME,
                LastName = TestResource.AdministratorFacade_AddCustomer_LAST_NAME,
                UserName = TestResource.AdministratorFacade_AddCustomer_USER_NAME,
                Password = TestResource.AdministratorFacade_AddCustomer_PASSWORD,
                Address = TestResource.AdministratorFacade_AddCustomer_ADDRESS,
                PhoneNo = TestResource.AdministratorFacade_AddCustomer_PHONE_NO,
                CreditCardNumber = TestResource.AdministratorFacade_AddCustomer_CREDIT_CARD_NUMBER

            };
            return newCustomer;
        }
        public AirlineCompany AddNewAirlineCompany()
        {
            AirlineCompany newAirlineCompany = new AirlineCompany()
            {
                AirlineName = TestResource.AdministratorFacade_AddAirlineCompany1_AIRLINE_NAME,
                UserName = TestResource.AdministratorFacade_AddAirlineCompany1_User_NAME,
                Password = TestResource.AdministratorFacade_AddAirlineCompany1_PASSWORD

            };
            return newAirlineCompany;
        }

        [TestMethod]
        public void TestFlyingCenterSystem()
        {
           // FlightCenterConfig.CleanAllDatabase();
            FlyingCenterSystem flyingCenter = FlyingCenterSystem.GetInstance();
        }
        [TestMethod]
        public void FacadeTest()
        {
           // FlightCenterConfig.CleanAllDatabase();
            FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();
            LoggedInAdministratorFacade loggedIn = new LoggedInAdministratorFacade();
            LoggedInAdministratorFacade loggedIn2 = new LoggedInAdministratorFacade();
             
            try
            {
                Assert.AreEqual(loggedIn, loggedIn2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
       


    }
    
}
