using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
   public class LoginService : ILoginService
   {
        private IAirlineDAO _airlineDAO;
        private ICustomerDAO _customerDAO;
        private IAdministratorDAO _administratorDAO;

        public LoginService()
        {
            _airlineDAO = new AirlineDAOMSSQL();
            _customerDAO = new CustomerDAOMSSQL();
            _administratorDAO = new AdministratorDAOMSSQL();
        }
      
        public bool TryAdminLogin(string username, string passsword, out LoginToken<Administrator> token)
        { 
            token = null;

            if(username.ToUpper() == FlightCenterConfig.ADMIN_NAME)
            {
                if(passsword == FlightCenterConfig.ADMIN_PASSWORD)
                {
                    token = new LoginToken<Administrator> { User = new Administrator { Id = 0, UserName = FlightCenterConfig.ADMIN_NAME, Password = FlightCenterConfig.ADMIN_PASSWORD } };
                    return true;
                }
                else
                {
                    throw new WrongPasswordException("Your Password Not Mismatch To Your UserName!");
                }
                
            }
            return false;
           
        }

        public bool TryAirlineLogin(string username, string password, out LoginToken<AirlineCompany> token)
        {
            _airlineDAO = new AirlineDAOMSSQL();
            AirlineCompany company = _airlineDAO.GetAirLineByUserName(username);
            if(company != null)
            {
                if(company.Password == password)
                {
                    token = new LoginToken<AirlineCompany>() { User = company };
                    return true;
                }
            }
            else
            {
                try
                {
                    if(company == null)
                    {
                        token = null;
                        return false;
                    }
                    
                }
                catch(WrongPasswordException )
                {
                    token = new LoginToken<AirlineCompany>() { User = company };
                    return false;
                    throw new WrongPasswordException("Your Password is not correct, Try again");
                }
            }
            token = null;
          
            return false;
        }

        public bool TryCustomerLogin(string username, string password, out LoginToken<Customer> token)
        {
            token = null;
            Customer customer = _customerDAO.GetCustomerByUserName(username);
            if(customer != null)
            {
                if(customer.Password.ToUpper() == password.ToUpper())
                {
                    token = new LoginToken<Customer>() { User = customer };
                    return true;

                }
            }
            else
            {
                try
                {
                    if(username == null)
                    {
                        token = null;
                        return false;
                    }
                    
                }
                catch(UserNotFoundException )
                {
                    token = new LoginToken<Customer>() { User = customer };
                    return false;
                    throw new UserNotFoundException("Sorry but your username not found");
                }
              
            }
           
            return false;
        }
   }
}
