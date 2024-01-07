using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

string fileName = $"{DateTime.Now}";
fileName = fileName.Replace('/', '.');
fileName = fileName.Replace(':', '.');
fileName = fileName +  ".txt";

FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8);
Console.WriteLine($"Internet Dropout Monitor [{DateTime.Now}]");
sw.WriteLine($"Internet Dropout Monitor [{DateTime.Now}]");
// Specify the host to ping (e.g., a reliable DNS server)
string hostToPing = "8.8.8.8"; // Google's DNS

// Set the interval for checking the internet connection (in milliseconds)
int checkInterval = 10000; // 10 seconds

while (true)  
{
    if (IsInternetConnected(hostToPing))
    {
        Console.WriteLine($"[{DateTime.Now}]: Connected.");
        sw.WriteLine($"[{DateTime.Now}]: Connected.");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"[{DateTime.Now}]: Internet dropout detected!");
        sw.WriteLine($"[{DateTime.Now}]: Internet dropout detected!");
        Console.WriteLine();
    }

    Thread.Sleep(checkInterval);
}

static bool IsInternetConnected(string hostToPing)
{
    try
    {
        using (Ping ping = new Ping())
        {
            PingReply reply = ping.Send(hostToPing);
            return reply.Status == IPStatus.Success;
        }
    }
    catch
    {
        return false;
    }
}
