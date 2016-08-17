using System;
using Microsoft.Owin.Hosting;

namespace WebBalloon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string url = "http://localhost:28660";
            using (WebApp.Start<BallonNotifierStartup>(url))
            {
                Console.WriteLine("Starting service in " + url);
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
        }
    }
}
