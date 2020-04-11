using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
   public class AirlineDAOMSSQL : IAirlineDAO
   {
        public long Add(AirlineCompany t)
        {
            long newId = 0;
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("ADD_NEW_AIRLINECOMPANY", connection))
                {
                    connection.Open();
                    cmd.Parameters.Add(new SqlParameter("@AIRLINE_NAME", t.AirlineName));
                    cmd.Parameters.Add(new SqlParameter("@USER_NAME", t.UserName));
                    cmd.Parameters.Add(new SqlParameter("@PASSWORD", t.Password));
                    cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", t.CountryCode));
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                }
            }
            return newId;
        }

        public AirlineCompany Get(long id)
        {
            AirlineCompany airline = new AirlineCompany();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIRLINE_COMPANY_BY_ID", connection);
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("@ID", id));

               
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
                while(reader.Read() == true)
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

      

        public AirlineCompany GetAirLineByUserName(string username)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                AirlineCompany airline = new AirlineCompany();
                SqlCommand cmd = new SqlCommand("GET_AIRLINE_BY_USER_NAME", connection);

                connection.Open();
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", username));

              
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

                while(reader.Read() == true)
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

        public IList<AirlineCompany> GetAll()
        {
            List<AirlineCompany> AllAirlineCompany = new List<AirlineCompany>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_AIRLINECOMPANY", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

                while(reader.Read() == true)
                {
                    AllAirlineCompany.Add(new AirlineCompany
                    {
                        ID = (long)reader["Id"],
                        AirlineName = (string)reader["AIRLINE_NAME"],
                         UserName  = (string)reader["USER_NAME"],
                         Password = (string)reader["Password"],
                         CountryCode = (long)reader["COUNTRY_CODE"],
                    });

                }
                cmd.Connection.Close();
                return AllAirlineCompany;
            }
            
        }

      

        public IList<Ticket> GetAllAirLineCompanyTickets(int airlineCompanyID)
        {
            List<Ticket> list = new List<Ticket>();

            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_AIRLINE_COMPANY_TICKETS", conn);
                cmd.Parameters.Add(new SqlParameter("@ID", airlineCompanyID));
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
                while(reader.Read() == true)
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = (long)reader["ID"];
                    ticket.FlightID = (long)reader["FLIGHT_ID"];
                    ticket.CustomerID = (long)reader["CUSTOMER_ID"];
                    list.Add(ticket);
                }
                cmd.Connection.Close();
                return list;
            }
        }

        public List<Ticket> GetAllAirlineCompanyTickets(int country_code)
        {
            throw new NotImplementedException();
        }

        public IList<AirlineCompany> GetAllAirlinesByCountry(int countryId)
        {
            List<AirlineCompany> List = new List<AirlineCompany>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_AIRLINE_BY_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", countryId));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
                while(reader.Read() == true)
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

        public void Remove(AirlineCompany t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_AIRLINE_COMPANY", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.AirlineName));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
                cmd.Connection.Close();


            }
        }

        public void Update(AirlineCompany t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_AIRLINE_COMPANY", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.ID));
                cmd.Parameters.Add(new SqlParameter("@AIRLINE_NAME", t.AirlineName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", t.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWOED", t.Password));
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", t.CountryCode));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
                cmd.Connection.Close();


            }
        }
   }
}
