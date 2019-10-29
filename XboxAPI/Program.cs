using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using XboxLiveData;

namespace XboxAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the XBOX live search tool!");
            Thread.Sleep(1000);
            Credentials.GamerTag = Methods.GetGamerTag();
            Credentials.XUID = Methods.GetXUID();

            bool active = true;

            while (active)
            {
                Console.WriteLine("Please choose an action: \n" +
                  "1) View Info\n" +
                  "2) View Xbox One Games\n" +
                  "3) View Xbox 360 Games\n" +
                  "5) Get Screenshots\n" +
                  "5) Get Game Clips\n" +
                  "6) Exit");
                Console.WriteLine();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(Methods.GetInfo());
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        foreach (var item in Methods.GetXboxOneGames())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        foreach (var item in Methods.GetXbox360Games())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        foreach (var item in Methods.GetScreenShots())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;


                    case "5":
                        Console.Clear();
                        foreach (var item in Methods.GetGameClips())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case "6":
                        active = false;
                        break;

                    default:
                        break;
                }
            }

            //Console.WriteLine(Methods.GetXUID());

            //Console.WriteLine(Methods.GetGamerTag());

            //Console.WriteLine(Methods.GetInfo());

            //Console.WriteLine(Methods.GetGameImg(1327376519));
        }
    }
}
