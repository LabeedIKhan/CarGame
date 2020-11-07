using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarGame
{
    class GameManager
    {

        private int speed = 30;
        private int score = 0;
        BackgroundMusic backmusic = new BackgroundMusic();

        public GameManager()
        {

        }

        public int Speed { get => speed; set => speed = value; }
        public int Score { get => score; set => score = value; }

        public void RunBackGroundMusic()
        {
        
            backmusic.StartMusic();
        }

        public void StopBackGroundMusic()
        {
            
            backmusic.StopMusic();
        }


    }

    class BackgroundMusic
    {

        SoundPlayer player;

        public BackgroundMusic()
        {

        }


        public void StartMusic()
        {
            player = new SoundPlayer(@"RecordingForGame.wav");
            player.Load();
            player.PlayLooping();

        }
        public void StopMusic()
        {

            player.Stop();
        }

    }
}
