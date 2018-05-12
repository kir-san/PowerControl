using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerControl2
{
    public partial class Form1 : Form
    {
        private PowerLineStatus lastStatus = SystemInformation.PowerStatus.PowerLineStatus;

        private Form f;
       

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SystemEvents.PowerModeChanged += OnPowerModeChanged;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SystemEvents.PowerModeChanged -= OnPowerModeChanged;
        }

        private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            var newStatus = SystemInformation.PowerStatus.PowerLineStatus;

            if (e.Mode == PowerModes.StatusChange && newStatus != lastStatus)
            {
                switch (newStatus)
                {
                    case PowerLineStatus.Online:
                       
                        if(f != null)
                        {
                           f.Close();
                        }
                   
                        Console.WriteLine("Питание есть");

                        lastStatus = newStatus;
                        break;

                    case PowerLineStatus.Offline:
                        Console.WriteLine("Питание кончилось");

                        f = new TimerDialog();
                        f.Show();

                        // 

                        lastStatus = newStatus;
                        break;

                    case PowerLineStatus.Unknown:
                        
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
        }
    }
}
