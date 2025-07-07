using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceSendMail
{
    public partial class ServiceL3GLGroupe2 : ServiceBase
       
    {
        public static Timer aTimer;
        public ServiceL3GLGroupe2()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            WriteLogSystem("Démarage du service SenMail", string.Format("Le service est demarré à {0}", DateTime.Now));
            aTimer.Interval = 1000;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        private static void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                WriteLogSystem("test", DateTime.Now.ToString());
            }
            catch(Exception ex) 
            { 

            }
            aTimer.Start();
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
            WriteLogSystem("Arret du service SenMail", string.Format("Le service est arreté à {0}", DateTime.Now));
        }

        public static void WriteLogSystem(string erreur , string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Send Mail:";
                eventLog.WriteEntry(string.Format("date: {0}, libelle"));
            }
        }
    }
}
