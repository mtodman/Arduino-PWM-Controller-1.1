// Arduino PWM Controller
// Version 1.1
// - Added Registry Entry to save previous Comm Port settings
// - Set DialogueResult = OK when exiting with save from the Presets form
// - Added sendtoArduino() routine after a preset has been selected (only if connected = true)
//
// Works with Arduino sketch "PWM_Controller_0_2.pde"
//
// Communicates with an Arduino to send a variable PWM rate to an external device (motor / light globe)
//
// Matt Todman
// 5th August, 2011
// http://www.mattsastro.com
//



using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Arduino_PWM_Controller
{
    public partial class Form1 : Form
    {

        const byte HELLO = 199; //199 tells the Arduino that this is a comms test. respond with "#" (byte = 33)

        int pwmReturnValue;
        byte pwmValue = 0;
        bool connected = false;

        static string arrayfiledir = System.Windows.Forms.Application.StartupPath + "\\data";
        static string arrayfile = arrayfiledir + "\\arrayfile.txt";
        static string[] data_array;
        static int intArraySize = 15;
        public static string[,] ImagingArray = new string[intArraySize + 1, 2];

        ModifyRegistry myRegistry = new ModifyRegistry();
        string COMM_PORT;

        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists(arrayfiledir))
            {
                DirectoryInfo D = Directory.CreateDirectory(arrayfiledir);

            }
            if (!File.Exists(arrayfile))
            {
                System.IO.FileStream F = System.IO.File.Create(arrayfile);
                F.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            COMM_PORT = myRegistry.Read("COMM_PORT");

            PopulateCommPorts();


            btnConnect.BackColor = Color.Red;
            hScrollBar1.Enabled = false;
            FromFileToArray();
            PopulateComboBox();
        }

        private void PopulateCommPorts()
        {
            foreach (string str in SerialPort.GetPortNames())
            {
                this.cmbComm.Items.Add(str);
                if (str == COMM_PORT)
                {
                    this.cmbComm.Text = COMM_PORT;
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            switch (connected)
            {
                case true: //Already connected to the Arduino so now disconnect
                    {
                        pwmValue = 0;
                        SendToArduino();
                        m_serial.Close();
                        connected = false;
                        btnConnect.Text = "Connect";
                        btnConnect.BackColor = Color.Red;
                        hScrollBar1.Value = 1;
                        hScrollBar1.Enabled = false;
                        lblPWMValue.Text = "1";
                        cmbComm.Enabled = true;
                        break;
                    }

                case false: //Not yet connected to the Arduino so try to connect
                    {
                        COMM_PORT = cmbComm.Text;
                        //myRegistry.Write("COMM_PORT", COMM_PORT);
                        m_serial.PortName = COMM_PORT;
                        m_serial.BaudRate = 9600;
                        m_serial.ReadTimeout = 2000;
                        m_serial.WriteTimeout = 2000;
                        m_serial.Open();
                        if (ConnectToArduino(HELLO) == 35)
                        {
                            // Success
                            myRegistry.Write("COMM_PORT", COMM_PORT);
                            connected = true;
                            btnConnect.Text = "Disconnect";
                            btnConnect.BackColor = Color.Green;
                            hScrollBar1.Enabled = true;
                            lblPWMValue.Text = hScrollBar1.Value.ToString();
                            cmbComm.Enabled = false;
                            SendToArduino();
                        }
                        else
                        {
                            //failure
                            m_serial.Close();
                            //throw new Exception("Connection to Arduino Focuser failed.");
                        }
                        break;
                    }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pwmValue = (byte)hScrollBar1.Value;
            lblPWMValue.Text = hScrollBar1.Value.ToString();
            SendToArduino();
        }

        void SendToArduino()
        {
            byte[] pwm = new byte[1];
            pwm[0] = (byte)(pwmValue);
            m_serial.Write(pwm, 0, pwm.Length);

            try
            {
                pwmReturnValue = m_serial.ReadByte();
                if (pwmReturnValue != 33)
                {
                    MessageBox.Show("Didn't receive correct response from Arduino");
                }
            }
            catch (System.TimeoutException)
            {
                MessageBox.Show("Didn't receive any response from the Arduino");
            }
        }

        int ConnectToArduino(byte cmd)
        {
            int response = 0;
            byte[] data = new byte[1];
            data[0] = (cmd);
            m_serial.Write(data, 0, data.Length);

            try
            {
                response = m_serial.ReadByte();
            }
            catch (System.TimeoutException ex)
            {
                MessageBox.Show("Didn't receive any response from the Arduino");
            }
            return response;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                pwmValue = 0;
                SendToArduino();
                m_serial.Close();
                m_serial.Dispose();
            }
            this.Close();
        }

        private void btnPresets_Click(object sender, EventArgs e)
        {
            Form presets = new Presets();
            if (presets.ShowDialog() == DialogResult.OK)
            {
                cmbPresets.Items.Clear();
                FromFileToArray();
                PopulateComboBox();
            }
        }


        public void FromFileToArray()
        {
            // This subroutine reads all values from the file (arrayfile.txt) in a csv format
            // and writes it to the array (ImagingArray).
            if (File.Exists(arrayfile))
            {
                int linecount = 0;
                StreamReader oRead = new StreamReader(arrayfile);
                while (!oRead.EndOfStream)
                {
                    string line = oRead.ReadLine();
                    data_array = line.Split(new char[] { ',' });
                    for (int i = 0; i <= data_array.Length - 1; i++)
                    {
                        ImagingArray[linecount, i] = data_array[i];
                    }
                    linecount += 1;
                }
                oRead.Close();
            }
        }

        public void PopulateComboBox()
        {
            //This subroutine takes the values from the array (ImagingArray) and uses the to
            //populate the Preset combobox on the form.
            for (int i = 1; i <= intArraySize; i++)
            {
                if (!(ImagingArray[i - 1, 0] == null))
                    cmbPresets.Items.Add(ImagingArray[i - 1, 0]);
            }
        }

        private void cmbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= intArraySize; i++)
            {
                if (cmbPresets.Text == ImagingArray[i - 1, 0])
                {
                    string pwm = ImagingArray[i - 1, 1];
                    lblPWMValue.Text = pwm;
                    pwmValue = (byte)Int32.Parse(pwm);
                    hScrollBar1.Value = pwmValue;
                }
            }
            if (this.connected) SendToArduino();
        }
    }
}
