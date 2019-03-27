using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace WrathOfTheRuined
{
    public class Music
    {
        public SoundPlayer soundplayer;

        public SoundPlayer StartMusic(string songName)
        {
            string songPath = "Songs/";
            songPath += songName;
            songPath += ".wav";
            SoundPlayer Music = new SoundPlayer();
            Music.SoundLocation = songPath;
            Music.PlayLooping();
            return Music;
        }

        public void StopMusic(SoundPlayer Music)
        {
            Music.Stop();
            Music.Dispose();
        }
    }
}
