using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
    public interface IAirlineDAO : IBasicDB<AirlineCompany>
    {
        AirlineCompany GetAirLineByUserName(string username);
        IList<Ticket> GetAllAirLineCompanyTickets(int airlineCompanyID);
        
        IList<AirlineCompany> GetAllAirlinesByCountry(int countryId);
    }
}
