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

        public SoundPlayer StartMusic(System.IO.UnmanagedMemoryStream song)
        {
            SoundPlayer Music = new SoundPlayer
            {
                Stream = song
            };
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
