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


        public static int TICK_HORLOGE = 500;
        private TypeDate LeFormatDate;
        private Thread timeUpdate;
     
        public Form1()
        {
            InitializeComponent();
        
        }

        #region Radio_CheckChanged
        private void RadioFull_CheckedChanged(object sender, EventArgs e)
        {
            this.LeFormatDate = TypeDate.DateEtHeure;
            this.RefreshTimeUI();
        }

        private void radioDay_CheckedChanged(object sender, EventArgs e)
        {
            this.LeFormatDate = TypeDate.Date;
            this.RefreshTimeUI();
        }

        private void radioTime_CheckedChanged(object sender, EventArgs e)
        {
            this.LeFormatDate = TypeDate.Heure;
            this.RefreshTimeUI();
        }
        #endregion

        /// <summary>
        /// Methode appelé par le thread
        /// </summary>
        private void updateTime()
        {
            while (true)
            {              
                    this.RefreshTimeUI();
                    System.Threading.Thread.Sleep(TICK_HORLOGE);
            }        
        }

      

        //true si necessite un refresh (1 refresh par seconde)
       

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timeUpdate = new Thread(updateTime);
            this.timeUpdate.IsBackground = true;
            this.timeUpdate.Start();

        }

        /// <summary>
        /// accepte les modifications a partir d'un autre thread que le main
        /// grace à l'objet MethodInvoker
        /// </summary>
        private void RefreshTimeUI()
        {
            MethodInvoker invoker = delegate
               {
                   this.LabelHorloge.Text = this.GenererDate();
               };

            this.Invoke(invoker);
        }


        /// <summary>
        /// Genere la date en fonction de la selection
        /// </summary>
        /// <returns></returns>
        private string GenererDate()
        {
            string date = null;
            switch (this.LeFormatDate)
            {
                case TypeDate.Date:
                   date= DateTime.Now.ToShortDateString();
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

        /// <summary>
        /// evenement fermeture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fermeture(object sender, FormClosingEventArgs e)
        {
            this.timeUpdate.Abort();
            Application.ExitThread();
        }
    }

    /// <summary>
    /// enumération des choix du radio group
    /// </summary>
    public enum TypeDate
    {
        Date,
        DateEtHeure,
        Heure
    }
}
