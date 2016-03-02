using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public static class SearchUtils
    {

        public static DriverRequest ConsoleReadDriver()

        {
            Console.WriteLine("Enter departure city");
            string dc = Console.ReadLine();

            Console.WriteLine("Enter arrival city");
            string ac = Console.ReadLine();

            Console.WriteLine("Enter number of passengers you can take");
            byte places = (byte)CheckIntInput(1, Byte.MaxValue);



            Console.WriteLine("Enter departure month number from 1 to 12");
            byte month = (byte)CheckIntInput(1, 12);

            Console.WriteLine("Enter departure day number from 1 to 31");
            byte day = (byte)CheckIntInput(1, 31);

            Console.WriteLine("Enter cities in the route where you can land passengers");
            string route = Console.ReadLine();

            Console.WriteLine("Enter weight of your luggage in kg");
            ushort weight = (ushort)CheckIntInput(0, UInt16.MaxValue);


            Console.WriteLine("Enter max height t of your luggage in cm");
            ushort height = (ushort)CheckIntInput(0, UInt16.MaxValue);

            return new DriverRequest(dc, ac, places, month, day, route, weight, height);


        }
        public static PassengerRequest ConsoleReadPassenger()
        {
            Console.WriteLine("Enter departure city");
            string dc = Console.ReadLine();

            Console.WriteLine("Enter arrival city");
            string ac = Console.ReadLine();

            Console.WriteLine("Enter departure month number from 1 to 12");
            byte month = (byte)CheckIntInput(1, 12);

            Console.WriteLine("Enter departure day number from 1 to 31");
            byte day = (byte)CheckIntInput(1, 31);

            Console.WriteLine("Enter weight of your luggage in kg");
            ushort weight = (ushort)CheckIntInput(0, UInt16.MaxValue);


            Console.WriteLine("Enter max height t of your luggage in cm");
            ushort height = (ushort)CheckIntInput(0, UInt16.MaxValue);

            return new PassengerRequest(dc, ac, month, day, weight, height);
        }




        public static void PrintResults(List<SearchResult> result)
        {

            if (result.Count() == 0)
            {
                Console.WriteLine("Sorry... no appropriate requests for you at this time");
            }


            else
            {
                Console.WriteLine("Great! We found {0} requestes for you:", result.Count());
                Console.WriteLine("************************************************************************");
                result.ForEach(x => Console.WriteLine(x));
                Console.WriteLine("************************************************************************");

            }

            

        }



        public static List<SearchResult> FindDrivers(PassengerRequest request)


        {
            List<SearchResult> result = new List<SearchResult>();


            try
            {
                var r = (from req in SqlSimulator.GetSqlSimulator().DriverRequests

                         where IsStringsSimilar(req.DepartureCity,request.DepartureCity) 
                              && (IsStringsSimilar(req.ArrivalCity, request.ArrivalCity) || ListContainSimilarString(req.RouteCities, request.ArrivalCity))
                              && req.AvailablePlaces > 0
                              && req.DepartureDay==request.DepartureDay
                              && req.DepartureMonth == request.DepartureMonth
                              && req.LuggageWeight >= request.LuggageWeight
                              && req.LuggageHeight >= request.LuggageHeight


                         select req).ToList();

                result = (from req in r
                          join user in SqlSimulator.GetSqlSimulator().UsersTable on req.UserId equals user.UserID
                          select new SearchResult
                          {
                              NickName = user.NickName,

                              Contact = user.Contact,

                              DepartureDay = req.DepartureDay,

                              DepartureMonth = req.DepartureMonth,

                              DepartureCity = req.DepartureCity,

                              ArrivalCity = req.ArrivalCity,


                          }).ToList();
            }
            catch
            {
            }

            return result;
        }

        public static List<SearchResult> FindPassengers(DriverRequest request)
        {

            List<SearchResult> result = new List<SearchResult>();

            try
            {

                var r = (from req in SqlSimulator.GetSqlSimulator().PassengerRequests

                         where   IsStringsSimilar(req.DepartureCity,request.DepartureCity) 
                              && IsStringsSimilar(req.ArrivalCity, request.ArrivalCity)
                              && req.DepartureDay == request.DepartureDay
                              && req.DepartureMonth == request.DepartureMonth
                              && req.LuggageWeight <= request.LuggageWeight
                              && req.LuggageHeight <= request.LuggageHeight


                         select req).ToList();

                result = (from req in r
                          join user in SqlSimulator.GetSqlSimulator().UsersTable on req.UserId equals user.UserID
                          select new SearchResult
                          {
                              NickName = user.NickName,

                              Contact = user.Contact,

                              DepartureDay = req.DepartureDay,

                              DepartureMonth = req.DepartureMonth,

                              DepartureCity = req.DepartureCity,

                              ArrivalCity = req.ArrivalCity,


                          }).ToList();
            }

            catch
            {


            }

            return result;
        }

        public static bool IsStringsSimilar(string s1, string s2)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();

            int min = Math.Min(s1.Length, s2.Length);

            int mistake = Math.Abs(s1.Length - s2.Length);

            for (int i = 0; i < min; i++)

            {

                if (s1[i] != s2[i])
                {
                    ++mistake;
                }
            }

            return mistake > 2 ? false : true;
        }

        public static bool ListContainSimilarString(List<string> list, string str)
        {

            foreach (string item in list)
            {

                if (IsStringsSimilar(item, str))
                {
                    return true;
                }

            }

            return false;
        }

        public static int CheckIntInput(int s, int f)
        {
            bool result = false;
            int input = 0;

            do
            {

                result = Int32.TryParse(Console.ReadLine(), out input);
                if (!result | input > f | input < s)
                {
                    Console.WriteLine("Invalid input. Try Again");
                }
            }
            while (!result | input > f | input < s);

            return input;
        }



    }

}
