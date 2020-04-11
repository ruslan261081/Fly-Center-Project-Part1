using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
   public class CountryDAOMSSQL : ICountryDAO
   {
        public long Add(Country t)
        {

            long newId = 0;
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("ADD_NEW_COUNTRY", connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@COUNTRY_NAME", t.CountryName));
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                   
                    cmd.Connection.Close();

                }
            }
            return newId;
           
           
        }

        public Country Get(long id)
        {
            Country country = new Country();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_COUNTRY_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while(reader.Read() == true)
                {
                    country.Id = (long)reader["ID"];
                    country.CountryName = (string)reader["COUNTRY_NAME"];
                }
                cmd.Connection.Close();
                return country;
                
     
            }
        }

        public IList<Country> GetAll()
        {
            List<Country> List = new List<Country>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_COUNTRIES", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while(reader.Read() == true)
                {
                    Country country = new Country();
                    country.Id = (long)reader["ID"];
                    country.CountryName = (string)reader["COUNTRY_NAME"];
                    List.Add(country);
                }
                cmd.Connection.Close();
                return List;
            }

        }

       

        public void Remove(Country t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.Id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();

            }
        }

        public void Update(Country t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_COUNTRY", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.Id));
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_NAME", t.CountryName));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();
            }
        }
   }
}
