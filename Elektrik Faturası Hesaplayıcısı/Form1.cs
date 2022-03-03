using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elektrik_Faturası_Hesaplayıcısı
{
    public partial class Form1 : Form
    {
        float kw = 1.37f;
        float kw2 = 2.06f;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float totalkw = ((float.Parse(textBox1.Text) / 1000f) * float.Parse(comboBox1.SelectedItem.ToString())) * float.Parse(comboBox2.SelectedItem.ToString());
            float amount;
            if(totalkw > 210f)
            {
                amount = kw * 210f;
                float fark = (totalkw - 210f) * kw2;
                amount += fark;
            }
            else
            {
                amount = totalkw * kw;
            }
            label4.Text = amount.ToString() + " TL";
            label6.Text = totalkw.ToString() + " kWh";
        }
    }
}
