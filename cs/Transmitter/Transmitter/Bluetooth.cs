using System;
using System.Threading.Tasks;
using System.Net.Http; // import HttpClient class 
using System.Net.Http.Formatting;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// for Bluetooth
//using System.Collections.Generic;
//using System.IO.Ports;
//using System.Linq;
//using System.Text;
using System.Threading;
using System.IO.Ports;

//
namespace Trasmitter
{
    namespace Datastream
    {

        //
        public class Bluetooth
        {
            //
            //public static SerialPort serialPort = new SerialPort();
            //public SerialPort serialPort { get; set; }
            //public int baudrate { get; set; }
            //public string portname { get; set; }
            //public bool connected { get; set; }

            // constructor initializes serial comm and reads (as own thread) until broken
            public Bluetooth()
            {
                //
                //PortName = "COM7"; // PortNameMac = "dev/cu.HC-05-DevB";
                //PortName = "dev/cu.HC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                // create a new serial port listener with given baud rate on given windows port
                SerialPort serialPort = new SerialPort
                {
                    BaudRate = 9600,
                    PortName = "/dev/cu.DSDTECHHC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                    //PortName = "dev/cu.HC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                };
                serialPort.Open();

                // 
                double counter = 60.0;

                // while a serial port connection exists
                //while (counter < 64.0)
                while (serialPort.IsOpen)
                {
                    // if serial port contains data, extract
                    while (serialPort.BytesToRead > 0)
                    {
                        Console.Write(Convert.ToChar(serialPort.ReadChar()));
                    }

                    // send to arduino through bluetooth comm
                    serialPort.WriteLine("PC counter: " + (counter++));

                    // POST to server 
                    //var postVitals = new BlueTelemetryModel
                    //{
                        //heartrate = counter,
                        //oxygen = 60.0,
                        //temperature = 70.0
                    //};
                    //_ = PostJsonHttpClient(postVitals);

                    // update ctr
                    counter++;

                    // check serial port connection and buffer for data every second
                    //Thread.Sleep(1000);
                    Thread.Sleep(100);

                    // if serial port closes, break loop
                }
            }

            // send vitals as a json to mongoDB
            // from: https://www.stevejgordon.co.uk/sending-and-receiving-json-using-httpclient-with-system-net-http-json
            //public static async Task PostJsonHttpClient(string uri, HttpClient httpClient)
            //public static async Task PostJsonHttpClient()
            public static async Task PostJsonHttpClient(BlueTelemetryModel postVitals)
            {
                // get 
                HttpClient httpClient = Data.api;

                // api post request url

                //string url = "http://localhost:3002/api/event";
                string url = "http://127.0.0.1:3002/api/vital";

                //string url = "http://127.0.0.1:3002/api/temp";
                //string url = "http://127.0.0.1:3002/api/oxygen";
                //string url = "http://127.0.0.1:3002/api/heartrate";

                Console.WriteLine("BLUETOOTH POST REQUEST" + url);

                // post request to server for "vitals"
                //var postVitals = new BlueTelemetryModel{ HEART_BPM = 60 };
                //var postVitals = new BlueTelemetryModel {
                    //heartrate = 60.0,
                    //oxygen = 60.0,
                    //temperature = 70.0
                //};

                //
                var postResponse = await httpClient.PostAsJsonAsync(url, postVitals);

                //
                postResponse.EnsureSuccessStatusCode();
            }
        }
    }
}


