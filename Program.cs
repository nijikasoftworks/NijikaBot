using System;

namespace nijikabot.space_cat_games_devtool
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nNijikaBot - Written By Meowcat; Belongs to Meowcat.");
                Console.WriteLine("1. Check user address");
                Console.WriteLine("2. Run testing scripts");
                Console.WriteLine("3. Check API endpoint");
                Console.WriteLine("4. Test load time");
                Console.WriteLine("5. Diagnostics (show last 5 log entries)");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter user address to check: ");
                        string address = Console.ReadLine();
                        var checker = new Services.AddressChecker();
                        try
                        {
                            bool exists = checker.CheckAddressAsync(address).Result;
                            Services.Logger.Log($"Checked address: {address}, Exists: {exists}");
                            Console.WriteLine(exists
                                ? "Address found on Space Cat Games website."
                                : "Address not found.");
                        }
                        catch (Exception ex)
                        {
                            Services.Logger.Log($"Error checking address: {address}. Exception: {ex.Message}");
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        var tester = new Tools.TestingTool();
                        Services.Logger.Log("Ran testing scripts.");
                        tester.RunTests();
                        break;
                    case "3":
                        Console.Write("Enter API endpoint URL: ");
                        string apiUrl = Console.ReadLine();
                        var apiChecker = new Services.ApiChecker();
                        try
                        {
                            int status = apiChecker.CheckApiStatusAsync(apiUrl).Result;
                            Services.Logger.Log($"Checked API endpoint: {apiUrl}, Status: {status}");
                            if (status == -1)
                                Console.WriteLine("Error: Unable to reach API endpoint.");
                            else
                                Console.WriteLine($"API responded with status code: {status}");
                        }
                        catch (Exception ex)
                        {
                            Services.Logger.Log($"Error checking API endpoint: {apiUrl}. Exception: {ex.Message}");
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "4":
                        Console.Write("Enter URL to test load time: ");
                        string loadUrl = Console.ReadLine();
                        var loadTester = new Services.LoadTimeTester();
                        try
                        {
                            long ms = loadTester.TestLoadTimeAsync(loadUrl).Result;
                            Services.Logger.Log($"Tested load time for: {loadUrl}, Time: {ms} ms");
                            if (ms == -1)
                                Console.WriteLine("Error: Unable to reach URL.");
                            else
                                Console.WriteLine($"Load time: {ms} ms");
                        }
                        catch (Exception ex)
                        {
                            Services.Logger.Log($"Error testing load time for: {loadUrl}. Exception: {ex.Message}");
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "5":
                        var entries = Services.Logger.GetLastEntries(5);
                        Console.WriteLine("Last 5 log entries:");
                        foreach (var entry in entries)
                            Console.WriteLine(entry);
                        break;
                    case "0":
                        Services.Logger.Log("Exited application.");
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}