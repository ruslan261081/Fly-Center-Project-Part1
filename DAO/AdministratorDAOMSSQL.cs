using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
  public  class AdministratorDAOMSSQL : IAdministratorDAO
  {
        public long Add(Administrator t)
        {
            long newId = 0;
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("ADD_ADMINISTRATOR", connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@ID", t.Id));
                    cmd.Parameters.Add(new SqlParameter("@USER_NAME", t.UserName));
                    cmd.Parameters.Add(new SqlParameter("@PASSWORD", t.Password));
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    cmd.Connection.Close();
                }
            }
            return newId;
        }

        public Administrator Get(long id)
        {
            Administrator administrator = new Administrator();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ADMINISTRATOR_AIRLINE_COMPANY_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    administrator.Id = (long)reader["ID"];
                  
                }
                cmd.Connection.Close();
                return administrator;
            }
        }

        public AirlineCompany GetAirlineByUserName(string username)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                AirlineCompany airline = new AirlineCompany();
                SqlCommand cmd = new SqlCommand("GET_AIR_LINE_BY_USER_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", username));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    airline.ID = (long)reader["ID"];
                    airline.AirlineName = (string)reader["AIRLINE_NAME"];
                    airline.UserName = (string)reader["USER_NAME"];
                    airline.Password = (string)reader["PASSWORD"];
                    airline.CountryCode = (long)reader["COUNTRY_CODE"];
                }
                cmd.Connection.Close();
                return airline;

            }
        }

        public IList<AirlineCompany> GetAirlineCompanies()
        {
            List<AirlineCompany> List = new List<AirlineCompany>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIRLINE_COMPANY", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    AirlineCompany airline = new AirlineCompany();
                    airline.ID = (long)reader["ID"];
                    airline.AirlineName = (string)reader["AIRLINE_NAME"];
                    airline.UserName = (string)reader["USER_NAME"];
                    airline.Password = (string)reader["PASSWORD"];
                    airline.CountryCode = (long)reader["COUNTRY_CODE"];

                    List.Add(airline);
                }
                cmd.Connection.Close();
                return List;
            }
        }

        public IList<Administrator> GetAll()
        {
            List<Administrator> List = new List<Administrator>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIR_LINE_BY_ADMINISTRATOR", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    Administrator administrator = new Administrator();
                    administrator.Id = (long)reader["ID"];
                    administrator.Password = (string)reader["PASSWORD"];
                    administrator.UserName = (string)reader["USER_NAME"];
                   

                    List.Add(administrator);
                }
                cmd.Connection.Close();
                return List;
            }

        }

        public IList<AirlineCompany> GetAllAirlineByCountry(int countryId)
        {
            List<AirlineCompany> List = new List<AirlineCompany>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIRLINE_BY_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", countryId));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    AirlineCompany airline = new AirlineCompany();
                    airline.ID = (long)reader["ID"];
                    airline.AirlineName = (string)reader["AIRLINE_NAME"];
                    airline.UserName = (string)reader["USER_NAME"];
                    airline.Password = (string)reader["PASSWORD"];
                    airline.CountryCode = (long)reader["COUNTRY_CODE"];

                    List.Add(airline);
                }
                cmd.Connection.Close();
                return List;
            }
        }
        public IList<Customer> GetAllCustomers()
        {
            List<Customer> List = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_CUSTOMER", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Customer t = new Customer();
                    t.Id = (long)reader["ID"];
                    t.FirstName = (string)reader["FIRST_NAME"];
                    t.LastName = (string)reader["LAST_NAME"];
                    t.UserName = (string)reader["USER_NAME"];
                    t.Password = (string)reader["PASSWORD"];
                    t.Address = (string)reader["ADDRESS"];
                    t.PhoneNo = (string)reader["PHONO_NO"];
                    t.CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"];


                }
                cmd.Connection.Close();
                return List;

            }
        }

        public Administrator GetByUserName(string userName)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                Administrator administrator = new Administrator();
                SqlCommand cmd = new SqlCommand("GET_AIR_LINE_BY_USER_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", userName));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    administrator.Id = (long)reader["ID"];
                    administrator.UserName = (string)reader["USER_NAME"];
                    administrator.Password = (string)reader["PASSWORD"];
                   
                }
                cmd.Connection.Close();
                return administrator;

            }
        }

        public Customer GetCustomerByUserName(string userName)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                Customer customer = new Customer();
                SqlCommand cmd = new SqlCommand("GET_CUSTOMER_BY_USER_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", userName));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    customer.Id = (long)reader["ID"];
                    customer.UserName = (string)reader["USER_NAME"];
                    customer.Password = (string)reader["PASSWORD"];

                }
                cmd.Connection.Close();
                return customer;

            }
        }

        public void Remove(Administrator t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_AIRLINE_BY_ADMINISTRATOR", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.Id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();


            }
        }

        public void Update(Administrator t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_AIRLINE_BY_ADMINISTRATOR", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.Id));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", t.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", t.Password));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();


            }
        }
  }
}
