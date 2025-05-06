using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Sounds
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void Play()
        {
            player.URL = pathToMedia + "stardust.wav";
            player.settings.volume = 30;
            player.controls.play();
            player.settings.setMode("loop", true);
        }

        public void Play(string songName)
        {
            player.URL = pathToMedia + songName + ".wav";
            player.controls.play();
        }

        public void PlayEat()
        {
            player.URL = pathToMedia + "click.wav";
            player.settings.volume = 100;
            player.controls.play();
        }
    }
}