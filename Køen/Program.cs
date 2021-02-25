using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Køen
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<FriendInfo> friends = new Queue<FriendInfo>();

            Console.WriteLine("What is your name?");
            string player = Console.ReadLine();
            Console.WriteLine("Welcome Home - " + player);

            while (true)
            {
                Menu();
                Console.WriteLine("--Waiting for User Input--");
                string userChoice = Console.ReadLine();

                switch (userChoice.ToLower())
                {
                    case "play":
                        Console.WriteLine(" WARNING: For this game to have functionality you need to add friends first!");
                        Thread.Sleep(500);
                        Console.Clear();

                        Console.WriteLine("-| Your Friend list has now been Shuffled.");
                        Thread.Sleep(500);
                        Console.Clear();

                        var shuffledPlayers = friends.OrderBy(a => Guid.NewGuid()).ToList();

                        FriendInfo firstToLeave = friends.Dequeue();
                        Console.WriteLine(string.Format("First to leave: {0}", firstToLeave.friendName));

                        FriendInfo soonToLeave = friends.Peek();
                        Console.WriteLine(string.Format("Next to leave is: {0}",
                        soonToLeave.friendName));
                        break;

                    case "friends":
                        if (friends.Count > 0)
                        {
                            friends.ToList().ForEach(x => Console.WriteLine($"Name: {x.friendName}, Level: {x.friendLevel}"));
                            Console.WriteLine("Friend has been added-");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You currently have no friends online.");
                        }
                        break;

                    case "add friends":
                        Random rnd = new Random();
                        int friendlevel = rnd.Next(1, 100);

                        Console.WriteLine("What is the username of the user you wish to befriend?");
                        string friendRequest = Console.ReadLine();
                        friends.Enqueue(new FriendInfo() { friendName = friendRequest, friendLevel = friendlevel });
                        break;

                    case "time":
                        Console.WriteLine("The time is currently: " + DateTime.Now);
                        break;

                    default:
                        Console.WriteLine("ERROR: 404");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void Menu()
        {
            Console.WriteLine("=================");
            Console.WriteLine("      -Game-     ");
            Console.WriteLine(" Who leaves first");
            Console.WriteLine("=================");
            Console.WriteLine(" - Play          ");
            Console.WriteLine(" - Friends       ");
            Console.WriteLine(" - Add Friends   ");
            Console.WriteLine(" - Time          ");
            Console.WriteLine("=================");
        }
    }
}
