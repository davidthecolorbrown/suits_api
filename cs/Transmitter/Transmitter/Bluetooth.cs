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
                    PortName = "COM5"
                    //PortName = "/dev/cu.DSDTECHHC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                    //PortName = "dev/cu.HC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                };
                serialPort.Open();

                // 
                //int counter = 0;

                // save serial data 
                //double data = 0.0;
                var data = "0.0";
                //BlueTelemetryModel postVitals = new BlueTelemetryModel();
                BlueTelemetryModel postVitals = new BlueTelemetryModel
                {
                    heartrate = Convert.ToDouble(data),
                    oxygen = Convert.ToDouble(data),
                    temperature = Convert.ToDouble(data)
                };
                //_ = PostJsonHttpClient(postVitals);

                // while a serial port connection exists
                while (serialPort.IsOpen)
                {
                    // if serial port contains data, extract
                    while (serialPort.BytesToRead > 0)
                    {
                        //Console.Write(Convert.ToChar(serialPort.ReadChar()));
                        //Console.Write(serialPort.ReadChar());
                        //Console.Write(serialPort.ReadExisting());

                        // save data from serial port into variable and convert to string in format of double
                        data = serialPort.ReadExisting() + ".0";
                        //data = Convert.ToChar(serialPort.ReadChar());
                        //data = Convert.ToChar(serialPort.ReadChar());
                        //Console.Write(Convert.ToChar(serialPort.ReadLine()));
                        //Console.Write(Convert.ToChar(serialPort.ReadLine()));
                        //Console.WriteLine((double) data);
                        //Console.WriteLine(data);

                        //postVitals = { BlueTelemetryModel.temperature = data };
                        postVitals.temperature = Convert.ToDouble(data);
                        Console.WriteLine(postVitals.temperature);
                        _ = PostJsonHttpClient(postVitals);
                    }

                    // send to arduino through bluetooth comm
                    //serialPort.WriteLine("PC counter: " + (counter++));

                    // update ctr
                    //counter++;

                    // check serial port connection and buffer for data every second
                    Thread.Sleep(1000);

                    // if serial port closes, break loop
                }
            }

            //
            //public Bluetooth() { }

            //
            // constructor initializes serial comm and reads (as own thread) until broken
            public void InitSerialPort(Bluetooth btooth, string port, int baudrate)
            {
                //
                //PortName = "COM7"; // PortNameMac = "dev/cu.HC-05-DevB";
                //PortName = "dev/cu.HC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                // create a new serial port listener with given baud rate on given windows port
                SerialPort serialPort = new SerialPort
                {
                    //BaudRate = 9600,
                    BaudRate = baudrate,
                    PortName = port
                    //PortName = "/dev/cu.DSDTECHHC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                    //PortName = "dev/cu.HC-05-DevB"  // Set in Windows Settings->Bluetooth->More Bluetooth Settings->COM Ports (OUTGOING)
                };
                serialPort.Open();

                // print counter to terminal to troubleshoot
                //int counter = 0;

                // POST to server 
                //var postVitals = new BlueTelemetryModel
                //{
                    //heartrate = counter,
                    //oxygen = 60.0,
                    //temperature = 70.0
                //};
                //_ = PostJsonHttpClient(postVitals);

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

                    // update ctr
                    //counter++;

                    // check serial port connection and buffer for data every second
                    Thread.Sleep(1000);

                    // if serial port closes, break loop
                }
            }

            // send vitals as a json to mongoDB
            // from: https://www.stevejgordon.co.uk/sending-and-receiving-json-using-httpclient-with-system-net-http-json
            public static async Task PostJsonHttpClient(BlueTelemetryModel postVitals)
            {
                // get the initialized client
                HttpClient httpClient = Data.api;

                //
                //BlueTelemetryModel postVitals = new BlueTelemetryModel();

                // api post request url
                string url = "http://127.0.0.1:3002/api/vital";
                //string url = "http://127.0.0.1:3002/api/temp";
                //string url = "http://127.0.0.1:3002/api/oxygen";
                //string url = "http://127.0.0.1:3002/api/heartrate";

                Console.WriteLine("BLUETOOTH POST REQUEST: " + url);

                // send vital json and wait for response from server 
                var postResponse = await httpClient.PostAsJsonAsync(url, postVitals);

                // 
                postResponse.EnsureSuccessStatusCode();
            }


            // call this method to post dummy data to server
            public static void TestVitalsPost() 
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

                // post 4 random vital measurements to server
                while (counter < 64.0)
                {

                    // send to arduino through bluetooth comm
                    //serialPort.WriteLine("PC counter: " + (counter++));

                    // POST to server 
                    var postVitals = new BlueTelemetryModel
                    {
                        heartrate = counter,
                        oxygen = 60.0,
                        temperature = 70.0
                    };
                    _ = PostJsonHttpClient(postVitals);

                    // update ctr
                    counter++;

                    // check serial port connection and buffer for data every second
                    Thread.Sleep(1000);

                }
            }
        }
    }
}


