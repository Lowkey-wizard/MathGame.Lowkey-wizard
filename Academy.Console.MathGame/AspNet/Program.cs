using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace MathGame
{
    public class Program : GameMenu
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHost(
                    webHost => webHost
                        .UseKestrel(kestrelOptions => { kestrelOptions.ListenAnyIP(5005); })
                        .Configure(app => app
                            .Run(
                                async context =>
                                {                                    
                                    await GameMenu.Menu();
                                }
                            )));
    }
}

