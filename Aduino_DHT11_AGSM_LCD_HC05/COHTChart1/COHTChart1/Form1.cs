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

namespace COHTChart1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialCom serial = new SerialCom();

        System.Threading.Timer timer;

        delegate void TimerEventDelegate();

        private void chartInit()
        {
            chart1.Series[0].Name = "CO";
            chart1.Series[1].Name = "Hum";
            chart1.Series[2].Name = "Tem";

            //chart1.ChartAreas[0].AxisY.Minimum = 0;
            //chart1.ChartAreas[0].AxisY.Maximum = 1000;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 60;

            //chart1.ChartAreas[1].AxisY.Minimum = 0;
            //chart1.ChartAreas[1].AxisY.Maximum = 100;
            chart1.ChartAreas[1].AxisX.Minimum = 0;
            chart1.ChartAreas[1].AxisX.Maximum = 60;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial.SetSerialPort(serialPort1);
            serial.OpenSerialPort(serialPort1);

            chartInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.ReadExisting();

            timer = new System.Threading.Timer(TimerCallback);
            timer.Change(0, 1000);
        }


        private void TimerCallback(object status)
        {
            BeginInvoke(new TimerEventDelegate(fGetCOHT));
        }

        private void fGetCOHT()
        {
            string[] data;

            string text = null;

            data = serialPort1.ReadExisting().Replace("\r\n", "").Split(',');


            if (data.Length == 3)
            {


                text += data[0] + "PPB, ";
                text += data[1] + "%, ";
                text += data[2] + "C \r\n";

                COLab.Text = data[0] + "PPB";
                HumLab.Text = data[1] + "%";
                TemLab.Text = data[2] + "C";

                tbLog.Text += text;

                chart1.Series[0].Points.AddY(data[0]);
                chart1.Series[1].Points.AddY(data[1]);
                chart1.Series[2].Points.AddY(data[2]);

                if (chart1.Series[0].Points.Count > 60)
                {
                    chart1.Series[0].Points.RemoveAt(0);
                }

                if (chart1.Series[1].Points.Count > 60)
                {
                    chart1.Series[1].Points.RemoveAt(0);
                }
                if (chart1.Series[2].Points.Count > 60)
                {
                    chart1.Series[2].Points.RemoveAt(0);
                }
            }






        }
    }
}
