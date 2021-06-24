using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Threading.Tasks;

namespace AppAuth_hang_win
{
    class Program
    {
        static async Task Main()
        {
            // Repro
            // 1.  Use a Windows corpnet-joined machine with two identities (2 x @microsoft.com accounts)
            // 2.  az logout

            Console.WriteLine("Calling GetAccessTokenAsync...");

            bool enableVisualStudioAccessTokenProvider = true;

            if (enableVisualStudioAccessTokenProvider)
            {
                // this hangs forever on Windows corpnet domain-joined machines with two identities (2 x @microsoft.com accounts)
                var token1 = await new AzureServiceTokenProvider(enableVisualStudioAccessTokenProvider: true).GetAccessTokenAsync("https://management.azure.com/");
                if (!string.IsNullOrWhiteSpace(token1)) Console.WriteLine($"Success with method1");
            }
            else
            {
                // but this works
                var token2 = await new AzureServiceTokenProvider(enableVisualStudioAccessTokenProvider: false).GetAccessTokenAsync("https://management.azure.com/");
                if (!string.IsNullOrWhiteSpace(token2)) Console.WriteLine($"Success with method2");
            }

            Console.WriteLine($"Press any key to quit.");
            Console.ReadKey();
        }
    }
}
