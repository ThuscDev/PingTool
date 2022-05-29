using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace PingTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            
            Console.WriteLine("Enter an IP Address: ");
            string pingMe = Console.ReadLine();

            options.DontFragment = true;

            string data = "Bill";
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(pingMe, timeout, buffer, options);

            if (reply.Status == IPStatus.Success){
                Console.WriteLine($"Address: {pingMe}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            else
            {
                Console.WriteLine($"{pingMe} did not respond");
            }

            
        }
    }
}
