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

namespace HorlogeStoV2
{
    public partial class Form1 : Form
    {
        private TypeDate LeFormatDate = TypeDate.DateEtHeure;

        private Thread timeUpdate;

        #region Init_Form
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Timer
        private void timerRefreshTime_Tick(object sender, EventArgs e)
        {
            UpdateTimeUi();
           
        }
        #endregion

        #region Radio_CheckChanged
        private void RadioFull_CheckedChanged(object sender, EventArgs e)
        {
            this.LeFormatDate = TypeDate.DateEtHeure;
            this.ForceRefreshTime();
        }

        private void InvokeUpdateTimeUi()
        {
            MethodInvoker invoke = delegate
            {
                this.UpdateTimeUi();
            };
            this.Invoke(invoke);
        }

        private void ForceRefreshTime()
        {

            this.timeUpdate = new Thread(InvokeUpdateTimeUi);
            this.timeUpdate.Start();
        }

        private void radioDay_CheckedChanged(object sender, EventArgs e)
        {
            this.LeFormatDate = TypeDate.Date;
            this.ForceRefreshTime();
        }

        private void radioTime_CheckedChanged(object sender, EventArgs e)
        {
            this.LeFormatDate = TypeDate.Heure;
            this.ForceRefreshTime();
        }
        #endregion

        #region Closing
        private void Fermeture(object sender, FormClosingEventArgs e)
        {
            this.timeUpdate.Abort();
            Application.ExitThread();
        }
        #endregion

        private void UpdateTimeUi()
        {
            this.LabelHorloge.Text = this.GenererDate();
        }

        private string GenererDate()
        {
            string date = null;
            switch (this.LeFormatDate)
            {
                case TypeDate.Date:
                    date = DateTime.Now.ToShortDateString();
                    break;
                case TypeDate.DateEtHeure:
                    date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                    break;
                case TypeDate.Heure:
                    date = DateTime.Now.ToLongTimeString();
                    break;
            }
            return date;
        }
       
    }


    public enum TypeDate
    {
        Date,
        DateEtHeure,
        Heure
    }
}
