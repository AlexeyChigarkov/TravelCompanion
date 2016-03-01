using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public class PassengerRequest
    {

        public uint Id { get; set; }
        public byte DepartureDay { get; set; }

        public byte DepartureMonth { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public uint UserId { get; set; }

        public ushort LuggageWeight { get; set; }

        public ushort LuggageHeight { get; set; }

        private static uint _idCounter = 0;


        public PassengerRequest(string dc, string ac, byte month, byte day, ushort weight = 0, ushort height = 0)
        {

            DepartureDay = day;
            DepartureMonth = month;
            DepartureCity = dc;
            ArrivalCity = ac;
            UserId = 0;
            LuggageWeight = weight;
            LuggageHeight = height;

            ++_idCounter;
            Id = _idCounter;
        }


        public override string ToString()
        {

            return string.Format("Reuqest Id {0}, from {1} to {2} at {3}.{4},  luggage weight {5},  luggage height {6}",
                                 Id, DepartureCity, ArrivalCity, DepartureDay, DepartureMonth, LuggageWeight, LuggageHeight);
        }

    }


}
