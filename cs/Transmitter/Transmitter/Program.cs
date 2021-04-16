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
            Bluetooth data = new Bluetooth();

            //await Bluetooth.PostJsonHttpClient();

            // run code if testing something
            var programRuntime = 2000;
            //if (config.RUN_TESTS) {}
            //else { Thread.Sleep(programRuntime); }


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
