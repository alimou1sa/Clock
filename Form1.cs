using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace project_5_clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            dateTimePicker1.Value = DateTime.Now;
            label1.Text = dateTimePicker1.Value.ToLongTimeString();

            label1.Refresh();
        }

        byte timer = 0;
        byte second = 0;
        byte min = 0;
        byte hour = 0;

        DateTime dt2;
        DateTime dt;
       TimeSpan differauntdate;


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            label2.Text = timer.ToString();
            if (timer > 98)
            {
                timer = 0;

                second++;
                label6.Text = second.ToString();

            }

            if (second > 59)
            {
                second = 0;
                min++;
                label3.Text = min.ToString();

            }

            if (min > 59)
            {
                min = 0;
                hour++;
                label7.Text = hour.ToString();
            }




        }

        void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer2.Enabled = true;
            dateTimePicker1.Value = System.DateTime.Now;
            label1.Text = dateTimePicker1.Value.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }


        int time = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 1)
            {
                label1_Click(sender, e);

                time = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer = 0;
            second = 0;
            min = 0;
            hour = 0;

            label6.Text = "0";
            label3.Text = "0";
            label7.Text = "0";
            label2.Text = "0";
        }

        void tm()
        {
  
            dt = dateTimePicker1.Value;

            dt2= dateTimePicker2.Value ;

            //if (dt2 < dt)
            //{
            //    dt2 = dt2.AddDays(1);
            //}

        }

        bool Alarm()
        {
        
            tm();
            differauntdate = dt2 - dt;
            string formattedTimeDifference = differauntdate.ToString(@"hh\:mm\:ss");
            label10.Text = formattedTimeDifference;
    

            if (dt >= dt2)
            {
                return true;
            }   

         return false;

        }
      
    
        private void button4_Click(object sender, EventArgs e)
        {

            timer3.Enabled = true;
            tm();
        }

        byte x = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
          
            x++;
            if (x== 1)
            {  
                

              if (Alarm())
              {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.BalloonTipTitle = "HI";
                notifyIcon1.BalloonTipText =textBox1.Text;
                notifyIcon1.ShowBalloonTip(1000);
                timer3.Stop();
              }

                x = 0;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            TimeSpan tim = TimeSpan.Zero;
            string formattedTimeDifference = tim.ToString(@"hh\:mm\:ss");
            label10.Text = formattedTimeDifference;
        }





    }
}
