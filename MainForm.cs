using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;
using System.Media;
namespace OBDII_SerialTest
{
    public partial class MainForm : Form
    {
        public string lastCommand = "";
        public bool elmReady = true;
        public bool ignition = false;
        public bool dataflow = true;
        public string protocol, device;
        
        public List<string> commandBuffer = new List<string>();
        public MainForm()
        {
            InitializeComponent();            
        }

        private string HexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        #region - UI -

        private void commOpenBTN_Click(object sender, EventArgs e)
        {            
            try
            {
               updateClockText(DateTime.Now.ToShortTimeString());
               open();
            }
            catch { }
        }

      
        private void commCloseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                closeport();
            }
            catch { }
        }

     
        #endregion

        #region - Set Up Connection -
            
        public bool open()
        {
            serialELM.PortName = comboPORT.Text.ToString();
            serialELM.BaudRate = Convert.ToInt32(comboBAUD.Text.ToString());
            serialELM.Handshake = Handshake.None;
            serialELM.DataBits = 8;
            serialELM.Parity = Parity.None;
            serialELM.StopBits =StopBits.One;
            serialELM.ReadTimeout =Convert.ToInt32(txt_readtimeout.Text);           
            rxtxTB.Text = "";
            serialELM.Close();
            //Check if a ELM327  is connected to any port.

                        updateLabelText("Trying " + serialELM.PortName.ToString());
                        Application.DoEvents();
                        serialELM.Close();                        
                        try
                        {
                            serialELM.Open();                            
                        }
                        catch (Exception err)
                        {
                            updateLabelText(err.ToString());
                        }                        
                        if (serialELM.IsOpen)
                        {
                            try
                            {
                                //"ATPP0CS23" 115200 KB
                                //ATPP0CON
                                //ATZ

                                serialELM.Write("ATZ\r");    //Reset all                            
                                serialELM.ReadTo(">");                               
                                serialELM.Write("ATL0\r");   //Linefeeds OFF                           
                                serialELM.ReadTo(">");
                                serialELM.Write("ATE0\r");   //Echo off                           
                                serialELM.ReadTo(">");
                                serialELM.Write("ATSPA5\r");
                                serialELM.ReadTo(">");                               
                                serialELM.Write("ATST10\r");//(40 MS TIMEOUT)
                                serialELM.ReadTo(">");
                                serialELM.Write("ATAT1\r");
                                serialELM.ReadTo(">");
                                serialELM.Write("ATI\r");    //Print version                            
                                string answer = serialELM.ReadTo(">");
                                if (answer.StartsWith("ELM327"))
                                {
                                    serialELM.Write("ATDP\r");                          
                                    protocol = serialELM.ReadTo(">").Trim();
                                    device = answer.ToString().Trim();
                                    txt_protocol.Text = "PROTOCOL: " + protocol.ToString() + "  -- INTERFACE: " + device.ToString();
                                    elmCommand("ATRV");
                                    Application.DoEvents();
                                    if (checkBatt.Checked == true)
                                    {
                                        batttimer.Enabled = true;
                                        timer_clock.Enabled = false;
                                    }
                                    else
                                    {
                                        elmTimer.Enabled = true;
                                        FastTimer.Enabled = true;
                                        timer_clock.Enabled = false;
                                    }
                                    ignition = true;
                                    playWarning(1);
                                    return true;
                                }
                                else
                                {
                                    closeport();
                                    return true;
                                }
                            }
                            catch (Exception err)
                            {
                                updateLabelText(err.ToString());
                            }   
                           
                        } 
                                                  
                            updateLabelText("ELM327 not found");
                            Application.DoEvents();
                            closeport();
                            return false;           
        }
        public void closeport()
        {
            try
            {
                if (serialELM.IsOpen)
                {
                    serialELM.DiscardInBuffer();
                    serialELM.DiscardOutBuffer();
                    serialELM.Close();
                    elmTimer.Enabled = false;
                    FastTimer.Enabled = false;
                    batttimer.Enabled = false;
                    timer_clock.Enabled = true;
                    updateLabelText(serialELM.PortName.ToString() + " Closed.");
                    txt_protocol.Text = "";
                    pic_batt.Visible = false;
                    pic_oil.Visible = false;
                    elmReady = true;
                    ignition = false;
                    dataflow = false;
                }
                else
                    updateLabelText("ERROR: Port not open.");
            }
            catch (Exception err)
            {
                updateLabelText(err.ToString());
                Application.DoEvents();
            }    
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialELM.IsOpen)
            {
                serialELM.Close();               
            }
            timer_clock.Enabled = false;
        }

       
        
        #endregion

        #region - Message Handling -    
               
        private void elmTimer_Tick(object sender, EventArgs e)
        {                    
                try
                {
                    if (serialELM.IsOpen & elmReady == true)
                    {
                        
                        elmReady = false;
                        serialELM.Write("010C1\r" + Environment.NewLine);                       
                     }    
                                
                }
                catch (Exception err)
                {
                   updateLabelText(err.Message);
                }
           
        }
        int k = 0;     
        private void fastTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateClockText(DateTime.Now.ToShortTimeString());
                if (LBL_SPEED.Text == "0" & LBL_LOAD.Text == "0" & ignition==true)
                {
                    pic_batt.Visible = true;
                    pic_oil.Visible = true;
                    if (dataflow == false)
                    {
                        pic_batt.Visible = false;
                        pic_oil.Visible = false;                                    
                    }
                }
                else
                {
                    pic_batt.Visible = false;
                    pic_oil.Visible = false;
                }
                if (serialELM.IsOpen & elmReady == true)
                {
                    if (k == 0)
                    {
                        elmReady = false; 
                        k = 1;                        
                        serialELM.Write("010D1\r" + Environment.NewLine);
                    }
                    else if (k == 1)
                    {
                        elmReady = false; 
                        k = 2;
                        serialELM.Write("01051\r" + Environment.NewLine);                       
                    }
                    else if (k == 2)
                    {
                        elmReady = false;
                        k = 3;
                        serialELM.Write("01041\r" + Environment.NewLine);                    
                    }
                    else if (k == 3)
                    {
                        elmReady = false;
                        k = 0;
                        serialELM.Write("ATRV\r" + Environment.NewLine);
                    }                   

                }

            }
            catch (Exception err)
            {
                updateLabelText(err.Message);
            }

        }
        private void serialELM_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialELM.IsOpen)
                {
                    StringBuilder response = new StringBuilder();
                    string message;
                    while ((message = ((char)serialELM.ReadByte()).ToString()) != null && message != "")
                    {
                        response.Append(message);                       
                        if (message == ">")
                        {
                            elmReady = true;
                            response = new StringBuilder();
                        }

                        if (message == "\r")
                        {
                            responseParser(response.ToString());                           
                            response = new StringBuilder();
                            
                        }
                    }
                }
            }
            catch
            { }
        }
        private void responseParser(string response)
        {
            string responseTrim = Regex.Replace(response.TrimStart(new char[] { '?', '>', ' ' }).TrimEnd(new char[] { '?', '>', ' ' }).Trim(), " ", "");
            int resint = 0;
            string checkResponse = "";
            if (responseTrim.Length > 4)
            {
                checkResponse = responseTrim.Substring(0, 4);
                if (responseTrim.Substring(0, 2) == "43")
                    checkResponse = responseTrim.Substring(0, 2);

                if (responseTrim.Substring(0, 2) == "41")
                    resint = int.Parse(responseTrim.Substring(4, responseTrim.Length - 4), System.Globalization.NumberStyles.HexNumber);

                if (responseTrim.Substring(0, 2) == "91")
                    checkResponse = responseTrim.Substring(0, 6);
            }

            switch (checkResponse)
            {
                
                case "4104":
                    dataflow = true;
                    int calcLoad = resint * 100 / 255;
                    updateLoadText(calcLoad.ToString());                    
                    break;
                case "4105":
                    dataflow = true;
                    int tempC = resint - 40;
                    // int tempF = (9 * tempC / 5) + 32;
                    updateTempText(tempC.ToString());                   
                    break;
                case "410C":
                    dataflow = true;
                    int val = (int)(resint / 4);
                    setRPMGauge((int)val / 100);                    
                    break;
                case "410D":
                    dataflow = true;
                    updateSpeedText(resint.ToString());                   
                    break;
                //case "410F":
                //    dataflow = true;
                //    tempC = resint - 40;                    
                //   // tempF = (9 * tempC / 5) + 32;
                //    updateIntakeText(tempC.ToString());                   
                //    break;
                //case "4106":
                //    int trim = (resint - 128) * 100 / 128;
                //    updateLabelText("" + trim.ToString() + "% STFT Bank 1");
                //    break;
                //case "4107":
                //    trim = (resint - 128) * 100 / 128;
                //    updateLabelText("" + trim.ToString() + "% LTFT Bank 1");
                //    break;
                //case "4108":
                //    trim = (resint - 128) * 100 / 128;
                //    updateLabelText("" + trim.ToString() + "% STFT Bank 2");
                //    break;
                //case "4109":
                //    trim = (resint - 128) * 100 / 128;
                //    updateLabelText("" + trim.ToString() + "% LTFT Bank 2");
                //    break;
                //case "410A":
                //    int val = (resint - 128) * 100 / 128;
                //    updateLabelText("" + val.ToString() + " kPa Fuel Pressure");
                //    break;
                //case "410B":
                //    updateLabelText("" + resint.ToString() + " kPa MAP");
                //    break;                
                //case "410E":
                //    val = (resint / 2) - 64;
                //    updateLabelText("" + val.ToString() + " Degrees Advance");
                //    break;               
                //case "4110":
                //    val = (resint / 100);
                //    updateLabelText("" + val.ToString() + " g/s MAF");
                //    break;
                //case "4111":
                //    val = resint * 100 / 255;
                //    updateLabelText("" + val.ToString() + "% Throttle");
                //    break;               
                default:
                    updateLabelText(response);
                    response = Regex.Replace(response, " ", "");
                    if (response.ToString().Trim().Length != 0 & response.ToString().StartsWith("1"))
                    {
                        updateBattText(response.ToString());
                    }
                    else if (response.ToString().StartsWith("NO"))
                    {
                        try
                        {
                            serialELM.Close();
                            playWarning(4);
                            pic_batt.Visible = false;
                            pic_oil.Visible = false;      
                            elmTimer.Enabled = false;
                            FastTimer.Enabled = false;
                            updateLabelText(serialELM.PortName.ToString() + " Closed.");                           
                            txt_protocol.Text = "";
                            elmReady = true;
                            ignition = false;
                            dataflow = false;                            
                        }catch{}
                        
                    }
                    else dataflow = true;
                    break;
            }

        }
        public void elmCommand(string command)
        {
            try
            {
                if (serialELM.IsOpen)
                {
                    serialELM.Write(command.Trim() + Environment.NewLine);
                }
            }
            catch (Exception err)
            {
                updateLabelText(" ERROR: " + err.Message);                
            }

            
        }

        public void setRPMGauge(int rpmVal)
        {
            if (RPMGauge.InvokeRequired)
            {
                RPMGauge.Invoke(new EventHandler(
                    delegate
                    {
                        RPMGauge.Value = rpmVal;
                    }));
            }
            else
            {
                RPMGauge.Value = rpmVal;
            }
            RPMGauge.Value = rpmVal;
            RPMGauge.DialText = "RPM X 100";            
        }
              
        delegate void updateLabelTextDelegate(string newText);
        private void updateLabelText(string newText)
        {
            if (rxtxTB.InvokeRequired)
            {
                // worker thread
                updateLabelTextDelegate del = new updateLabelTextDelegate(updateLabelText);
                rxtxTB.Invoke(del, new object[] { newText.Trim() });
            }
            else
            {
                // UI thread
                rxtxTB.Text = newText.Trim();
            }
        }
        delegate void updateBattTextDelegate(string newText);
        private void updateBattText(string newText)
        {
            if (LBL_BATT.InvokeRequired)
            {
                // worker thread
                updateBattTextDelegate del = new updateBattTextDelegate(updateBattText);
                LBL_BATT.Invoke(del, new object[] { newText.Trim() });
            }
            else
            {
                // UI thread
                LBL_BATT.Text = newText.Trim();
            }
        }
        delegate void updateTempTextDelegate(string newText);
        private void updateTempText(string newText)
        {
            if (LBL_TEMP.InvokeRequired)
            {
                // worker thread
                updateTempTextDelegate del = new updateTempTextDelegate(updateTempText);
                LBL_TEMP.Invoke(del, new object[] { newText.Trim() });
            }
            else
            {
                // UI thread
                LBL_TEMP.Text = newText.Trim();
            }
        }
        delegate void updateSpeedTextDelegate(string newText);
        private void updateSpeedText(string newText)
        {
            if (LBL_SPEED.InvokeRequired)
            {
                // worker thread
                updateSpeedTextDelegate del = new updateSpeedTextDelegate(updateSpeedText);
                LBL_SPEED.Invoke(del, new object[] { newText.Trim() });
            }
            else
            {
                // UI thread
                LBL_SPEED.Text = newText.Trim();
            }
        }
        private void playWarning(int warn)
        {string path;
            SoundPlayer player = new SoundPlayer();
            if (warn==1)
                path = Directory.GetCurrentDirectory() + @"\sound\Start.wav";
            else if (warn == 2)
                path = Directory.GetCurrentDirectory() + @"\sound\Beepl.wav";
            else if (warn == 3)
                path = Directory.GetCurrentDirectory() + @"\sound\Beeph.wav";
            else if (warn == 4)
                path = Directory.GetCurrentDirectory() + @"\sound\End.wav";
            else
            path="";

            player.SoundLocation = path; 
            player.Play();
        }

        delegate void updateLoadTextDelegate(string newText);
        private void updateLoadText(string newText)
        {
                if (Convert.ToInt32(newText) >= 70)
                {
                    playWarning(3);               
                }
                if (LBL_LOAD.InvokeRequired)
                {
                    // worker thread
                    updateLoadTextDelegate del = new updateLoadTextDelegate(updateLoadText);
                    LBL_LOAD.Invoke(del, new object[] { newText.Trim() });
                }
                else
                {
                    // UI thread
                    LBL_LOAD.Text = newText.Trim();
                }
        }
        delegate void updateClockTextDelegate(string newText);
        private void updateClockText(string newText)
        {
            if (LBL_CLOCK.InvokeRequired)
            {
                // worker thread
                updateClockTextDelegate del = new updateClockTextDelegate(updateClockText);
                LBL_CLOCK.Invoke(del, new object[] { newText.Trim() });
            }
            else
            {
                // UI thread
                LBL_CLOCK.Text = newText.Trim();
            }
        }
        private void serialELM_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            updateLabelText(e.ToString());
        }

      

        #endregion


        #region - CRC Check -


        private byte crc8(byte[] buffer)
        {
            return crc8(buffer, false);
        }
        private byte crc8(byte[] buffer, bool iso)
        {
            byte crc_reg = (byte)0xFF;
            byte checksum = (byte)0;
            byte val;

            for (int len = 0; len < buffer.Length; len++)
            {
                val = buffer[len];
                checksum += val;

                for (int i = 8; i > 0; i--)
                {
                    if (((val ^ crc_reg) & 0x80) != (byte)0)
                    {
                        crc_reg ^= 0x0e;
                        crc_reg = (byte)((crc_reg << 1) | 1);
                    }
                    else
                        crc_reg = (byte)(crc_reg << 1);

                    val = (byte)(val << 1);
                }

            }
            if (iso)
                return checksum;
            else
                return (byte)~crc_reg;
        }



      
        #endregion

        #region - Conversions - 
        public string byte2bin(string bytestr)
        {
            string bin = "0000";
            switch (bytestr)
            {
                case "1":
                    bin = "0001";
                    break;
                case "2":
                    bin = "0010";
                    break;
                case "3":
                    bin = "0011";
                    break;
                case "4":
                    bin = "0100";
                    break;
                case "5":
                    bin = "0101";
                    break;
                case "6":
                    bin = "0110";
                    break;
                case "7":
                    bin = "0111";
                    break;
                case "8":
                    bin = "1000";
                    break;
                case "9":
                    bin = "1001";
                    break;
                case "A":
                    bin = "1010";
                    break;
                case "B":
                    bin = "1011";
                    break;
                case "C":
                    bin = "1100";
                    break;
                case "D":
                    bin = "1101";
                    break;
                case "E":
                    bin = "1110";
                    break;
                case "F":
                    bin = "1111";
                    break;
                default:
                    bin = "0000";
                    break;
            }
            return bin;
        }
        #endregion

    
        private void btn_sendcommand_Click(object sender, EventArgs e)
        {
            if (txt_command.Text != "")
            {
                if (serialELM.IsOpen)
                {
                    checktimer1.Checked = false;
                    elmReady = false;
                    LBL_BATT.Text = "";
                    elmCommand(txt_command.Text);
                    updateLabelText(txt_command.Text);
                }
                else updateLabelText(serialELM.PortName.ToString() + " is not opened.");
            }
            else
                updateLabelText( txt_command.Text + "There is no Command.");
        }

        private void checktimer1_CheckedChanged(object sender, EventArgs e)
        {
            if (serialELM.IsOpen)
            {
                if (checktimer1.Checked)
                {
                    elmTimer.Enabled = true;                  
                }
                else{
                    elmTimer.Enabled = false;                   
                }
            }
        }

        private void comboPORT_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialELM.PortName = comboPORT.SelectedItem.ToString();
        }

        private void comboBAUD_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialELM.BaudRate=Convert.ToInt32(comboBAUD.SelectedItem.ToString());
        }

        private void btn_settimer_Click(object sender, EventArgs e)
        {
            elmTimer.Interval = Convert.ToInt32(textTimer1.Text);
            FastTimer.Interval = Convert.ToInt32(textTimer2.Text);
        }

        private void checkGaugeTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (checkGaugeTrans.Checked)
            {
                RPMGauge.EnableTransparentBackground = true;                
            }
            else
            {
                RPMGauge.EnableTransparentBackground = false;        
            }
        }

        private void checktimer2_CheckedChanged(object sender, EventArgs e)
        {
            if (serialELM.IsOpen)
            {
                if (checktimer1.Checked)
                {
                   FastTimer.Enabled = true;
                }
                else
                {
                   FastTimer.Enabled = false;
                }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
             if (R.Checked)
             {
                 RPMGauge.DialColor = System.Drawing.Color.FromArgb(hScrollBar1.Value, 0, 0);
             }
             else if (G.Checked)
             {
                 RPMGauge.DialColor = System.Drawing.Color.FromArgb(0, hScrollBar1.Value, 0);
             }
             else if (B.Checked)
             {
                 RPMGauge.DialColor = System.Drawing.Color.FromArgb(0, 0, hScrollBar1.Value);
             }
        }

        private void R_CheckedChanged(object sender, EventArgs e)
        {
            if (R.Checked)
            {
                G.Checked = false;
                B.Checked = false;               
            }
           
        }

        private void B_CheckedChanged(object sender, EventArgs e)
        {
            if (B.Checked)
            {
                G.Checked = false;               
                R.Checked = false;
            }
            
        }

        private void G_CheckedChanged(object sender, EventArgs e)
        {
            if (G.Checked)
            {                
                B.Checked = false;
                R.Checked = false;
            }
           
        }

        private void glossiness_Scroll(object sender, ScrollEventArgs e)
        {
            RPMGauge.Glossiness = glossiness.Value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            glossiness.Value = Convert.ToInt32(RPMGauge.Glossiness.ToString());
        }

        private void batttimer_Tick(object sender, EventArgs e)
        {
            updateClockText(DateTime.Now.ToShortTimeString());
            pic_batt.Visible = true;
            Application.DoEvents();
            Thread.Sleep(150);
            pic_batt.Visible = false;
            Application.DoEvents();
            Thread.Sleep(150);
            if (serialELM.IsOpen & elmReady == true)
            {
                elmReady = false;
                serialELM.Write("ATRV\r" + Environment.NewLine);
            }                  
                    
        }

        private void checkBatt_CheckedChanged(object sender, EventArgs e)
        {
            if (serialELM.IsOpen)
            {
                if (checkBatt.Checked == true)
                {
                    batttimer.Enabled = true;
                    elmTimer.Enabled = false;
                    FastTimer.Enabled = false;
                    pic_batt.Visible = false;
                    pic_oil.Visible = false;
                }
                else
                {
                    batttimer.Enabled = false;
                    elmTimer.Enabled = true;
                    FastTimer.Enabled = true;
                }
            }
        }

        private void LBL_CLOCK_Click(object sender, EventArgs e)
        {
            updateClockText(DateTime.Now.ToShortTimeString());
        }

        private void timer_clock_Tick(object sender, EventArgs e)
        {
            updateClockText(DateTime.Now.ToShortTimeString());
        }

       
       
    }

   //// formula                        // label            //screen_buffer  //pid  //enabled // bytes
   //{ throttle_position_formula,     "Absolute Throttle Position:",     "", "11",      1,    1 },
   //{ engine_rpm_formula,            "Engine RPM:",                     "", "0C",      1,    2 },
   //{ vehicle_speed_formula,         "Vehicle Speed:",                  "", "0D",      1,    1 },
   //{ engine_load_formula,           "Calculated Load Value:",          "", "04",      1,    1 },
   //{ timing_advance_formula,        "Timing Advance (Cyl. #1):",       "", "0E",      1,    1 },
   //{ intake_pressure_formula,       "Intake Manifold Pressure:",       "", "0B",      1,    1 },
   //{ air_flow_rate_formula,         "Air Flow Rate (MAF sensor):",     "", "10",      1,    2 },
   //{ fuel_system1_status_formula,   "Fuel System 1 Status:",           "", "03",      1,    2 },
   //{ fuel_system2_status_formula,   "Fuel System 2 Status:",           "", "03",      1,    2 },
   //// Page 2
   //{ short_term_fuel_trim_formula,  "Short Term Fuel Trim (Bank 1):",  "", "06",      1,    2 },
   //{ long_term_fuel_trim_formula,   "Long Term Fuel Trim (Bank 1):",   "", "07",      1,    2 },
   //{ short_term_fuel_trim_formula,  "Short Term Fuel Trim (Bank 2):",  "", "08",      1,    2 },
   //{ long_term_fuel_trim_formula,   "Long Term Fuel Trim (Bank 2):",   "", "09",      1,    2 },
   //{ intake_air_temp_formula,       "Intake Air Temperature:",         "", "0F",      1,    1 },
   //{ coolant_temp_formula,          "Coolant Temperature:",            "", "05",      1,    1 },
   //{ fuel_pressure_formula,         "Fuel Pressure (gauge):",          "", "0A",      1,    1 },
   //{ secondary_air_status_formula,  "Secondary air status:",           "", "12",      1,    1 },
   //{ pto_status_formula,            "Power Take-Off Status:",          "", "1E",      1,    1 },
   //// Page 3
   //{ o2_sensor_formula,             "O2 Sensor 1, Bank 1:",            "", "14",      1,    2 },
   //{ o2_sensor_formula,             "O2 Sensor 2, Bank 1:",            "", "15",      1,    2 },
   //{ o2_sensor_formula,             "O2 Sensor 3, Bank 1:",            "", "16",      1,    2 },
   //{ o2_sensor_formula,             "O2 Sensor 4, Bank 1:",            "", "17",      1,    2 },
   //{ o2_sensor_formula,             "O2 Sensor 1, Bank 2:",            "", "18",      1,    2 },
   //{ o2_sensor_formula,             "O2 Sensor 2, Bank 2:",            "", "19",      1,    2 },
   //{ o2_sensor_formula,             "O2 Sensor 3, Bank 2:",            "", "1A",      1,    2 },
   //{ o2_sensor_formula,             "O2 Sensor 4, Bank 2:",            "", "1B",      1,    2 },
   //{ obd_requirements_formula,      "OBD conforms to:",                "", "1C",      1,    1 },
   //// Page 4
   //{ o2_sensor_wrv_formula,         "O2 Sensor 1, Bank 1 (WR):",       "", "24",      1,    4 },    // o2 sensors (wide range), voltage
   //{ o2_sensor_wrv_formula,         "O2 Sensor 2, Bank 1 (WR):",       "", "25",      1,    4 },
   //{ o2_sensor_wrv_formula,         "O2 Sensor 3, Bank 1 (WR):",       "", "26",      1,    4 },
   //{ o2_sensor_wrv_formula,         "O2 Sensor 4, Bank 1 (WR):",       "", "27",      1,    4 },
   //{ o2_sensor_wrv_formula,         "O2 Sensor 1, Bank 2 (WR):",       "", "28",      1,    4 },
   //{ o2_sensor_wrv_formula,         "O2 Sensor 2, Bank 2 (WR):",       "", "29",      1,    4 },
   //{ o2_sensor_wrv_formula,         "O2 Sensor 3, Bank 2 (WR):",       "", "2A",      1,    4 },
   //{ o2_sensor_wrv_formula,         "O2 Sensor 4, Bank 2 (WR):",       "", "2B",      1,    4 },
   //{ engine_run_time_formula,       "Time Since Engine Start:",        "", "1F",      1,    2 },
   //// Page 5
   //{ frp_relative_formula,          "FRP rel. to manifold vacuum:",    "", "22",      1,    2 },    // fuel rail pressure relative to manifold vacuum
   //{ frp_widerange_formula,         "Fuel Pressure (gauge):",          "", "23",      1,    2 },    // fuel rail pressure (gauge), wide range
   //{ commanded_egr_formula,         "Commanded EGR:",                  "", "2C",      1,    1 },
   //{ egr_error_formula,             "EGR Error:",                      "", "2D",      1,    1 },
   //{ evap_pct_formula,              "Commanded Evaporative Purge:",    "", "2E",      1,    1 },
   //{ fuel_level_formula,            "Fuel Level Input:",               "", "2F",      1,    1 },
   //{ warm_ups_formula,              "Warm-ups since ECU reset:",       "", "30",      1,    1 },
   //{ clr_distance_formula,          "Distance since ECU reset:",       "", "31",      1,    2 },
   //{ evap_vp_formula,               "Evap System Vapor Pressure:",     "", "32",      1,    2 },
   //// Page 6
   //{ o2_sensor_wrc_formula,         "O2 Sensor 1, Bank 1 (WR):",       "", "34",      1,    4 },   // o2 sensors (wide range), current
   //{ o2_sensor_wrc_formula,         "O2 Sensor 2, Bank 1 (WR):",       "", "35",      1,    4 },
   //{ o2_sensor_wrc_formula,         "O2 Sensor 3, Bank 1 (WR):",       "", "36",      1,    4 },
   //{ o2_sensor_wrc_formula,         "O2 Sensor 4, Bank 1 (WR):",       "", "37",      1,    4 },
   //{ o2_sensor_wrc_formula,         "O2 Sensor 1, Bank 2 (WR):",       "", "38",      1,    4 },
   //{ o2_sensor_wrc_formula,         "O2 Sensor 2, Bank 2 (WR):",       "", "39",      1,    4 },
   //{ o2_sensor_wrc_formula,         "O2 Sensor 3, Bank 2 (WR):",       "", "3A",      1,    4 },
   //{ o2_sensor_wrc_formula,         "O2 Sensor 4, Bank 2 (WR):",       "", "3B",      1,    4 },
   //{ mil_distance_formula,          "Distance since MIL activated:",   "", "21",      1,    2 },
   //// Page 7
   //{ baro_pressure_formula,         "Barometric Pressure (absolute):", "", "33",      1,    1 },
   //{ cat_temp_formula,              "CAT Temperature, B1S1:",          "", "3C",      1,    2 },
   //{ cat_temp_formula,              "CAT Temperature, B2S1:",          "", "3D",      1,    2 },
   //{ cat_temp_formula,              "CAT Temperature, B1S2:",          "", "3E",      1,    2 },
   //{ cat_temp_formula,              "CAT Temperature, B2S2:",          "", "3F",      1,    2 },
   //{ ecu_voltage_formula,           "ECU voltage:",                    "", "42",      1,    2 },
   //{ abs_load_formula,              "Absolute Engine Load:",           "", "43",      1,    2 },
   //{ eq_ratio_formula,              "Commanded Equivalence Ratio:",    "", "44",      1,    2 },
   //{ amb_air_temp_formula,          "Ambient Air Temperature:",        "", "46",      1,    1 },  // same scaling as $0F
   //// Page 8
   //{ relative_tp_formula,           "Relative Throttle Position:",     "", "45",      1,    1 },
   //{ abs_tp_formula,                "Absolute Throttle Position B:",   "", "47",      1,    1 },
   //{ abs_tp_formula,                "Absolute Throttle Position C:",   "", "48",      1,    1 },
   //{ abs_tp_formula,                "Accelerator Pedal Position D:",   "", "49",      1,    1 },
   //{ abs_tp_formula,                "Accelerator Pedal Position E:",   "", "4A",      1,    1 },
   //{ abs_tp_formula,                "Accelerator Pedal Position F:",   "", "4B",      1,    1 },
   //{ tac_pct_formula,               "Comm. Throttle Actuator Cntrl:",  "", "4C",      1,    1 }, // commanded TAC
   //{ mil_time_formula,              "Engine running while MIL on:",    "", "4D",      1,    2 }, // minutes run by the engine while MIL activated
   //{ clr_time_formula,              "Time since DTCs cleared:",        "", "4E",      1,    2 },
   //{ NULL,                          "",                                "", "",        0,    0 }


}
