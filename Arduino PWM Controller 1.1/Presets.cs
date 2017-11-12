using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Arduino_PWM_Controller
{
    public partial class Presets : Form
    {
        static string arrayfiledir = System.Windows.Forms.Application.StartupPath + "\\data";
        static string arrayfile = arrayfiledir + "\\arrayfile.txt";
        static string[] data_array;
        static int intArraySize = 15;
        public static string[,] ImagingArray = new string[intArraySize + 1, 2];
        static TextBox[] txtDescription = new TextBox[15];
        static TextBox[] txtValue = new TextBox[15];
        public Presets()
        {
            InitializeComponent();
            txtDescription[0] = txtDescription1; txtValue[0] = txtValue1;
            txtDescription[1] = txtDescription2; txtValue[1] = txtValue2;
            txtDescription[2] = txtDescription3; txtValue[2] = txtValue3;
            txtDescription[3] = txtDescription4; txtValue[3] = txtValue4;
            txtDescription[4] = txtDescription5; txtValue[4] = txtValue5;
            txtDescription[5] = txtDescription6; txtValue[5] = txtValue6;
            txtDescription[6] = txtDescription7; txtValue[6] = txtValue7;
            txtDescription[7] = txtDescription8; txtValue[7] = txtValue8;
            txtDescription[8] = txtDescription9; txtValue[8] = txtValue9;
            txtDescription[9] = txtDescription10; txtValue[9] = txtValue10;
            txtDescription[10] = txtDescription11; txtValue[10] = txtValue11;
            txtDescription[11] = txtDescription12; txtValue[11] = txtValue12;
            txtDescription[12] = txtDescription13; txtValue[12] = txtValue13;
            txtDescription[13] = txtDescription14; txtValue[13] = txtValue14;
            txtDescription[14] = txtDescription15; txtValue[14] = txtValue15;
        }

        public static void FromFileToArray()
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

        public static void LoadFromArray()
        {
            //This subroutine takes the values from the array (ImagingArray) and uses the to
            //populate the various comboboxes and textboxes on the form.
            for (int i = 1; i <= intArraySize; i++)
            {
                txtDescription[i - 1].Text = ImagingArray[i - 1, 0];
                txtValue[i - 1].Text = ImagingArray[i - 1, 1];
            }
        }

        public void SaveToArray()
        {
            //Take the values from the table of textboxes and comboboxes 
            //and use them to populate an array (ImagingArray()).
            for (int i = 0; i <= intArraySize - 1; i++)
            {
                ImagingArray[i, 0] = txtDescription[i].Text;
                ImagingArray[i, 1] = txtValue[i].Text;
            }
        }

        public static void FromArrayToFile()
        {
            // This subroutine reads all values from the array (ImagingArray)
            // and writes it to the file (arrayfile.txt) in a csv format.
            // The File.Delete command zero's the file so that it's not appended to.
            if (File.Exists(arrayfile))
            {
                File.Delete(arrayfile);
            }

            using (StreamWriter objWriter = File.AppendText(arrayfile))
            {
                //Auto creates the file

                for (int i = 1; i <= intArraySize; i++)
                {
                    objWriter.Write(ImagingArray[i - 1, 0]);
                    objWriter.Write(",");
                    objWriter.Write(ImagingArray[i - 1, 1]);
                    objWriter.WriteLine();
                }
                objWriter.Close();
            }

        }

        private void Presets_Load(object sender, EventArgs e)
        {
            FromFileToArray();
            LoadFromArray();

            // Add the handlers for checking the Value format when leaving the textbox
            txtValue2.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue3.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue4.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue5.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue6.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue7.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue8.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue9.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue10.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue11.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue12.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue13.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue14.Leave += new System.EventHandler(txtValue1_Leave);
            txtValue15.Leave += new System.EventHandler(txtValue1_Leave);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            SaveToArray();
            FromArrayToFile();
            this.Close();
        }

        private void txtValue1_Leave(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.TextBox)sender).Text != "")
            {
                try
                {
                    int theValue = Int32.Parse(((System.Windows.Forms.TextBox)sender).Text);

                    if (theValue < 0 || theValue > 255)
                    {
                        MessageBox.Show("Value must be between 0 and 255");
                        ((System.Windows.Forms.TextBox)sender).Focus();
                    }
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Value must be numeric between 0 and 255");
                    ((System.Windows.Forms.TextBox)sender).Focus();
                }
            }
        }
    }
}
