using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{

    public   class LoggedInAirlineFacade :AnonymousUserFacade,ILoggedInAirlineFacade, IFacede
    {
        private new IAdministratorDAO _administratorDAO = new AdministratorDAOMSSQL();
        private new IAirlineDAO _airlineDAO = new AirlineDAOMSSQL();
        private new ICustomerDAO _customerDAO = new CustomerDAOMSSQL();
        private new ICountryDAO _countryDAO = new CountryDAOMSSQL();
        private new ITicketDAO _ticketDAO = new TicketDAOMSSQL();
        private new IFlightDAO _flightDAO = new FlightDAOMSSQL();

        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flihgt)
        {
           if(UserIsValid(token) && token.User.ID == flihgt.AirlineCompany_Id)
           {
                _flightDAO.Remove(flihgt);
           }
        }

        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            if(UserIsValid(token))
            {
                if(token.User.Password == oldPassword)
                {
                    token.User.Password = newPassword;
                    _airlineDAO = new AirlineDAOMSSQL();
                    _airlineDAO.Update(token.User);
                }
                else
                {
                    throw new WrongPasswordException("Your Password Old, Please write new Password");
                }
            }
        }

        public long CreateFlight(LoginToken<AirlineCompany> token, Flight flihgt)
        {

           long newId = 0;
           if(UserIsValid(token) && token.User.ID == flihgt.AirlineCompany_Id)
           {
              newId =  _flightDAO.Add(flihgt);
           }
            return newId;
        }

        public IList<Flight> GetAllFlightsByAirline(LoginToken<AirlineCompany> token)
        {
            List<Flight> flights = new List<Flight>();
            if(UserIsValid(token))
            {
                flights = _flightDAO.GetFlightsByAirlineCompany(token.User).ToList();
            }
            return flights;
        }
        public IList<Ticket> GetAllTicketsByAirline(LoginToken<AirlineCompany> token)
        {
            IList<Ticket> tickets = new List<Ticket>();
           
            if(token != null)
            {
                return _ticketDAO.GetAll();
            }
            return tickets;
           
        }

       
        public void ModifyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airlineCompany)
        {
            if(UserIsValid(token) && token.User.ID == airlineCompany.ID)
            {
                _airlineDAO.Update(airlineCompany);
            }
        }

        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (UserIsValid(token) && token.User.ID == flight.AirlineCompany_Id)
            {
                _flightDAO.Update(flight);
            }
        }
        public Flight GetFlightById(LoginToken<AirlineCompany> token, long flightId)
        {
            if (token != null)
            {
                return _flightDAO.Get(flightId);
            }
            else
                throw new Exception("Token can't be null");
            
        }
        public Customer GetCustomerByUserName(LoginToken<AirlineCompany> token,string customerUserName)
        {
            if (token != null)
            {
                return _customerDAO.GetCustomerByUserName(customerUserName);
            }
            else
                throw new Exception("Token can't be null");

        }

      
        public bool UserIsValid(LoginToken<AirlineCompany> token)
        {
            if (token != null && token.User != null)
                return true;
            return false;
        }

      
    }
}
