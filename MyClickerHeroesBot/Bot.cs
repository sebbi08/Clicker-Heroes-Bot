using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyClickerHeroesBot.Properties;
using Timer = System.Timers.Timer;

namespace MyClickerHeroesBot
{
    class Bot
    {

        private Form1 form;

        private readonly WindowInterActionHelper helper;

        private static readonly TimeSpan HeroLevelIntervall = TimeSpan.FromSeconds(3);
        private static readonly TimeSpan ClickableIntervall = TimeSpan.FromSeconds(20);
        private static readonly TimeSpan EnableProgressModeIntervall = TimeSpan.FromSeconds(60);
        public Timer HeroMaxLevelTimer { get; private set; }
        public Timer ClickableTimer { get; private set; }
        public Timer ProgressEnableTimer { get; private set; }

        public Bot()
        {
            form = Program.getForm();
            helper = WindowInterActionHelper.getInstance();
        }

        public void StartRun()
        {
            HeroMaxLevelTimer = new Timer
            {
                Interval = HeroLevelIntervall.TotalMilliseconds,
                AutoReset = true
            };
            HeroMaxLevelTimer.Elapsed += (sender, args) => LevelHeroToMax();

            ClickableTimer = new Timer
            {
                Interval = ClickableIntervall.TotalMilliseconds,
                AutoReset = true
            };
            ClickableTimer.Elapsed += (sender, args) => ClickClickable();

            ProgressEnableTimer = new Timer
            {
                Interval = EnableProgressModeIntervall.TotalMilliseconds,
                AutoReset = true
            };
            ProgressEnableTimer.Elapsed += (sender, args) => EnableProgressionMode();
        }

        private void LevelHeroToMax()
        {

            Point heroLvlButton = FindHeroLevelButton();
            if (heroLvlButton.IsEmpty)
            {
                HeroMaxLevelTimer.Stop();
                ScroleToTop();
                while (heroLvlButton.IsEmpty)
                {
                    ScroleDown();
                    heroLvlButton = FindHeroLevelButton();
                }
            }
            
            helper.SendKeyDown(WindowInterActionHelper.VKeys.VK_Q);
            helper.SendLeftClick(heroLvlButton);
            helper.SendKeyUp(WindowInterActionHelper.VKeys.VK_Q);
            Thread.Sleep(100);
            helper.ClearMousFokus();

            if (!HeroMaxLevelTimer.Enabled)
            {
                HeroMaxLevelTimer.Start();
            }
        }

        private void ScroleDown()
        {
            Point scroleDownButton = helper.SeartchBitmapAutoTolerance(Resources.ScroleDownBtn).Center();
            helper.SendLeftClick(scroleDownButton);
            helper.SendLeftClick(scroleDownButton);
            helper.SendLeftClick(scroleDownButton);
        }


        private void ScroleToTop()
        {
            while (helper.SeartchBitmapAutoTolerance(Resources.ScrolledUp).IsEmpty)
            {
                Point scroleUpButton = helper.SeartchBitmapAutoTolerance(Resources.ScroleUpBtn).Center();
                helper.SendLeftClick(scroleUpButton);
                helper.SendLeftClick(scroleUpButton);
                helper.SendLeftClick(scroleUpButton);
                helper.SendLeftClick(scroleUpButton);
            }
        }

        private Point FindHeroLevelButton()
        {
            Point heroLevelButton = new Point();
            Rectangle level = helper.SeartchBitmapAutoTolerance(Resources.Level);
            heroLevelButton.X = !level.IsEmpty ? level.Center().X : helper.SeartchBitmapAutoTolerance(Resources.Hire).Center().X;
            Rectangle hero = helper.SeartchBitmapAutoTolerance(Resources.Samurai);
            if (hero.IsEmpty)
            {
                return Point.Empty;
            }
            heroLevelButton.Y = hero.Center().Y;
            return heroLevelButton;
        }

        private void LevelHeroOneHundredLevel()
        {
            helper.SendKeyDown(WindowInterActionHelper.VKeys.VK_CONTROL);
            helper.SendLeftClick(new Point(30, 250));
            helper.SendKeyUp(WindowInterActionHelper.VKeys.VK_CONTROL);
            Thread.Sleep(100);
            helper.ClearMousFokus();
        }

        private void ClickClickable()
        {
            Rectangle fish = helper.SeartchBitmapAutoTolerance(Resources.Fish);
            if (!fish.IsEmpty)
            {
                helper.SendLeftClick(fish.Center());
                form.FoundClickable();
            }
        }

        private void EnableProgressionMode()
        {
            Rectangle progressEnableButton = helper.SeartchBitmapAutoTolerance(Resources.ProgDisabeld);
            if (!progressEnableButton.IsEmpty)
            {
                helper.SendLeftClick(progressEnableButton.Center());
                helper.ClearMousFokus();
            }
        }
    }
}
