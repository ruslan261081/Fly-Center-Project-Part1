using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyCenterProject;

namespace FlyCenterTest
{
    [TestClass]
    public class AnonymousFacade
    {
        public AnonymousUserFacade GetAnonymousFacade()
        {
            FlyingCenterSystem flyingCenter = FlyingCenterSystem.GetInstance();
            AnonymousUserFacade anonymousUserFacade = flyingCenter.GetFacede(null) as AnonymousUserFacade;
            return anonymousUserFacade;

        }
        public ILoggedInCustomerFacade GetCustomerFacade(out LoginToken<Customer> tCustomer)
        {
            FlyingCenterSystem flyingCenter = FlyingCenterSystem.GetInstance();
            ILoginToken loginToken = flyingCenter.Login(TestResource.AirlineFacade_Customer1_USER_NAME, TestResource.AirlineFacade_Customer1_PASSWORD);
            tCustomer = loginToken as LoginToken<Customer>;
            ILoggedInCustomerFacade customerFacade = flyingCenter.GetFacede(loginToken) as ILoggedInCustomerFacade;
            return customerFacade;
        }
        public ILoggedInAdministratorFacade GetAdministratorFacade(out LoginToken<Administrator> tAdministrator)
        {
            FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();
            ILoginToken loginToken = flyingCenterSystem.Login(TestResource.Administrator_USER_NAME, TestResource.Administrator_PASSWORD);
            tAdministrator = loginToken as LoginToken<Administrator>;
            ILoggedInAdministratorFacade administratorFacade = flyingCenterSystem.GetFacede(loginToken) as ILoggedInAdministratorFacade;
            return administratorFacade;
        }
        public Country AddNewCountry1()
        {
            Country newCountry1 = new Country()
            {
                CountryName = TestResource.AdministratorFacade_AddCountry_COUNTRY_NAME1
            };
            return newCountry1;
        }
        public Country AddNewCountry2()
        {
            Country newCountry2 = new Country()
            {
                CountryName = TestResource.AdministratorFacade_AddCountry_COUNTRY_NAME2
            };
            return newCountry2;
        }
        public Customer AddNewCustomer()
        {
            Customer newCustomer = new Customer()
            {
                FirstName = TestResource.AnonymousFacade_Customer_FIRST_NAME,
                LastName = TestResource.AnonymousFacade_Customer_LAST_NAME,
                UserName = TestResource.AnonymousFacade_Customer_USER_NAME,
                Address = TestResource.AnonymousFacade_Customer_ADDRESS,
                Password = TestResource.AnonymousFacade_Customer_PASSWORD,
                PhoneNo = TestResource.AnonymousFacade_Customer_PHONE_NO,
                CreditCardNumber = TestResource.AnonymousFacade_Customer_CREDIT_CARD_NUMBER

            };
            return newCustomer;
        }
        public Flight AddNewFlight()
        {
            Flight newFlight = new Flight
            {
                Departure_Time = TestResource.AnonymousFacade_DEPARTURE_TIME,
                Landing_Time = TestResource.AnonymousFacade_LANDING_TIME,
                Remaining_Tickets = TestResource.AnonymousFacade_REMAINING_TICKETS

            };
            return newFlight;
        }
        public AirlineCompany AddNewAirlineCompany1()
        {
            AirlineCompany newAirlineCompany1 = new AirlineCompany()
            {
                AirlineName = TestResource.AnonymousFacade_AirlineCompany1_AIRLINE_NAME,
                UserName = TestResource.AnonymousFacade_AirlineCompany1_User_NAME,
                Password = TestResource.AnonumousFacade_AirlineCompany1_PASSWORD,


            };
            return newAirlineCompany1;
        }
        public AirlineCompany AddNewAirlineCompany2()
        {
            AirlineCompany newAirlineCompany2 = new AirlineCompany()
            {
                AirlineName = TestResource.AnonymousFacade_AirlineCompany2_AIRLINE_NAME,
                UserName = TestResource.AnonymousFacade_AirlineCompany2_USER_NAME,
                Password = TestResource.AnonymousFacade_AirlineCompany2_PASSWORD


            };
            return newAirlineCompany2;
        }
        public Country AdministratorFacade_AddNewCountry1()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country newCountry1 = AddNewCountry1();
            long countryCode1 = administratorFacade.CreateNewCountry(t, newCountry1);
            newCountry1.Id = countryCode1;
            return newCountry1;
        }
        public Country AdministratorFacade_AddNewCountry2()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country newCountry2 = AddNewCountry2();
            long countryCode2 = administratorFacade.CreateNewCountry(t, newCountry2);
            newCountry2.Id = countryCode2;
            return newCountry2;
        }
        public Customer AdministratorFacade_AddNewCustomer()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Customer newCustomer = AddNewCustomer();
            long ID = administratorFacade.CreateNewCustomer(t, newCustomer);
            newCustomer.Id = ID;
            return newCustomer;

        }
        public AirlineCompany AdministratorFacade_AddNewArline1()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country1 = AdministratorFacade_AddNewCountry1();
            AirlineCompany newAirlineCompany = AddNewAirlineCompany1();
            newAirlineCompany.CountryCode = country1.Id;
            long ID = administratorFacade.CreateNewAirline(t, newAirlineCompany);
            newAirlineCompany.ID = ID;
            return newAirlineCompany;
        }
        public AirlineCompany AdministratorFacade_AddNewAirline2()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country2 = AdministratorFacade_AddNewCountry2();
            AirlineCompany newAirlineCompany = AddNewAirlineCompany2();
            newAirlineCompany.CountryCode = country2.Id;
            long ID = administratorFacade.CreateNewAirline(t, newAirlineCompany);
            newAirlineCompany.ID = ID;
            return newAirlineCompany;
        }


        [TestMethod]
        public void AnonymousWrongPassword()
        {
            FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();
            ILoginToken loginToken = flyingCenterSystem.Login(TestResource.AnonymousFacade_Anonymous_USER_NAME,TestResource.AnonymousFacade_AnonymousWrongPASSWORD);
        }
    
    }
}
