using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
    public class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade, IFacede
    {
        private new IAdministratorDAO _administratorDAO = new AdministratorDAOMSSQL();
        private new IAirlineDAO _airlineDAO = new AirlineDAOMSSQL();
        private new ICustomerDAO _customerDAO = new CustomerDAOMSSQL();
        private new ICountryDAO _countryDAO = new CountryDAOMSSQL();
        private new ITicketDAO _ticketDAO = new TicketDAOMSSQL();
        private new IFlightDAO _flightDAO = new FlightDAOMSSQL();

        public long CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            long newId = 0;
            if (UserIsValid(token))
            {
                newId = _airlineDAO.Add(airline);
            }
            return newId;
        }

        public long CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            long newId = 0;
            if (UserIsValid(token))
            {
                newId = _customerDAO.Add(customer);
            }
            return newId;
        }
        public long CreateNewCountry(LoginToken<Administrator> token, Country country)
        {
            long newId = 0;
            if (UserIsValid(token))
            {
                newId = _countryDAO.Add(country);
            }
            return newId;

        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (UserIsValid(token))
            {
                _airlineDAO.Remove(airline);
            }
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (UserIsValid(token))
            {
                _customerDAO.Remove(customer);
            }
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (UserIsValid(token))
            {
                _airlineDAO.Update(airline);
            }
        }

        public void UpdateCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (UserIsValid(token))
            {
                _customerDAO.Update(customer);
            }
        }

        public IList<Customer> GetAllCustomer()
        {
            
                return _customerDAO.GetAll();
            
        }

        public bool UserIsValid(LoginToken<Administrator> token)
        {
            if (token != null && token.User != null)
                return true;
            return false;
        }
    }
}
