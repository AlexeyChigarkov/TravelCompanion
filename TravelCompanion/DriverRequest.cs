using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public class DriverRequest
    {



        public byte DepartureDay { get; set; }

        public byte DepartureMonth { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public List<string> RouteCities { get; set; }

        public byte AvailablePlaces { get; set; }

        public uint UserId { get; set; }


        public ushort LuggageWeight { get; set; }

        public ushort LuggageHeight { get; set; }

        public uint Id { get; set; }

        private static uint _idCounter = 0;



        public DriverRequest(string dc, string ac, byte places, byte month, byte day, string route = "", ushort weight = 0, ushort height = 0)
        {

            DepartureDay = day;
            DepartureMonth = month;
            DepartureCity = dc;
            ArrivalCity = ac;
            AvailablePlaces = places;

            RouteCities = route.Split(',').ToList();
            LuggageWeight = weight;

            LuggageHeight = height;

            UserId = 0;

            ++_idCounter;
            Id = _idCounter;
        }

        public override string ToString()
        {

            return string.Format("Reuqest Id {0}, from {1} to {2} via {8} at {3}.{4}. available {5} seats, max luggage weight {6}, max luggage height {7}",
                                 Id, DepartureCity, ArrivalCity, DepartureDay, DepartureMonth, AvailablePlaces, LuggageWeight,
                                 LuggageHeight, String.Join(" ", RouteCities));
        }


    }
}
