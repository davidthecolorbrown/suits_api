// Dependencies for web API
// Microsoft.AspNet.WebApi.Client (5.2.7)
// Newtonsoft.Json (12.0.3)

using System;
using System.Threading.Tasks;
using System.Threading;
using Trasmitter.Datastream;

namespace Transmitter
{

    class Program
    {

        //public static async Task Main(string[] args)
        public static Task Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~  MAIN() PROGRAM HAS STARTED  ~~~~~~");
            Console.WriteLine("~~~~~~     APPLICATION NAMESPACE    ~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();

            // connect to datastream (telemetry, bluetooth, etc)
            Data.InitClient();

            // initialize serial communication through bluetooth
            //string port = "/dev/cu.DSDTECHHC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
            //string port = "dev/cu.HC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
            //string port = "COM7";
            //int baudrate = 9600;
            //Bluetooth data = new Bluetooth(port, baudrate);
            Bluetooth data = new Bluetooth();


            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~ MAIN() PROGRAM HAS ENDED ~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            return Task.CompletedTask;
        }
    }
}
