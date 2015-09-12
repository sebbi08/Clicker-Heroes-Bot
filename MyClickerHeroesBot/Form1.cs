using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClickerHeroesBot.Properties;

namespace MyClickerHeroesBot
{



    public partial class Form1 : Form
    {
        private int _clickableFound = 0;

        private Bot _bot;

        public Form1()
        {
            InitializeComponent();
        }

        public void FoundClickable()
        {
            _clickableFound++;
            ClickableCount.Text = _clickableFound + "";
        }

        public void StartBot()
        {
            _bot = new Bot();
            Thread botThread = new Thread(_bot.StartRun);
            botThread.Start();
        }

        private void GetClickables_Click(object sender, EventArgs e)
        {
            if (_bot.ClickableTimer.Enabled)
            {
                _bot.ClickableTimer.Stop();
            }
            else
            {
                _bot.ClickableTimer.Start();
            }

            GetClickablesButton.BackColor = _bot.ClickableTimer.Enabled ? Color.LimeGreen : Color.Red;
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            if (_bot.HeroMaxLevelTimer.Enabled)
            {
                _bot.HeroMaxLevelTimer.Stop();
                _bot.ClickableTimer.Stop();
                _bot.ProgressEnableTimer.Stop();
                GetClickablesButton.Enabled = false;
            }
            else
            {
                _bot.HeroMaxLevelTimer.Start();
                _bot.ProgressEnableTimer.Start();
                GetClickablesButton.Enabled = true;
            }

            startButton.BackColor = _bot.HeroMaxLevelTimer.Enabled ? Color.LimeGreen : Color.Red;
            GetClickablesButton.BackColor = _bot.ClickableTimer.Enabled ? Color.LimeGreen : Color.Red;
        }
    }

    
}
