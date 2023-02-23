using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private int _inputCoin;
       public int CoinSum;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int.TryParse(textBox1.Text, out _inputCoin);

            if (string.IsNullOrEmpty(textBox1.Text)||Math.Abs(_inputCoin) < 0)
            {
                CoinSum = _inputCoin;
                textBox2.Text = string.Format(@"State:StandbyState 機器沒在工作,等待下一個客人操作" + "\r\n" + "Money:{0}", CoinSum);
                //button2.Enabled = false;
                //button3.Enabled = false;
            }else if (_inputCoin > 0 && _inputCoin < 50)
            {
                CoinSum += _inputCoin;
                if (CoinSum < 50)
                {
                    textBox2.Text = string.Format(@"State:InsufficientAmountState 有投幣,但金額還不足夠" + "\r\n" + "Money:{0}",
                        CoinSum);
                    button2.Enabled = true;
                }
                else
                {
                    textBox2.Text = string.Format(@"State:ReadyToShip 投入足夠金額,等待客人指令就出貨" + "\r\n" + "Money:{0}", CoinSum);
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
            else 
            {
                CoinSum += _inputCoin;
                textBox2.Text = string.Format(@"State:ReadyToShip 投入足夠金額,等待客人指令就出貨" + "\r\n" + "Money:{0}", CoinSum);
                button2.Enabled = true;
                button3.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CoinSum > 0)
            {
                MessageBox.Show(@"已完成退幣作業");
                CoinSum -= CoinSum;
                textBox1.Text = "";
                textBox2.Text = string.Format(@"State:StandbyState 機器沒在工作,等待下一個客人操作" + "\r\n" + "Money:{0}", CoinSum);
                button2.Enabled = false;
                button3.Enabled = false;
       
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CoinSum >= 50)
            {
                MessageBox.Show(@"已出貨");
                CoinSum = CoinSum - 50;
                if (CoinSum >= 50)
                {
                    textBox2.Text = string.Format(@"State:ReadyToShip 投入足夠金額,等待客人指令就出貨" + "\r\n" + "Money:{0}", CoinSum);
                }else if (CoinSum > 0)
                {
                    textBox2.Text = string.Format(@"State:InsufficientAmountState 有投幣,但金額還不足夠" + "\r\n" + "Money:{0}",
                        CoinSum);
                    button3.Enabled = false;
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = string.Format(@"State:StandbyState 機器沒在工作,等待下一個客人操作" + "\r\n" + "Money:{0}", CoinSum);
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
            }
        }

    }

 
    //public static class InputCoinFirst
    //{
    //    public static int Coin { get; set; }
    //}

    
}
