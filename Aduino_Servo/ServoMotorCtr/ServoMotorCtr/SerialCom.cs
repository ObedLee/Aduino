using System;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace CSUtil
{
    public class SerialCom
    {

        private const char CR = (char)0x0D;
        private const char LF = (char)0x0A;

        private string inStream;

        public void SetSerialPort(SerialPort serialPort)
        {
            try
            {
                string str = File.ReadAllText(@"config.ini").Replace("\n", String.Empty);
                string[] setting = str.Split(',');


                for (int i = 0; i < setting.Length; i++)
                {
                    if (setting[i].Split('=')[0] == "PortName")
                        serialPort.PortName = setting[i].Split('=')[1];

                    else if (setting[i].Split('=')[0] == "BaudRate")
                        serialPort.BaudRate = Int32.Parse(setting[i].Split('=')[1]);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
        }

        public void OpenSerialPort(SerialPort serialPort)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void CloseSerialPort(SerialPort serialPort)
        {
            try
            {
                serialPort.ReadExisting();
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
        }


        public string ReceiveSerialData(SerialPort serialPort, char stx)
        {
            string inData = serialPort.ReadExisting();
            char[] arr = inData.ToCharArray();

            if (arr.Length <= 0) return null;

            if (arr[0] == stx)
                inStream = inData;
            else
                inStream += inData;

            string[] splited = inStream.Split(LF);
            foreach (string s in splited)
            {

                char[] arr2 = s.ToCharArray();

                if (arr2.Length <= 0) continue;

                int etxIndex = Array.IndexOf(arr2, CR);
                if (etxIndex <= 0) continue;

                //etxIndex = Array.IndexOf(arr2, LF);
                //if (etxIndex <= 0) continue;

                char[] arr3 = arr2.SubArray(0, etxIndex);
                string cmd = new string(arr3);

                return cmd;
            }

            return null;
        }

        public string SendSerialData(SerialPort serialPort, string data)
        {
            byte[] outData = CSUtil.Str16ToByte(data);

            if (serialPort.IsOpen)
            {
                serialPort.Write(outData, 0, outData.Length);
            }
            else
            {
                OpenSerialPort(serialPort);
                SendSerialData(serialPort, data);
            }

            return Encoding.Default.GetString(outData);
        }

        public string SendSerialData(SerialPort serialPort, byte[] outData)
        {

            if (serialPort.IsOpen)
            {
                serialPort.Write(outData, 0, outData.Length);
            }
            else
            {
                OpenSerialPort(serialPort);
                SendSerialData(serialPort, outData);
            }

            return Encoding.Default.GetString(outData);
        }


    }
}
