using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FlyCenterProject
{

    public static class FlightCenterConfig
    {
        public const string ADMIN_NAME = "admin";
        public const string ADMIN_PASSWORD = "9999";
        public const int ONEDAY_INTERVAL = 1000 * 60 * 60 * 24;
        public const string CONNECTION_STRING = (@"Data Source=DESKTOP-EGLVPS0\SQLEXPRESS;Initial Catalog = Fly Center; Integrated Security = True");
       

        /*@"Server = tcp:flycenterdb.database.windows.net,1433;Initial Catalog = flycenter.Azure; Persist Security Info=False;User ID = {Ruslan }; Password={Tamerlan09
     }; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";*/




    }
    
}
