using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
   public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade,IFacede
   {
        private new IAdministratorDAO _administratorDAO = new AdministratorDAOMSSQL();
        private new IAirlineDAO _airlineDAO = new AirlineDAOMSSQL();
        private new ICustomerDAO _customerDAO = new CustomerDAOMSSQL();
        private new ICountryDAO _countryDAO = new CountryDAOMSSQL();
        private new ITicketDAO _ticketDAO = new TicketDAOMSSQL();
        private new IFlightDAO _flightDAO = new FlightDAOMSSQL();

        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (UserIsValid(token) && token.User.Id == ticket.CustomerID)
            {
                _ticketDAO.Remove(ticket);
            }
        }

      
        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            IList<Flight> flightsByCustomer = null;
            if(UserIsValid(token))
            {
                flightsByCustomer = _flightDAO.GetFlightsByCustomer(token.User);
            }
            return flightsByCustomer;
        }
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {



            if (flight.Remaining_Tickets > 0)
            {
                Ticket ticket = new Ticket(flight.ID, token.User.Id);
                if (token != null && token.User != null)
                {
                    try
                    {
                        ticket.ID = _ticketDAO.Add(new Ticket { CustomerID = token.User.Id, FlightID = flight.ID });
                        flight.Remaining_Tickets--;
                        _flightDAO.Update(flight);

                    }
                    catch(Exception e)
                    {
                        throw new UserAlreadyExistException($"{token.User.FirstName} {token.User.LastName} already has ticket from this flight");
                    }
                    return ticket;
                }

            }
            throw new TicketsIsOver("Sorry To try One's Luck Next Time");

        }
        public bool UserIsValid(LoginToken<Customer> token)
        {
            if (token != null && token.User != null)
                return true;
            return false;
        }
    }
}
