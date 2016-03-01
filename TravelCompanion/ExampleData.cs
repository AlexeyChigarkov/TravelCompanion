using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    public static class ExampleData
    {

        public static void LoadData()
        {

            User me = new User("Alex", "06766677788");

            User you = new User("Paul", "06766677788");

            User he = new User("Andrew", "0503455678");

            User she = new User("Anna", "anna@mail.ru");

            User he2 = new User("Ninja", "0963244567");

            User she2 = new User("Olechka", "skype ola-la.la");

            User he3 = new User("Sergey", "0501218955");

            User he4 = new User("Nick", "0639805124");

            User he5 = new User("Maxim", "+38067956487");

            User she3 = new User("Ksyusha", "0911015437");

            you.CreateDriverRequest(new DriverRequest("Dnepr", "Warsaw", 2, 5, 1, "Kiev,Rivne,Lwow", 50, 100));

            me.CreatePassengerRequest(new PassengerRequest("Dnepr", "Lviv", 5, 1, 40, 80));

            he.CreateDriverRequest(new DriverRequest("Dnepr", "Rivno", 1, 5, 1, "Kiev", 390, 90));

            she.CreatePassengerRequest(new PassengerRequest("Dnepr", "Lviv", 5, 1));

            he2.CreatePassengerRequest(new PassengerRequest("Dnepro", "Kiev", 5, 1, 40, 80));

            she2.CreateDriverRequest(new DriverRequest("Dnepr", "Odesa",1, 5, 2,"Nikolaev"));

            he3.CreatePassengerRequest(new PassengerRequest("Dnepro", "Nikalaev", 5, 2));


            he4.CreatePassengerRequest(new PassengerRequest("Dnepr", "Odessa", 5, 2));


            he5.CreatePassengerRequest(new PassengerRequest("Dnepro", "Kherson", 5, 2));


            she3.CreateDriverRequest(new DriverRequest("Dnepr", "Odesa", 1, 5, 2, "Nikolaev,Herson"));


        }
    }
}
