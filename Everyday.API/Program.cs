using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;

namespace Everyday.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
#if DEBUG
                    .UseUrls(BuildHostingUrls())
#endif
                    .UseUrls("https://192.168.0.168:5001", "http://192.168.0.168:5000")
                        .UseStartup<Startup>();
            });

        private static string[] BuildHostingUrls()
        {
            string[] hostingUrls = new string[2];

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);

                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;

                hostingUrls[0] = string.Concat("https://", endPoint.Address, ":", "5001");
                hostingUrls[1] = string.Concat("http://", endPoint.Address, ":", "5000");
            }
            return hostingUrls;
        }
    }
}
