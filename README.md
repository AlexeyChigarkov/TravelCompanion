<h1>Comments   to “Travel Companion" program</h1>

<h3>Intro</h3>  


First of all I want to say that this program doesn’t fully meet all the requirements in the task. 
 It’s because of two reasons:
-	Due to lack of time to work with Visiual Studio at home I wrote this program mostly at https://dotnetfiddle.net/ROcqfN  during free time at work.  And there’s no possibilities to create UI except console and to create IO streams or SQL connections and databases 

-	My experience in the creating UI and SQL databases are poor and I need much more time for it
Anyway I try to develop program with simple console interface and without real database.  To simulate 
Interaction with SQL database I decided to create special SqlSimulator class with collections which are similar to  real database tables we need for such program.  Of course it can work only with run-time memory.

<h3>Program structure</h3>  


Model  has 3 main entities:

User -  class that represents registered program user. This class is relative to database table UserTable

PassengerRequest – class that represents requests from passengers.  Relative with PassengerRequests table 

DriverRequest – class that represents requests from drivers.  Relative with DriverRequests table 

User class aggregate collections of  his PassengerRequest  and DriverRequest.   In this way each User 
can be  a passenger as well as a driver depends on his needs.  

Also program has SearchResult class that represents results when we join UserTable on PassengerRequests  table or DriverRequests table

SqlSimualtor class designed to simulate real SQL database.  It has 3 collections for each main program entity.  This class made according to Singleton pattern so each users and utility blocks will be automatically “connected” to one and only “database”. 


ProgramConsole  - class which organize interaction of   Windows Console user   with our main classes. 
It’s working like simple FSM with two states – SignIn (when console user isn’t signed into program) 
and SignedUserConsole (when user is already in our database) 
In the SignIn state console user can only make searches in our database but can’t create own requests.   
 To change state to the SignedUserConsole user must be exist in UsersTable or should register as a new user.    To change state in reverse order user should make sign out. 
Static class SearchUtility  consist of methods which will help us to make search in database, organize and  check input values from console etc.

To avoid differences in the cities spelling SearchUtility has method IsStringsSimilar which compare two strings 
and make decision are they similar or not.  Off course it’s very simple and not very useable algorithm in real programs but it can handle some simple differences or mistakes in spelling like Lvov and Lviv, Kiev and Kyiv, Odessa and Odesa. 


<h3>How it’s work</h3>


As I noted above each user can make both driver requests and passenger requests.  User information consists only of user nickname and user contact information.  Each user received unique Id.  This Id will be users “key” to sign in. 
In driver request user must declare city of departure, arrival city, month of departure and day of departure.   Can add other cities in its route where passengers can be landed. Note that the passenger can take a seat only in departure point but can leave it in any cities thru the driver route.   Also in the driver request must be declared number of available seats for passengers.   Driver also can specify maximal weight and height of passenger luggage. 
In passenger request user  also must indicate city of departure, arrival city, month of departure and day of departure.  Additionaly can be  declared luggage parameters. 
Users can manage their requests.  But not very  much.   For driver request owner user can change only 
number of available seats. In the passenger request user can’t change anything.  
So if user needs to change request he have to delete old request and create new. 
Departure date include only day and month but not year.  I think situation when departure day will be after more than 12 month from creation day is not very real.  
When the user claims a new request program make search for it immediately.  So user doesn’t need to make special search. 

To test the program I added 10 users and 10 requests.  In all of these requests Dnepr is a departure point, 1-st or 2-nd of May is a departure date, and Lvov or Odessa is  an arrival points with some small variation. 
