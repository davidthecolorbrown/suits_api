using System;
using System;
using System.Threading.Tasks;
using System.Net.Http; // import HttpClient class 
using System.Net.Http.Formatting;

// for FileIO
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// for Bluetooth
using System.Threading;
using System.IO.Ports;

namespace Trasmitter
{
    // SuitsUI.Datastream
    namespace Datastream
    {

        // class for interacting with NASA SUITS database (mongoDB)
        public static class Data
        {
            // create new http client for api with single api client (thread-safe)
            public static HttpClient api { get; set; }

            // initialize client for streaming data through api 
            public static void InitClient()
            {
                // create new api client and initialize 
                api = new HttpClient();

                // set base addresss
                //api.BaseAddress = new Uri("http://127.0.0.1:3002/api/vital");

                // clear header
                api.DefaultRequestHeaders.Accept.Clear();

                // add header telling client to give json 
                api.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        // load json object 
        public static class BlueTelemetry
        {

            // list that stores telemetry stream data so I can save to file for future testing
            public static List<BlueTelemetryModel> telemetryData = new List<BlueTelemetryModel>();

            // method to load telemetry stream data
            // returns TelemetryModel which maps onto json data by properties
            public static async Task<BlueTelemetryModel> LoadTelemetry(string base_url, bool uia = false)
            {
                // start with empty string for url
                string url = "";

                // decide whether to get recent suit data or dcu/uia recent data
                if (uia)
                {

                    url = "http://127.0.0.1:3002/api/vital";
                    Console.WriteLine("BLUETELEMETRY" + url);
                }
                else
                {
                    url = "http://127.0.0.1:3002/api/vital";
                    Console.WriteLine("BLUETELEMETRY" + url);
                }

                // new request using a single open api client and gets this as response
                using (HttpResponseMessage res = await Data.api.GetAsync(url))
                {
                    // if response is successful, read back data
                    if (res.IsSuccessStatusCode)
                    {
                        //TelemetryModel model = JsonConvert.DeserializeObject<TelemetryModel>(res);

                        // create new object for telemetry data
                        // takes data into as json and maps onto telemetry model, ignoring properties that don't match
                        BlueTelemetryModel telemetry = await res.Content.ReadAsAsync<BlueTelemetryModel>();

                        // add each entry to list for future testing
                        telemetryData.Add(telemetry);

                        // return the mapped data
                        return telemetry;
                    }
                    // else, unsuccessful response
                    else
                    {
                        // throw an exception (with reason) if response isn't succesful
                        throw new Exception(res.ReasonPhrase);
                    }

                    // close/dispose of port when done to avoid bad memory management
                }
            }
        }

        // create a class for getting telemetry data for json 
        // "vitals" 
        public class BlueTelemetryModel
        {
            // map telemetry stream json onto model properties 
            public DateTime timestamp { get; set; }
            public double heartrate { get; set; }
            public double oxygen { get; set; }
            public double temperature { get; set; }

        }
    }
}



