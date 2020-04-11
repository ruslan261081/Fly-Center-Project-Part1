using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
  public class TicketDAOMSSQL : ITicketDAO
  {
        public long Add(Ticket t)
        {
            long newId = 0;
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("ADD_TICKET", connection);
                cmd.Parameters.Add(new SqlParameter("@FLIGHT_ID", t.FlightID)); 
                cmd.Parameters.Add(new SqlParameter("@CUSTOMER_ID", t.CustomerID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            return newId;
            
        }

        public Ticket Get(long id)
        {
            Ticket t = new Ticket();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_TICKET BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()== true)
                {
                    t.ID = (long)reader["ID"];
                    t.FlightID = (long)reader["FLIGHT_ID"];
                    t.CustomerID = (long)reader["CUSTOMER_ID"];
                }
                cmd.Connection.Close();
                return t;

            }
        }

        public IList<Ticket> GetAll()
        {
            List<Ticket> List = new List<Ticket>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_TICKET", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()==  true)
                {
                    Ticket t = new Ticket();
                    t.ID = (long)reader["ID"];
                    t.FlightID = (long)reader["FLIGHT_ID"];
                    t.CustomerID = (long)reader["CUSTOMER_ID"];
                    List.Add(t);

                }
            }
            return List;
        }

        public void Remove(Ticket t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_TICKET", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.ID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Connection.Close();
                
            }
        }

        public void Update(Ticket t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_TICKET", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.ID));
                cmd.Parameters.Add(new SqlParameter("@FLIGHT_ID", t.FlightID));
                cmd.Parameters.Add(new SqlParameter("@CUSTOMER_ID", t.CustomerID));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                

                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Connection.Close();
            }
          
        }
   }
}
