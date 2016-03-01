using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public class ProgrammConsole

    {
        public User currentUser;

        public delegate void ConditionHandler();
        ConditionHandler cond;

        public ProgrammConsole()
        {
            cond = SignIn;

        }

        public void ConsoleCondition(ConditionHandler newCond)

        {
            cond = newCond;
        }

        public void Update()
        {
            cond();

        }

        public void SignIn()
        {



            currentUser = null;
            Console.WriteLine("************************************************************************");
            Console.WriteLine("Welcome to the Travel Companion");
            Console.WriteLine("************************************************************************");
            Console.WriteLine("Choose the number of  operation:");
            Console.WriteLine("************************************************************************");
            Console.WriteLine("Sing in as existing user - 1\n" +
                            "Register new user - 2\n" +
                            "Search for passengers requestes - 3\n" +
                            "Search for driver requestes - 4\n");
            Console.WriteLine("************************************************************************");
            
            int choice = SearchUtils.CheckIntInput(1,4);

            switch (choice)
            {
                case 1:

                    {
                        Console.WriteLine("Enter user Id");
                        int id = SearchUtils.CheckIntInput(1,Int32.MaxValue);

                        currentUser = SqlSimulator.GetSqlSimulator().UsersTable.Find(x => x.UserID == id);

                        if (currentUser != null)
                        {


                            cond = SignedUserConsole;
                        }

                        else
                        {
                            Console.WriteLine("User Id not found");
                            Console.ReadKey();

                        }
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Input new user nickname");

                        string name = Console.ReadLine();

                        Console.WriteLine("Input contact information");

                        string contact = Console.ReadLine();

                        currentUser = new User(name, contact);

                        cond = SignedUserConsole;

                        break;
                    }

                case 4:
                    {
                        PassengerRequest request = SearchUtils.ConsoleReadPassenger();
                        List<SearchResult> result = SearchUtils.FindDrivers(request);
                        SearchUtils.PrintResults(result);
                        Console.ReadKey();
                       
                        break;

                    }

                case 3:
                    {
                        DriverRequest request = SearchUtils.ConsoleReadDriver();
                        List<SearchResult> result = SearchUtils.FindPassengers(request);
                        SearchUtils.PrintResults(result);
                        Console.ReadKey();
                        break;
                    }


                default:
                    {
                        break;
                    }
            }


        }

        public void SignedUserConsole()
        {

            Console.WriteLine("Hello {0}", currentUser.NickName);
            Console.WriteLine("************************************************************************");
            Console.WriteLine("You have {0} passenger request", currentUser.MyPassengerRequests.Count());
            currentUser.MyPassengerRequests.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("************************************************************************");
            Console.WriteLine("You have {0} driver request", currentUser.MyDriverRequests.Count());
            currentUser.MyDriverRequests.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("************************************************************************");

            Console.WriteLine("Choose the number of  operation:");
            Console.WriteLine("************************************************************************");
            Console.WriteLine("Find passenger for your driver request - 1\n" +
                              "Find drivers for your passenger request - 2\n" +
                              "Delete driver request - 3\n" +
                              "Delete passenger request - 4\n" +
                              "Create new passenger request - 5\n" +
                              "Create new driver request - 6\n" +
                              "Change number of free seats in your driver request - 7\n" +
                              "Log out -8 ");
            Console.WriteLine("************************************************************************");

            int choice = SearchUtils.CheckIntInput(1,8);

            switch (choice)
            {
                case 1:
                    {

                        Console.WriteLine("Enter driver request Id");
                        int id = SearchUtils.CheckIntInput(1, Int32.MaxValue);

                        DriverRequest request = SqlSimulator.GetSqlSimulator().DriverRequests.Find(x => x.Id == id);
                        if (request != null && request.UserId == currentUser.UserID)
                        {

                            List<SearchResult> result = SearchUtils.FindPassengers(SqlSimulator.GetSqlSimulator().DriverRequests.Find(x => x.Id == id));

                            SearchUtils.PrintResults(result);
                            Console.ReadKey();

                        }

                        else
                        {

                            Console.WriteLine("You haven't driver requests with id {0}", id);
                            Console.ReadKey();
                        }


                        break;
                    }

                case 2:
                    {

                        Console.WriteLine("Enter passenger request Id");
                        int id = SearchUtils.CheckIntInput(1, Int32.MaxValue);
                        PassengerRequest request = SqlSimulator.GetSqlSimulator().PassengerRequests.Find(x => x.Id == id);

                        if (request != null && request.UserId == currentUser.UserID)
                        {
                            List<SearchResult> result = SearchUtils.FindDrivers(SqlSimulator.GetSqlSimulator().PassengerRequests.Find(x => x.Id == id));

                            SearchUtils.PrintResults(result);
                            Console.ReadKey();
                        }
                        else
                        {

                            Console.WriteLine("You haven't passenger requests with id {0}", id);
                            Console.ReadKey();
                        }
                        break;
                    }

                case 3:
                    {

                        Console.WriteLine("Enter driver request Id");
                        int id = SearchUtils.CheckIntInput(1, Int32.MaxValue);

                        DriverRequest request = SqlSimulator.GetSqlSimulator().DriverRequests.Find(x => x.Id == id);
                        if (request != null && request.UserId == currentUser.UserID)
                        {


                            currentUser.DeleteDriverRequest(id);
                            Console.WriteLine("Deleted driver request with Id {0}", id);
                            Console.ReadKey();
                        }

                        else
                        {

                            Console.WriteLine("You haven't driver requests with id {0}", id);
                            Console.ReadKey();
                        }

                        break;

                    }

                case 4:
                    {

                        Console.WriteLine("Enter driver request Id");
                        int id = SearchUtils.CheckIntInput(1, Int32.MaxValue);


                        PassengerRequest request = SqlSimulator.GetSqlSimulator().PassengerRequests.Find(x => x.Id == id);
                        if (request != null && request.UserId == currentUser.UserID)
                        {
                            currentUser.DeletePassengerRequest(id);
                            Console.WriteLine("Deleted driver request with Id {0}", id);
                            Console.ReadKey();
                        }

                        else
                        {

                            Console.WriteLine("You haven't driver requests with id {0}", id);
                            Console.ReadKey();
                        }

                        break;

                    }

                case 5:
                    {
                        PassengerRequest request = SearchUtils.ConsoleReadPassenger();

                        currentUser.CreatePassengerRequest(request);
                        Console.ReadKey();
                        break;
                    }

                case 6:
                    {
                        DriverRequest request = SearchUtils.ConsoleReadDriver();

                        currentUser.CreateDriverRequest(request);
                        Console.ReadKey();
                        break;

                    }

                case 7:
                    {
                        Console.WriteLine("Enter driver request Id");
                        int id = SearchUtils.CheckIntInput(1, Int32.MaxValue);

                        DriverRequest request = SqlSimulator.GetSqlSimulator().DriverRequests.Find(x => x.Id == id);
                        if (request != null && request.UserId == currentUser.UserID)
                        {

                            Console.WriteLine("Enter number of availbale seats");
                            byte places = Convert.ToByte(Console.ReadLine());

                            currentUser.ChangeAvailablePlaces(id, places);
                        }
                        else
                        {

                            Console.WriteLine("You haven't driver requests with id {0}", id);
                            Console.ReadKey();
                        }

                        break;
                    }


                case 8:
                    {

                        cond = SignIn;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

        }
    }
}