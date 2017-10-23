using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.IO;

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

        public void PlayMusic(Song song)
        {
            musicPlayer.settings.setMode("loop", true);
            int songNumber = (int)song;
            musicPlayer.URL = Directory.GetCurrentDirectory() + "\\Music\\" + "song" + songNumber + ".mp3";
            musicPlayer.controls.play();
        }

        public void StopMusic()
        {
            musicPlayer.controls.stop();
        }

        public void PlaySound(Sound sound)
        {
            int soundNumber = (int)sound;
            soundPlayer.URL = Directory.GetCurrentDirectory() + "\\Sound\\" +  "sound" +soundNumber + ".mp3";
            soundPlayer.controls.play();
        }
    }
}
