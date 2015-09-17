using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClickerHeroesBot.Forms;
using MyClickerHeroesBot.Properties;

namespace MyClickerHeroesBot
{
    static class Program
    {
        static Form1 _form;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _form = new Form1();
            _form.StartBot();
            Application.Run(_form);
        }

        public static Form1 getForm()
        {
            return _form;
        }
    }

    
}
