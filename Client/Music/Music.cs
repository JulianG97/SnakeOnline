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

        public void PlayMusic(string song)
        {
            musicPlayer.settings.setMode("loop", true);
            musicPlayer.URL = GetMusicDirectory() + song + ".mp3";
            musicPlayer.controls.play();
        }

        public void StopMusic()
        {
            musicPlayer.controls.stop();
        }

        public void PlaySound(string sound)
        {
            soundPlayer.URL = GetMusicDirectory() + sound + ".mp3";
            soundPlayer.controls.play();
        }

        private string GetMusicDirectory()
        {
            string path = Directory.GetCurrentDirectory();
            string[] pathArray = path.Split('\\');

            path = pathArray[0];

            for (int i = 1; i < pathArray.Length; i++)
            {
                path = path + "\\" + pathArray[i];

                if (pathArray[i] == "Client")
                {
                    break;
                }
            }

            return path + "\\Music\\";
        }
    }
}
