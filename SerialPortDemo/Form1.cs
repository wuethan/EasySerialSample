using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace SerialPortDemo
{
    public partial class Form1 : Form
    {
        #region 变量

        //申明串口
        public SerialPort MySerialPort;
        //存储接收的缓存数据
        public List<byte> BufferList = new List<byte>();

        #endregion

        #region 构造函数

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 十六进制字符串转为字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] StringToHexByteArray(string s)
        {
            s = s.Replace(" ", "");
            if ((s.Length%2) != 0)
                s += " ";
            byte[] returnBytes = new byte[s.Length/2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(s.Substring(i*2, 2), 16);
            return returnBytes;

        }

        /// <summary>
        /// 十六进制字节数组转为字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HexByteArrayToString(byte[] data)
        {
            StringBuilder strBuilder = new StringBuilder(data.Length*3);
            foreach (byte b in data)
            {
                strBuilder.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return strBuilder.ToString().ToUpper(); //将得到的字符全部以字母大写形式输出
        }

        private delegate void ShowDataCallback(string str);

        /// <summary>
        /// 写入串口信息文本框
        /// </summary>
        /// <param name="message"></param>
        public void ShowData(string message)
        {
            MsgList.Items.Add(DateTime.Now.ToString("mm:ss  ") + message);
            MsgList.SelectedIndex = MsgList.Items.Count - 1;
            //这里可以写解析数据方法（自定义）
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="strData"></param>
        public void SendData(string strData)
        {
            try
            {
                //"FF FE XX XX XX XX XX";数据格式
                byte[] writeBuffer = StringToHexByteArray(strData);
                MySerialPort.Write(writeBuffer, 0, writeBuffer.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("发送指令数据错误，错误原因：{0}", ex.Message));
            }
        }

        #endregion

        #region 事件
        /// <summary>
        /// 串口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            BtnRefreshClick(null, null);
        }
        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //根据不同协议更改协议长度和针头针尾数据
            //这里以FF FE XX XX XX XX XX AA为例
            //针头为：FF FE，针尾为：AA
            try
            {
                int n = MySerialPort.BytesToRead; //记录缓存数据的长度
                byte[] buf = new byte[n]; //声明一个临时数组存储当前来的串口数据  
                MySerialPort.Read(buf, 0, n); //读取缓冲数据  
                BufferList.AddRange(buf);//将本次接收到的缓存数据添加到BufferList列表数据中
                //当BufferList缓存列表数据大于或等于协议数据长度时开始处理数据
                while (BufferList.Count >= 8)
                {
                    //查找数据头（重要，防止数据丢失或不全）
                    if (BufferList[0] != 0xFF || BufferList[1] != 0xFE || BufferList[7] != 0xAA)
                    {
                        //若针头针尾没有达到协议标准则移除BufferList第一位，继续下一轮判断
                        BufferList.RemoveAt(0);
                        continue;
                    }
                    //若前面数据验证成功则将数据取出
                    StringBuilder myStringBuilder = new StringBuilder(MySerialPort.ReadBufferSize*2);
                    for (int i = 0; i < 8; i++)
                    {
                        myStringBuilder.Append(String.Format("{0:X2}", Convert.ToInt32(BufferList[i])) + " ");
                    }
                    //移除BufferList列表中已处理的数据
                    BufferList.RemoveRange(0, 8); //从缓存中删除错误数据  
                    Invoke(new ShowDataCallback(ShowData), myStringBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                //最好写日志文件，保存起来
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 刷新串口按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefreshClick(object sender, EventArgs e)
        {
            CBSerialportList.Items.Clear();
            //获取PC端可用串口
            string[] ports = SerialPort.GetPortNames();
            //对串口进行排序
            Array.Sort(ports);
            foreach (string name in ports)
            {
                CBSerialportList.Items.Add(name);
            }
        }

        /// <summary>
        /// 打开串口按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenClick(object sender, EventArgs e)
        {
            if (MySerialPort == null)
                MySerialPort = new SerialPort();
            try
            {
                //打开串口
                if (CBSerialportList.Items.Count == 0)
                {
                    MessageBox.Show(string.Format("未检测到系统串口，请确认串口已连接"));
                    return;
                }
                MySerialPort.PortName = CBSerialportList.Text;
                MySerialPort.BaudRate = 9600; //波特率
                MySerialPort.Parity = Parity.None;
                MySerialPort.DataBits = 8;
                MySerialPort.StopBits = StopBits.One;
                MySerialPort.DataReceived += new SerialDataReceivedEventHandler(SpDataReceived);
                MySerialPort.Open();
                BtnOpen.Enabled = false;
                BtnClose.Enabled = true;
                label1.Text = string.Format("串口已打开");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 关闭串口按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseClick(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                MySerialPort.Close();
                BtnOpen.Enabled = true;
                BtnClose.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 发送按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendClick(object sender, EventArgs e)
        {
            SendData(TxtMsg.Text);
        }

        #endregion


    }
}
