using Microsoft.AspNetCore.Mvc;
// imports functionality from the ASP.NET Core MVC package listed in our .csproj file


namespace FriendLetter.Controllers
{
    public class HomeController : Controller
    {
        // the Hello() method represents a route in our application
        [Route("/hello")]
        public string Hello() { return "Hello friend!"; }
        // return "Hello friend" is called the action because it defines what the site will do
        // when a client requests this particular path
        [Route("/goodbye")]
        public string Goodbye() { return "Goodbye Friend."; }

        [Route("/")]
        public string Letter() { return "Our virtual postcard will go here soon!"; }
    }
}