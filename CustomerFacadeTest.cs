using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyCenterProject;

namespace FlyCenterTest
{
    [TestClass]
    public class CustomerFacadeTest
    {
        public ILoggedInAdministratorFacade GetAirlineCompanyFacade { get; private set; }

        public ILoggedInCustomerFacade GetCustomerFacade(out LoginToken<Customer> tCustomer)
        {
            FlyingCenterSystem flyingCenter = FlyingCenterSystem.GetInstance();
            ILoginToken loginToken = flyingCenter.Login(TestResource.CustomerFacade_Customer_USER_NAME, TestResource.CustomerFacade_Customer_PASSWORD);
            tCustomer = loginToken as LoginToken<Customer>;
            ILoggedInCustomerFacade customerFacade = flyingCenter.GetFacede(loginToken) as ILoggedInCustomerFacade;
            return customerFacade;
        }
        public ILoggedInAdministratorFacade GetAdministratorFacade(out LoginToken<Administrator> tAdministrator)
        {
            FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();
            ILoginToken loginToken = flyingCenterSystem.Login(TestResource.Administrator_UpdateCustomer_USER_NAME, TestResource.Administrator_PASSWORD);
            tAdministrator = loginToken as LoginToken<Administrator>;
            ILoggedInAdministratorFacade administratorFacade = flyingCenterSystem.GetFacede(loginToken) as ILoggedInAdministratorFacade;
            return administratorFacade;
        }
        public Country AddNewCountry1()
        {
            Country country1 = new Country()
            {
                CountryName = TestResource.AdministratorFacade_AddCountry_COUNTRY_NAME1

            };
            return country1;
        }
        public Country AddNewCountry2()
        {
            Country country2 = new Country()
            {
                CountryName = TestResource.AdministratorFacade_AddCountry_COUNTRY_NAME2
            };
            return country2;
        }
        public AirlineCompany AddNewAirlineCompany1()
        {
            AirlineCompany airlineCompany1 = new AirlineCompany()
            {
                AirlineName = TestResource.CustomerFacade_AirlineCompany1_AIRLINE_NAME,
                UserName = TestResource.CustomerFacade_AirlineCompany1_User_NAME,
                Password = TestResource.CustomerFacade_AirlineCompany1_PASSWORD,
            };
            return airlineCompany1;

        }
        public AirlineCompany AddNewAirlineCompany2()
        {
            AirlineCompany airlineCompany2 = new AirlineCompany()
            {
                AirlineName = TestResource.CustomerFacade_AirlineCompany2_AIRLINE_NAME,
                UserName = TestResource.CustomerFacade_AirlineCompany2_USER_NAME,
                Password = TestResource.CustomerFacade_AirlineCompany2_PASSWORD

            };
            return airlineCompany2;
        }
        public Customer AddNewCustomer()
        {
            Customer newCustomer = new Customer
            {
                FirstName = TestResource.CustomerFacade_Customer_FIRST_NAME,
                LastName = TestResource.CustomerFacade_Customer_LAST_NAME,
                UserName = TestResource.CustomerFacade_Customer_USER_NAME,
                Address = TestResource.CustomerFacade_Customer_ADDRESS,
                Password = TestResource.CustomerFacade_Customer_PASSWORD,
                PhoneNo = TestResource.CustomerFacade_Customer_PHONE_NO,
                CreditCardNumber = TestResource.CustomerFacade_Customer_CREDIT_CARD_NUMBER

            };
            return newCustomer;
        }
        public Flight AddNewFlight()
        {
            Flight newFlight = new Flight
            {
                Departure_Time = TestResource.CustomerFacade_AddFlight_DEPARTURE_TIME,
                Landing_Time = TestResource.CustomerFacade_AddFlight_LANDING_TIME,
                Remaining_Tickets = TestResource.CustomerFacade_AddFlight_REMAINING_TICKETS

            };
            return newFlight;
        }
        public Country AdministatorFacade_AddNewCountry1()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country1 = AddNewCountry1();
            long countryCode1 = administratorFacade.CreateNewCountry(t, country1);
            country1.Id = countryCode1;
            return country1;
        }
        public Country AdministaratorFacade_AddNewCountry2()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country2 = AddNewCountry1();
            long countryCode2 = administratorFacade.CreateNewCountry(t, country2);
            country2.Id = countryCode2;
            return country2;
        }
        public Customer AdministratorFacade_AddNewCustomer()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Customer customer = AddNewCustomer();
            long ID = administratorFacade.CreateNewCustomer(t, customer);
            customer.Id = ID;
            return customer;
        }
        public AirlineCompany AdministratorFacade_AddNewAirline1()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country1 = AdministatorFacade_AddNewCountry1();
            AirlineCompany airlineCompany = AddNewAirlineCompany1();
            airlineCompany.CountryCode = country1.Id;
            long ID = administratorFacade.CreateNewAirline(t, airlineCompany);
            airlineCompany.ID = ID;
            return airlineCompany;
        }
        public AirlineCompany AdministratorFacade_AddNewairline2()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country2 = AdministaratorFacade_AddNewCountry2();
            AirlineCompany airlineCompany = AddNewAirlineCompany2();
            airlineCompany.CountryCode = country2.Id;
            long ID = administratorFacade.CreateNewAirline(t, airlineCompany);
            airlineCompany.ID = ID;
            return airlineCompany;
        }
       
        [TestMethod]
        public void CustomerWrongPassword()
        {
            FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();
            ILoginToken loginToken = flyingCenterSystem.Login(TestResource.CustomerFacade_Customer_USER_NAME, TestResource.CustomerFacade_CustomerWrongPassword_Password);
        }
    }
}
