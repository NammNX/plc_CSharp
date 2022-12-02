using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Profinet.Melsec;
using HslCommunication;


namespace PLC_CSharp
{

    public partial class Form1 : Form
    {
        MelsecFxSerial melsecFx = new MelsecFxSerial();

        public Form1()
        {
            InitializeComponent();

            melsecFx.SerialPortInni(sp =>
            {
                sp.PortName = "COM4";
                sp.BaudRate = 38400;
                sp.DataBits = 7;
                sp.StopBits = System.IO.Ports.StopBits.One;
                sp.Parity = System.IO.Ports.Parity.Even;
            });

        }

          
        private void btnConnect_Click(object sender, EventArgs e)
        {

            
            
            melsecFx.Open();
            bool b = melsecFx.IsOpen();
            



            Console.WriteLine($"isopen = {b}"); 
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            melsecFx.Close();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {

            bool b = melsecFx.IsOpen();

            Console.WriteLine($"isopen = {b}");

            short short_D100 = melsecFx.ReadInt16("D100").Content;   

            Console.WriteLine($"D100 = {short_D100}");

            bool X1 = melsecFx.ReadBool("X1").Content;

            Console.WriteLine($"X1 = {X1}");

            bool M500 = melsecFx.ReadBool("M500").Content;

            Console.WriteLine($"M500 = {M500}");
            bool Y0 = melsecFx.ReadBool("Y0").Content;

            Console.WriteLine($"Y0 = {Y0}");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            

        }

        
    }
}
