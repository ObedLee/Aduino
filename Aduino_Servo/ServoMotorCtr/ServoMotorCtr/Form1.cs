using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSUtil;

namespace ServoMotorCtr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void TimerEventDelegate();

        System.Threading.Timer timer;
        SerialCom serial = new SerialCom();


        private void TimerCallback(object obj)
        {
            BeginInvoke(new TimerEventDelegate(fCheckSerialPortState));
        }

        private void fCheckSerialPortState()
        {
            if (serialPort1.IsOpen)
            {
                btnCon.BackColor = Color.Gray;
                btnCon.Enabled = false;
                btnDiscon.BackColor = Color.Lime;
                btnDiscon.Enabled = true;
            }
            else
            {
                btnDiscon.BackColor = Color.Gray;
                btnDiscon.Enabled = false;
                btnCon.BackColor = Color.Lime;
                btnCon.Enabled = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer(TimerCallback);
            timer.Change(0, 500);
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial.SetSerialPort(serialPort1);
                serial.OpenSerialPort(serialPort1);
            }
        }

        private void btnDiscon_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serial.CloseSerialPort(serialPort1);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {


            if (serialPort1.IsOpen)
            {
                if (int.Parse(tbAngle.Text) > 180)
                {
                    tbAngle.Text = "180";
                }

                byte[] send = new byte[2];
                send[0] = (byte)(int.Parse(tbSpeed.Text));
                send[1] = (byte)(int.Parse(tbAngle.Text));

                serialPort1.Write(send, 0, 2);
            }

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            BeginInvoke(new EventHandler(fRecieveData));
        }

        private void fRecieveData(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string log = "";
                byte[] recv = new byte[2];
                serialPort1.Read(recv, 0, 2);
                log = "Speed: " + recv[0] + ", Angle: " + recv[1] + "\r\n";
                tbLog.Text += log;
            }
        }


    }
}
