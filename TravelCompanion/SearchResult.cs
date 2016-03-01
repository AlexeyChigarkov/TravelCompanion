using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public class SearchResult
    {
        public string NickName;

        public string Contact;

        public byte DepartureDay;

        public byte DepartureMonth;

        public string DepartureCity;

        public string ArrivalCity;

        public override string ToString()
        {

            return string.Format("User - {0}, Contact info - {1}, Departure date - {2}.{3}, from {4} to {5}", NickName, Contact,
                                 DepartureDay, DepartureMonth, DepartureCity, ArrivalCity);

        }


    }

}
