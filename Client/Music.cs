using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Client
{
    public class Music
    {
        private WindowsMediaPlayer musicPlayer;
        private WindowsMediaPlayer soundPlayer;

        public Music()
        {
            musicPlayer = new WindowsMediaPlayer();
            soundPlayer = new WindowsMediaPlayer();
        }

        public void PlayMusic(string song)
        {
            musicPlayer.settings.setMode("loop", true);
            musicPlayer.URL = song + ".mp3";
            musicPlayer.controls.play();
        }

        public void StopMusic()
        {
            musicPlayer.controls.stop();
        }

        public void PlaySound(string sound)
        {
            soundPlayer.URL = sound + ".mp3";
            soundPlayer.controls.play();
        }
    }
}
