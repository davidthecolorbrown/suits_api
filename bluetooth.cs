// Dependencies for web API
// Microsoft.AspNet.WebApi.Client (5.2.7)
// Newtonsoft.Json (12.0.3)

namespace SuitsUIConsole
{

    // SuitsUIConsole.Application (Program/App with main function, deals with configuration etc)
    namespace Application
    {
        // load modules
        using System;
        using System.Threading.Tasks;
        using System.Threading;

        // load project specific modules
        using SuitsUIConsole.Datastream;
        using SuitsUIConsole.Missions; 
        using SuitsUIConsole.Users;

        // loads json with app configuration
        //// SuitsUIConsole.Application
        //public class Configuration
        //{
        //    // configuration for application (move to json)
        //    //public static string abspath = "C:\\Users\\David\\Documents\\school\\eel4915 - senior design II\\project\\frontend\\NasaSuitsUI\\Assets\\Data\\astronaut.json";
        //    public static string config_path = "C:\\Users\\David\\Documents\\school\\eel4915 - senior design II\\project\\frontend\\NasaSuitsUI\\Assets\\Data\\config.json";
        //    //public static string m_path = "C:\\Users\\David\\Documents\\school\\eel4915 - senior design II\\project\\frontend\\NasaSuitsUI\\Assets\\Data\\test_data\\mission_test.json";
        //    //public static string a_path = "C:\\Users\\David\\Documents\\school\\eel4915 - senior design II\\project\\frontend\\NasaSuitsUI\\Assets\\Data\\test_data\\astronaut_test.json";

        //    // map each configuration/setting to key in json file
        //    public string USER { get; set; }
        //    public string ABSOLUTE_PATH { get; set; }
        //    public string FILE_WRITE_PATH { get; set; }
        //    public string ASTRONAUT_FILE { get; set; }
        //    public string MISSION_FILE { get; set; }
        //    public string TELEMETRY_FILE { get; set; }
        //    public string TELEMETRY_SIM_URL { get; set; }
        //    public string TELEMETRY_UIA_SIM_URL { get; set; }
        //    public bool RUN_TESTS { get; set; }

        //    // method for loading application config from config json
        //    public static Configuration LoadConfig()
        //    {
        //        // load app config from JSON file
        //        Configuration config = (Configuration) FileIO.loadConfigJSON(config_path);
                
        //        return config; 
        //    }

        //    // method for printing configuration in console
        //    public static void printConfig(Configuration config)
        //    {
        //        Console.WriteLine("USER: " + config.USER);
        //        Console.WriteLine("ABSOLUTE_PATH: " + config.ABSOLUTE_PATH);
        //        Console.WriteLine("FILE_WRITE_PATH: " + config.FILE_WRITE_PATH);
        //        Console.WriteLine("ASTRONAUT_FILE: " + config.ASTRONAUT_FILE);
        //        Console.WriteLine("MISSION_FILE: " + config.MISSION_FILE);
        //        Console.WriteLine("TELEMETRY_FILE: " + config.TELEMETRY_FILE);
        //        Console.WriteLine("TELEMETRY_SIM_URL: " + config.TELEMETRY_SIM_URL);
        //        Console.WriteLine("TELEMETRY_UIA_SIM_URL: " + config.TELEMETRY_UIA_SIM_URL);
        //        Console.WriteLine("RUN_TESTS: " + config.RUN_TESTS);
        //    }
        //}


        // Takes care of initializing and running backend program
        // SuitsUIConsole.Application
        public class Program
        {


            //
            //public static Configuration config;
            //public static Astronaut astronaut = new Astronaut();
            //public static MissionControl ctrl;

            public static async Task Main(string[] args)
            {

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~  MAIN() PROGRAM HAS STARTED  ~~~~~~");
                Console.WriteLine("~~~~~~     APPLICATION NAMESPACE    ~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
                Console.WriteLine();

                // load application configuration
                //config = Configuration.LoadConfig();
                //// troubleshoot to check loading of configuration
                //Configuration.printConfig(config);

                // load the astronaut and mission
                //astronaut = (Astronaut) OnAppStart(config);

                // connect to datastream (telemetry, bluetooth, etc)
                //Data.InitClient();
                //Data.InitBluetooth();
                //Data.InitWifi();
                Bluetooth data = new Bluetooth();
                //await Bluetooth.PostJsonHttpClient();

                // create new mission control object and pass astronaut 
                // mission control creates mission/astronaut and monitors vitals from telemetry stream
                //ctrl = new MissionControl(astronaut);

                //// troubleshooting to see if data loaded correctly
                //Console.WriteLine("New MissionControl astronaut: " + ctrl.ASTRONAUTS.Count);
                //// for each astronaut, print their notes in mission notebook 
                //for (int i = 0; i < ctrl.ASTRONAUTS.Count; i++)
                //{
                //    //Console.WriteLine("astronauts[" + i + "] - NAME: " + ctrl.ASTRONAUTS[i].FIRSTNAME + " " + ctrl.ASTRONAUTS[i].LASTNAME + " SUIT ID: " + ctrl.ASTRONAUTS[i].SUIT.ID);
                //    //Console.WriteLine("astronauts[" + i + "] - NAME: " + ctrl.ASTRONAUTS[i].FIRSTNAME + " " + ctrl.ASTRONAUTS[i].LASTNAME + " MISSION: " + ctrl.ASTRONAUTS[i].MISSION.TITLE + " SUIT ID: " + ctrl.ASTRONAUTS[i].SUIT.ID);

                //    for (int j = 0; j < ctrl.ASTRONAUTS[i].MISSION.NOTEBOOK.Count; j++)
                //    {
                //        //Console.WriteLine("notebook [{0}]: {1}", j, ctrl.ASTRONAUTS[i].MISSION.NOTEBOOK.ToString());
                //        Console.WriteLine("notebook [{0}]: {1}", j, ctrl.ASTRONAUTS[i].MISSION.NOTEBOOK[j].TITLE);
                //    }
                //}

                // check if astronaut is on mission (start mission clicked), if so, tell missionControl to monitor mission
                //if (astronaut.ONMISSION) { ctrl.MonitorVitals; }

                // run code if testing something
                var programRuntime = 2000;
                //if (config.RUN_TESTS)
                //{
                //    // use thread of X seconds allowing program to run for given amount of time, counting every second with timer 
                //    // lets mission control monitor mission until thread wakes up
                //    // when thread wakes up, program terminates
                //    Thread.Sleep(programRuntime);

                //    // set mission control connected to data == true
                //    ctrl.DATA_CONNECTED = true;
                //    Thread.Sleep(programRuntime);

                //    // save telemetry stream data to a json
                //    string telemetry_path = "C:\\Users\\David\\Documents\\school\\eel4915 - senior design II\\project\\frontend\\NasaSuitsUI\\Assets\\Data\\test_data\\telemetry_unsafe.json";
                //    //string telemetry_path = "C:\\Users\\David\\Documents\\school\\eel4915 - senior design II\\project\\frontend\\NasaSuitsUI\\Assets\\Data\\test_data\\telemetry_safe.json";
                //    FileIO.SaveTelemetryJSON(Telemetry.telemetryData, telemetry_path, true);
                //}
                //else { Thread.Sleep(programRuntime); }


                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~ MAIN() PROGRAM HAS ENDED ~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }

            // start() or startMission or LoadAstronaut()
            // when application starts, load config/astronaut/mission data 
            // startMission()
            //public static Object OnAppStart(Configuration config)
            //{
            //    Console.WriteLine("...OnAppStart() RUNNING...");
            //    Console.WriteLine("...LOADING Astronaut   ...");
            //    Console.WriteLine("...LOADING Mission     ...");

            //    // load astronaut data 
            //    Astronaut astro = new Astronaut();
            //    //astro = (Astronaut)FileIO.loadAstronautJSON(config.ASTRONAUT_FILE);
            //    //Console.WriteLine("astro.FIRSTNAME: " + astro.FIRSTNAME);//.FIRSTNAME);

            //    // load mission data 
            //    // save the mission data to astronaut 
            //    //astro.MISSION = (Mission)FileIO.loadMissionJSON(config.MISSION_FILE);
            //    //Console.WriteLine("mission title: " + astro.MISSION.TITLE);

            //    // save updated notebook to json 
            //    Mission newNotebook = new Mission("Test Mission");
            //    FileIO.SaveJSONFile(newNotebook, config.MISSION_FILE, false);
            //    Console.WriteLine(newNotebook.TITLE);
            //    //Console.WriteLine(newNotebook.INSTRUCTIONS[0]);
            //    Console.WriteLine(newNotebook.NOTEBOOK);

            //    //
            //    //astro.MISSION.NOTEBOOK = newNotebook.NOTEBOOK;
            //    //FileIO.SaveJSONFile(newNotebook, config.ASTRONAUT_FILE, false);

            //    // return astronaut with mission 
            //    return astro;

            //}

            // called when application quits to save objects to json and kill all threads
            //public static void OnAppQuit() { }


        }
    }

        // SuitsUI.Datastream
    namespace Datastream
    {
        // SuitsUI.Datastream
        using System;
        //using System.Collections.Generic;
        //using System.Text;
        using System.Threading.Tasks;
        using System.Net.Http; // import HttpClient class 
        using System.Net.Http.Formatting;

        // for FileIO
        using System.IO;
        using Newtonsoft.Json;
        //using System.Net;
        using Newtonsoft.Json.Linq;
        using SuitsUIConsole.Users;
        using SuitsUIConsole.Missions;
        using System.Collections.Generic;
        using SuitsUIConsole.Application;

        // for Bluetooth
        //using System.Collections.Generic;
        //using System.IO.Ports;
        //using System.Linq;
        //using System.Text;
        using System.Threading;
        using System.IO.Ports;

        // for camera
        //using System;
        //using System.Collections.Generic;
        using System.Text;
        using Emgu.CV;
        using Emgu.CV.Structure;
        using Emgu.CV.CvEnum;
        using Emgu.CV.UI;
        using Emgu.CV.Plot;
        //using Emgu.Util.UnmanagedObject.Capture;
        //using System.Threading;
        using System.Drawing;
        using System.Drawing.Imaging;
        using System.Runtime.InteropServices;


        // class for interacting with NASA SUITS database (mongoDB)
        public static class Data
        {
            // create new http client for api with single api client (thread-safe)
            public static HttpClient api { get; set; }
            // TODO: get/set the base api address 

            // initialize client for streaming data through api 
            public static void InitClient()
            {
                // create new api client and initialize 
                api = new HttpClient();

                // set base addresss
                //api.BaseAddress = new Uri("https://localhost:3000/api/simulation/state");

                // clear header
                api.DefaultRequestHeaders.Accept.Clear();

                // add header telling client to give json 
                api.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        // load json object 
        public static class BlueTelemetry
        {
            // allows us to know range of values (min, max) for each json object key/value pair
            // TODO: probably should be moved to avoid Task() calls and cross threading
            //public int MaxTelemetryTime { get; set; }

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
                    // set api url to obtain recent DCU/UIA data
                    //url = base_url + "api/simulation/uiastate";
                    url = $"{ base_url }api/simulation/uiastate";
                    Console.WriteLine("url: " + url);
                }
                else
                {
                    // set api url to obtain recent suit data
                    url = base_url + "api/simulation/state";
                    //url = $"{ base_url }api/simulation/state";
                    //Console.WriteLine("url: " + url);
                }

                // new request using a single open api client and gets this as response
                using (HttpResponseMessage res = await Data.api.GetAsync(url))
                {
                    // if response is successful, read back data
                    if (res.IsSuccessStatusCode)
                    {
                        //
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

        //
        public class Bluetooth
        {
            //
            //public static SerialPort serialPort = new SerialPort();
            public SerialPort serialPort { get; set; }
            public int baud_rate { get; set; }
            public string port_name { get; set; }
            public bool connected { get; set; }

            // constructor initializes serial comm and reads (as own thread) until broken
            public Bluetooth()
            {
                ///dev/cu.HC-05-DevB
                /////PortName = "COM7"
                // create a new serial port listener with given baud rate on given windows port
                SerialPort serialPort = new SerialPort
                {
                    BaudRate = 9600,
                    PortName = "dev/cu.HC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                };
                serialPort.Open();

                // 
                int counter = 0;

                // while a serial port connection exists
                while (serialPort.IsOpen)
                {
                    // if serial port contains data, extract
                    while (serialPort.BytesToRead > 0)
                    {
                        Console.Write(Convert.ToChar(serialPort.ReadChar()));
                    }

                    // send to arduino through bluetooth comm
                    //serialPort.WriteLine("PC counter: " + (counter++));

                    // check serial port connection and buffer for data every second
                    Thread.Sleep(1000);

                    // if serial port closes, break loop
                }
            }

            // send vitals as a json to mongoDB
            // from: https://www.stevejgordon.co.uk/sending-and-receiving-json-using-httpclient-with-system-net-http-json
            //public static async Task PostJsonHttpClient(string uri, HttpClient httpClient)
            public static async Task PostJsonHttpClient()
            {
                // 
                HttpClient httpClient = Data.api;

                // api post request url
                string url = "http://localhost:3002/api/event";
                //string url = "http://127.0.0.1:3002/api/vital";
                //string url = "http://127.0.0.1:3002/api/temp";
                //string url = "http://127.0.0.1:3002/api/oxygen";
                //string url = "http://127.0.0.1:3002/api/heartrate";

                //
                var postVitals = new TelemetryModel { HEART_BPM = 60 };

                //
                var postResponse = await httpClient.PostAsJsonAsync(url, postVitals);

                //
                postResponse.EnsureSuccessStatusCode();
            }
        }
    }
}


