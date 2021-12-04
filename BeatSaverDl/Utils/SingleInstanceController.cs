using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BeatSaverDl
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        private Form m_SetMain;

        public SingleInstanceController(Form main)
        {
            m_SetMain = main;
            IsSingleInstance = true;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            Program.NotifyNewInstance(eventArgs.CommandLine.ToArray());
            if (Program.AutoFocus)
            {
                base.OnStartupNextInstance(eventArgs);
            }
        }

        protected override void OnCreateMainForm()
        {
            MainForm = m_SetMain;
            Program.NotifySelf();
        }
    }
}