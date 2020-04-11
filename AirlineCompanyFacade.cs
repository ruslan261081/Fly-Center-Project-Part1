using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyCenterProject;

namespace FlyCenterTest
{
    [TestClass]
    public class AirlineCompanyFacade
    {
           public ILoggedInCustomerFacade GetCustomerFacade(out LoginToken<Customer> tCustomer)
           {
                FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();
                ILoginToken loginToken = flyingCenterSystem.Login(TestResource.AirlineFacade_Customer1_USER_NAME, TestResource.AirlineFacade_Customer1_PASSWORD);
                tCustomer = loginToken as LoginToken<Customer>;
                ILoggedInCustomerFacade customerFacade = flyingCenterSystem.GetFacede(loginToken) as ILoggedInCustomerFacade;
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
            Country newcountry1 = new Country()
            {
                CountryName = TestResource.AdministratorFacade_AddCountry_COUNTRY_NAME1

            };
            return newcountry1;
        }
        public Country AddNewCountry2()
        {
            Country newcountry2 = new Country()
            {
                CountryName = TestResource.AdministratorFacade_AddCountry_COUNTRY_NAME2

            };
            return newcountry2;
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
                Password = TestResource.CustomerFacade_AirlineCompany2_PASSWORD,

            };
            return airlineCompany2;

        }
        public Flight AddNewFlight()
        {
            Flight flight = new Flight
            {
                Departure_Time = TestResource.AirlineCompanyFacade_AddNewFlight_DEPARTURE_TIME,
                Landing_Time = TestResource.AirlineCompanyFacade_AddNewFlight_LANDING_TIME,
                Remaining_Tickets = TestResource.AirlineCompanyFacade_AddNewFlight_REMAINING_TICKETS

            };
            return flight;
        }
        public Customer AddNewCustomer()
        {
            Customer customer = new Customer()
            {
                FirstName = TestResource.AirlineFacade_Customer1_FIRST_NAME,
                LastName = TestResource.AirlineFacade_Customer1_LAST_NAME,
                UserName = TestResource.AirlineFacade_Customer1_USER_NAME,
                Address = TestResource.AirlineFacade_Customer1_ADDRESS,
                Password = TestResource.AirlineFacade_Customer1_PASSWORD,
                PhoneNo = TestResource.AirlineFacade_Customer1_PHONE_NO,
                CreditCardNumber = TestResource.AirlineFacade_Customer1_CREDIT_CARD_NUMBER

            };
            return customer;
        }
        public AirlineCompany AddNewAirlineCompany()
        {
            AirlineCompany airlineCompany = new AirlineCompany()
            {
                AirlineName = TestResource.AirlineCompanyFacade_AIRLINE_NAME,
                UserName = TestResource.AirlineCompanyfacade_USER_NAME,
                Password = TestResource.AirlineCompanyFacade_PASSWORD


            };
            return airlineCompany;
        }
        public Ticket AddNewTicket()
        {
            Ticket ticket = new Ticket();
            return ticket;
        }
        public Country AdministratorFacade_AddNewCountry1()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country newcountry1 = AddNewCountry2();
            long countryCode1 = administratorFacade.CreateNewCountry(t, newcountry1);
            newcountry1.Id = countryCode1;
            return newcountry1;

        }
        public Country AdministratorFacade_AddNewCountry2()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country newcountry2 = AddNewCountry2();
            long countryCode2 = administratorFacade.CreateNewCountry(t, newcountry2);
            newcountry2.Id = countryCode2;
            return newcountry2;

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
        public void AirlineCompanyWrongPassword()
        {
            FlyingCenterSystem flyingCenterSystem = FlyingCenterSystem.GetInstance();
            ILoginToken loginToken = flyingCenterSystem.Login(TestResource.AirlineCompanyfacade_USER_NAME, TestResource.AirlineCompanyFacade_AirlineCompanyWrongPassword_PASSWORD);
        }
    }
}
