using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System;
using System.IO;

namespace Evoke.Kiosk.Nordic
{
    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5050")
                .UseContentRoot(AppContext.BaseDirectory);

        static public HttpClient NotificationClient
        {
            get;
            internal set;
        }

        public static void Main(string[] args)
        {
            Initialise();

            IWebHost host = CreateWebHostBuilder(args).Build();

            bool isService = !(Debugger.IsAttached);

            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;

                var pathToContentRoot = Path.GetDirectoryName(pathToExe);

                Directory.SetCurrentDirectory(pathToContentRoot);

                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }

        public static void Initialise()
        {
            NotificationClient = new HttpClient();
        }
    }
}
