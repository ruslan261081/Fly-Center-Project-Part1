using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
   public class AnonymousUserFacade :FacadeBase, IAnonymousUserFacade,IFacede
   {
        private new IAdministratorDAO _administratorDAO = new AdministratorDAOMSSQL();
        private new IAirlineDAO _airlineDAO = new AirlineDAOMSSQL();
        private new ICustomerDAO _customerDAO = new CustomerDAOMSSQL();
        private new ICountryDAO _countryDAO = new CountryDAOMSSQL();
        private new ITicketDAO _ticketDAO = new TicketDAOMSSQL();
        private new IFlightDAO _flightDAO = new FlightDAOMSSQL();



        

      

        public IList<AirlineCompany> GetAllAirlineCompanies()
        {
            return _airlineDAO.GetAll();
        }

        public IList<Flight> GetAllFlights()
        {
            return _flightDAO.GetAll();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            return _flightDAO.GetAllFlightsVacancy();
        }

        public Flight GetFlightById(long id)
        {
            return _flightDAO.Get(id);
        }

        public IList<Flight> GetFlightsByDepatruteDate(DateTime departureDate)
        {
            return _flightDAO.GetFlightsByDepartureDate(departureDate);
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByDestinationCountry(countryCode);
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            return _flightDAO.GetFlightsByLandingDate(landingDate);
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByOriginCountry(countryCode);
        }

        public IList<Flight> DepartureForNext12H()
        {
            return _flightDAO.GetDepartureFlightsNext12H();
        }

        public IList<Flight> LandingNext12hAndLast4H()
        {
            return _flightDAO.GetLandingFlightsNext12hAndLast4H();
        }

        public IList<Flight> SearchByParams()
        {
            throw new NotImplementedException();
        }
    }
}
