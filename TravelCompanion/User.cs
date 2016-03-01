using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public class User
    {
        public uint UserID { get; private set; }

        public string NickName { get; set; }

        public string Contact { get; set; }

        public List<PassengerRequest> MyPassengerRequests { get; set; }

        public List<DriverRequest> MyDriverRequests { get; set; }

        public SqlSimulator DataBase { get; set; }

        private static uint _idCounter = 0;

        public User(string nick, string phone)
        {
            NickName = nick;
            Contact = phone;

            MyPassengerRequests = new List<PassengerRequest>();

            MyDriverRequests = new List<DriverRequest>();
            ++_idCounter;
            UserID = _idCounter;
            DataBase = SqlSimulator.GetSqlSimulator();
            DataBase.UsersTable.Add(this);

        }
        public void CreatePassengerRequest(PassengerRequest newRequest)
        {

            newRequest.UserId = this.UserID;
            MyPassengerRequests.Add(newRequest);
            DataBase.PassengerRequests.Add(newRequest);

            List<SearchResult> result = SearchUtils.FindDrivers(newRequest);

            SearchUtils.PrintResults(result);

        }

        public void CreateDriverRequest(DriverRequest newRequest)
        {
            newRequest.UserId = this.UserID;
            MyDriverRequests.Add(newRequest);
            DataBase.DriverRequests.Add(newRequest);

            List<SearchResult> result = SearchUtils.FindPassengers(newRequest);

            SearchUtils.PrintResults(result);


        }

        public void DeletePassengerRequest(int requestId)
        {
            MyPassengerRequests.RemoveAll(x => x.Id == requestId);
            DataBase.PassengerRequests.RemoveAll(x => x.Id == requestId);
        }


        public void DeleteDriverRequest(int requestId)
        {
            MyDriverRequests.RemoveAll(x => x.Id == requestId);
            DataBase.DriverRequests.RemoveAll(x => x.Id == requestId);

        }

        public void UpdateCondition()
        {
            for (int i = 0; i < MyPassengerRequests.Count; i++)
            {
                if (new DateTime(DateTime.Now.Year, MyPassengerRequests[i].DepartureMonth, MyPassengerRequests[i].DepartureDay) < DateTime.Now.Date)
                {
                    DeletePassengerRequest(i);
                }

            }

            for (int i = 0; i < MyDriverRequests.Count; i++)
            {
                if (new DateTime(DateTime.Now.Year, MyDriverRequests[i].DepartureMonth, MyDriverRequests[i].DepartureDay) < DateTime.Now.Date)
                {
                    DeleteDriverRequest(i);
                }

            }

        }

        public void ChangeAvailablePlaces(int requestId, byte places)
        {
            DriverRequest request = MyDriverRequests.Find(x => x.Id == requestId);

            if (request != null)
            {
                request.AvailablePlaces = places;
            }


        }


    }

}
