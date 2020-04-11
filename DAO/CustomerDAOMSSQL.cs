using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
  public class CustomerDAOMSSQL : ICustomerDAO
  {
        public long Add(Customer t)
        {
            long NewID = 0;
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("ADD_NEW_CUSTOMER", connection);
              
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", t.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", t.LastName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", t.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", t.Password));
                cmd.Parameters.Add(new SqlParameter("@ADDRESS", t.Address));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NO", t.PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@CREDIT_CARD_NUMBER", t.CreditCardNumber));


                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                

                
                cmd.Connection.Close();

            }
            return NewID;
        }
        public Customer Get(long id)
        {
            Customer t = new Customer();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_CUSTOMER_BY_ID", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while(reader.Read()== true)
                {


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
                return t;
               
            }
        }

        public IList<Customer> GetAll()
        {
            List<Customer> List = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_CUSTOMER", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while(reader.Read()== true)
                {
                    Customer Customer = new Customer();
                    Customer.Id = (long)reader["ID"];
                    Customer.FirstName = (string)reader["FIRST_NAME"];
                    Customer.LastName = (string)reader["LAST_NAME"];
                    Customer.UserName = (string)reader["USER_NAME"];
                    Customer.Password = (string)reader["PASSWORD"];
                    Customer.Address = (string)reader["ADDRESS"];
                    Customer.PhoneNo = (string)reader["PHONE_NO"];
                    Customer.CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"];

                    List.Add(Customer);


                }

            }
            return List;
        }

        public Customer GetCustomerByUserName(string username)
        {
            Customer t = new Customer();
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("GET_CUSTOMER_BY_USER_NAME", connection);
                cmd.Parameters.Add(new SqlParameter("@USERNAME", username));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while(reader.Read()== true)
                {
                    t.Id = (long)reader["ID"];
                    t.FirstName = (string)reader["FIRST_NAME"];
                    t.LastName = (string)reader["LAST_NAME"];
                    t.UserName = (string)reader["USER_NAME"];
                    t.Password = (string)reader["PASSWORD"];
                    t.Address = (string)reader["ADDRESS"];
                    t.PhoneNo = (string)reader["PHONE_NO"];
                    t.CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"];

                }
                cmd.Connection.Close();
                return t;

            }
        }

        public void Remove(Customer t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("REMOVE_CUSTOMER", connection);
                cmd.Parameters.Add(new SqlParameter("@ID", t.Id));
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();
            }
        }

        public void Update(Customer t)
        {
            using (SqlConnection connection = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("ADD_CUSTOMER", connection);
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", t.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", t.LastName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", t.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", t.Password));
                cmd.Parameters.Add(new SqlParameter("@ADDRESS", t.Address));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NO", t.PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@CREDIT_CARD_NUMBER", t.CreditCardNumber));

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();

            }
        }
   }
}
