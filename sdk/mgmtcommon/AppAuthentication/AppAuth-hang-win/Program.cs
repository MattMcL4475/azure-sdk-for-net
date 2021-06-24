using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Threading.Tasks;

namespace AppAuth_hang_win
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Calling GetAccessTokenAsync...");

            // this hangs forever on Windows domain-joined machines
            var token = await new AzureServiceTokenProvider().GetAccessTokenAsync("https://management.azure.com/"); 
            
            Console.WriteLine($"Success.  No bug found in this configuration.  Press any key to quit.");
            Console.ReadKey();
        }
    }
}
