using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerControl2
{
    public partial class TimerDialog : Form
    {

        private int timeLeft = 20;

        public TimerDialog()
        {
            InitializeComponent();
        }

        private void TimerDialog_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = timeLeft;
            progressBar1.Value = timeLeft;

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += Timer1_tick;
        }

        private void Timer1_tick(object sender, EventArgs e)
        {
            --timeLeft;

            if(timeLeft >= 0)
            {
                if (timeLeft == 0)
                {
                    label2.Text = "Гибернирую!!!";
                }
                else
                {
                    progressBar1.Value = timeLeft;
                    label2.Text = "Осталось " + timeLeft + " сек";
                }
            } else 
            {
                timer1.Stop();
                Application.SetSuspendState(PowerState.Hibernate, true, true);
            }
        }
    }
}
