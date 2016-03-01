using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public class SqlSimulator
    {

        public List<User> UsersTable;

        public List<PassengerRequest> PassengerRequests;

        public List<DriverRequest> DriverRequests;

        private static SqlSimulator SqlInstance;

        private SqlSimulator()
        {
            UsersTable = new List<User>();

            PassengerRequests = new List<PassengerRequest>();

            DriverRequests = new List<DriverRequest>();

        }

        public static SqlSimulator GetSqlSimulator()
        {

            if (SqlInstance == null)
            {
                SqlInstance = new SqlSimulator();

            }

            return SqlInstance;
        }

    }
}
