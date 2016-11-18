using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
//using FtdAdapter;
using Modbus.Data;
using Modbus.Device;
using Modbus.Utility;

namespace _570i_Modbus_Tester
{
    public partial class Form1 : Form
    {
        public static void ModbusSerialRtuMasterWriteRegisters(string baudBaud)
        {
           
            //MessageBox.Show(baudBaud);
            using (SerialPort port = new SerialPort(baudBaud))
            {
                // configure serial port
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = Parity.Even;
                port.StopBits = StopBits.One;
                port.Open();

                // create modbus master
                IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);

                //ushort[] ReadHoldingRegisters(
                byte slaveId = 1;
                ushort startAddress = 60;
                ushort value = 500;
                master.WriteSingleRegister(slaveId, startAddress, value);
            }  

        }   
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string whif = comboBox1.Text;
            ModbusSerialRtuMasterWriteRegisters(whif);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
         }
        
    }
}
