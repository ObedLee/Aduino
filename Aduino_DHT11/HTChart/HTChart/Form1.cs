using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CSUtil;

namespace HTChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Threading.Timer timer;
        SerialCom serialCom = new SerialCom();
        delegate void TimerEventDelegate();

        string hum, tem;

        private void Form1_Load(object sender, EventArgs e)
        {
            serialCom.SetSerialPort(serialPort1);
            serialCom.OpenSerialPort(serialPort1);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;

            serialPort1.ReadExisting();

            timer = new System.Threading.Timer(TimerCallback);
            timer.Change(500, 2500);
        }

        private void TimerCallback(object status)
        {
            BeginInvoke(new TimerEventDelegate(fGetTemHum));
        }

        private void fGetTemHum()
        {
            string data = serialPort1.ReadLine();
            hum = data.Substring(0, 6);
            tem = data.Substring(18);

            lbHum.Text = hum;
            lbTem.Text = tem;


            fDrawChart(float.Parse(hum.Substring(0,4)), float.Parse(tem.Substring(0,4)));
        }


        private void fDrawChart(float hum, float tem)
        {
            chart1.Series[0].Points.AddY(tem);
            chart1.Series[1].Points.AddY(hum);

            if (chart1.Series[0].Points.Count > 100)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }

            if (chart1.Series[1].Points.Count > 100)
            {
                chart1.Series[1].Points.RemoveAt(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Dispose();

            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
