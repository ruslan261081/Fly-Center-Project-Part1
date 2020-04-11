using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCenterProject
{
   public  class DeleteDataDAO
   {
        public void CleanAllDatabase()
        {
            using (SqlConnection con = new SqlConnection(FlightCenterConfig.CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("CLEAN_ALL_DB", con))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
        }
   }
}
