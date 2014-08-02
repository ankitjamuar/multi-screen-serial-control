using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using AxAXVLC;
using AXVLC;
using System.Threading;



namespace _candid_bump
{
    public partial class Form1 : Form
    {

        static SerialPort serial;
        String temp = "";

        Form screen1, screen2, screen3, screen4, screen5, screen6, screen7, screen8;
        AxVLCPlugin2 vlc1, vlc2, vlc3, vlc4, vlc5, vlc6, vlc7, vlc8;
       

        public Form1()
        {
            InitializeComponent();
            
        }

       

        private void Form1_Load_1(object sender, EventArgs e)
        {

           

            
            
          
        }

        

        public void init()
        {

           
         
            serial = new SerialPort("COM32", 9600, Parity.None, 8, StopBits.One)
            {
                Handshake = Handshake.None
            };

            serial.DataReceived += SerialPortdataReceived;
            serial.Open();
            
        }

        private void SerialPortdataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string tempData = sp.ReadLine();

           

            String[] indataArray = tempData.Split('@');
            
            foreach(String indata in indataArray)
            {

                if (temp != indata && indata.Length == 5)
                {
                    //NEW DATA
                    Console.Write(indata+ "  ");
                    temp = indata;

                    String[] _indata = indata.Split('_'); // 1_HIG  OR  1_LOW

                    if (_indata[1] == "HIG")
                    {
                        Console.WriteLine("Playing Screen " + _indata[0]);
                       
                        play(returnPluginScreen(_indata[0]));
                    }
                    if (_indata[1] == "LOW")
                    {
                        Console.WriteLine("Stopping Screen " + _indata[0]);
                        stop(returnPluginScreen(_indata[0]));
                    }
                
                } 

            }
            Array.Clear(indataArray, 0, indataArray.Length);
            Console.WriteLine("/===============================/");
             
            
            
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            screen1 = new Form(); 
            vlc1 = new AxVLCPlugin2();
            screen1.Controls.Add(vlc1);
            screen1.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc1.playlist.add(convertedURI);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            screen2 = new Form();
            vlc2 = new AxVLCPlugin2();
            screen2.Controls.Add(vlc2);
            screen2.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc2.playlist.add(convertedURI);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            screen3 = new Form();
            vlc3 = new AxVLCPlugin2();
            screen3.Controls.Add(vlc3);
            screen3.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc3.playlist.add(convertedURI);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            screen4 = new Form();
            vlc4 = new AxVLCPlugin2();
            screen4.Controls.Add(vlc4);
            screen4.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc4.playlist.add(convertedURI);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            screen5 = new Form();
            vlc5 = new AxVLCPlugin2();
            screen5.Controls.Add(vlc5);
            screen5.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc5.playlist.add(convertedURI);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            screen6 = new Form();
            vlc6 = new AxVLCPlugin2();
            screen6.Controls.Add(vlc6);
            screen6.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc6.playlist.add(convertedURI);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            screen7 = new Form();
            vlc7 = new AxVLCPlugin2();
            screen7.Controls.Add(vlc7);
            screen7.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc7.playlist.add(convertedURI);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            screen8 = new Form();
            vlc8 = new AxVLCPlugin2();
            screen8.Controls.Add(vlc8);
            screen8.Show();
            var uri = new Uri(@"F:\videos\SEASONS\How I Met Your Mother\Season 1-5 Bloopers.FLV");
            var convertedURI = uri.AbsoluteUri;
            vlc8.playlist.add(convertedURI);

            Thread thread = new Thread(new ThreadStart(init));
            thread.Start();

        }


        public void play(AxVLCPlugin2 screen)
        {
            if (!screen.playlist.isPlaying)
                screen.playlist.play();


        }




        public void stop(AxVLCPlugin2 screen)
        {
            if (screen.playlist.isPlaying && screen.Created)
                screen.playlist.stop();

        }

        public AxVLCPlugin2 returnPluginScreen(String screen)
        {
            switch (screen)
            {
                case "1":
                    return vlc1;
                case "2":
                    return vlc2;
                case "3":
                    return vlc3;
                case "4":
                    return vlc4;
                case "5":
                    return vlc5;
                case "6":
                    return vlc6;
                case "7":
                    return vlc7;
                case "8":
                    return vlc8;
                default:
                    return vlc1;
            }
        }

        
       
    }
}
