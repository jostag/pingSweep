using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace pingSweep
{
    class Program
    {
        static void Main(string[] args)
        {
            Ping pingIP = new Ping();
            Console.WriteLine("Please enter the first 3 octets of the desired IP.");
            string subNet = Console.ReadLine();
            var firstHost = 0;
            var lastHost = 255;
            int numberOfHosts = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            while (firstHost < lastHost)
            {
                var IP = subNet + "." + firstHost;
                PingReply reply = pingIP.Send(IP, timeout: 500);
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Address: {0}", reply.Address.ToString());
                    numberOfHosts++;
                }
                firstHost++;


            }

            if (numberOfHosts == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are " + numberOfHosts + " hosts on the network.");
                Console.WriteLine("Please check network connectivity and try a diffrent subnet.");
            }
            else
            {
                Console.WriteLine("There are " + numberOfHosts + " hosts on the network.");
            }
            Console.Write("Press enter to exit:");
            Console.ReadLine();
        }
    }
}
