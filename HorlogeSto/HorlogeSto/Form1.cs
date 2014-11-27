using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorlogeSto
{
    public partial class Form1 : Form
    {
        private DateTime dateTime { get; set; }
        private string textDate { get; set; }
        private DateTime lastFrameUpdate { get; set; }

        //bool en fonction des radio
        private bool full;
        private bool date;
        private bool time;
        public Form1()
        {
            InitializeComponent();
            this.full = true;
            this.date = false;
            this.time = false;
            this.lastFrameUpdate = DateTime.Now;
        }

        #region Radio_CheckChanged
        private void RadioFull_CheckedChanged(object sender, EventArgs e)
        {
            this.full = true;
            this.date = false;
            this.time = false;
        }

        private void radioDay_CheckedChanged(object sender, EventArgs e)
        {
            this.full = false;
            this.date = true;
            this.time = false;
        }

        private void radioTime_CheckedChanged(object sender, EventArgs e)
        {
            this.full = false;
            this.date = false;
            this.time = true;
        }
        #endregion

        private void updateTime()
        {
            //-2 = force l'update au chargement de la fenetre
            this.lastFrameUpdate = DateTime.Now.AddSeconds(-2);
            while (true)
            {
                if (RefreshUI())
                {
                    FormatDateSelection();
                    this.RefreshTimeUI();
                }

            }
        }

        private void FormatDateSelection()
        {
            this.dateTime = DateTime.Today;

            if (this.full)
            {
                this.textDate = this.dateTime.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            }
            else
                if (this.date)
                {
                    this.textDate = this.dateTime.ToShortDateString();
                }
                else
                    this.textDate = DateTime.Now.ToLongTimeString();
        }

        //true si necessite un refresh (1 refresh par seconde)
        private bool RefreshUI()
        {
            return DateTime.Now.TimeOfDay.TotalSeconds - this.lastFrameUpdate.TimeOfDay.TotalSeconds >= 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread timeUpdate = new Thread(updateTime);
            timeUpdate.Start();

        }

        //accepte les modifications a partir d'un autre thread que le main
        private void RefreshTimeUI()
        {
            MethodInvoker invoker = delegate
               {
                   this.LabelHorloge.Text = this.textDate;
               };

            this.Invoke(invoker);
        }


    }
}
