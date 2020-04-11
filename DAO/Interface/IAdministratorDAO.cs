using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
  public interface IAdministratorDAO : IBasicDB<Administrator>
  {
        Administrator GetByUserName(string userName);
        AirlineCompany GetAirlineByUserName(string username);
        IList<AirlineCompany> GetAllAirlineByCountry(int countryId);
        IList<AirlineCompany> GetAirlineCompanies();
        Customer GetCustomerByUserName(string userName);
        IList<Customer> GetAllCustomers();
        
  }
}
