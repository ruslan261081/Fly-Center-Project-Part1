using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
    public abstract class FacadeBase
    {

        protected IAirlineDAO _airlineDAO;

        protected ICountryDAO _countryDAO;

        protected ICustomerDAO _customerDAO;

        protected IFlightDAO _flightDAO;

        protected ITicketDAO _ticketDAO;

        protected IAdministratorDAO _administratorDAO;


    }
   

    
}
